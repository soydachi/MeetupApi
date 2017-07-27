// // Target - The task you want to start. Runs the Default task if not specified.
// var target = Argument("Target", "Default");
// // Configuration - The build configuration (Debug/Release) to use.
// // 1. If command line parameter parameter passed, use that.
// // 2. Otherwise if an Environment variable exists, use that.
// var configuration = 
//     HasArgument("Configuration") ? Argument("Configuration") :
//     EnvironmentVariable("Configuration") != null ? EnvironmentVariable("Configuration") : "Release";
// // The build number to use in the version number of the built NuGet packages.
// // There are multiple ways this value can be passed, this is a common pattern.
// // 1. If command line parameter parameter passed, use that.
// // 2. Otherwise if running on AppVeyor, get it's build number.
// // 3. Otherwise if running on Travis CI, get it's build number.
// // 4. Otherwise if an Environment variable exists, use that.
// // 5. Otherwise default the build number to 0.
// var buildNumber =
//     HasArgument("BuildNumber") ? Argument<int>("BuildNumber") :
//     EnvironmentVariable("BuildNumber") != null ? int.Parse(EnvironmentVariable("BuildNumber")) : 0;

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var buildNumber = 0;
 
// A directory path to an Artifacts directory.
var artifactsDirectory = Directory("./artifacts");
 
// Deletes the contents of the Artifacts folder if it should contain anything from a previous build.
Task("Clean")
    .Does(() =>
    {
        CleanDirectory(artifactsDirectory);

        CleanDirectories("./**/bin/" + configuration);
        CleanDirectories("./**/obj/" + configuration);
    });
 
// Run dotnet restore to restore all package references.
Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
    {
        DotNetCoreRestore("src/MeetupApi.sln");
    });
 
// Find all csproj projects and build them using the build configuration specified as an argument.
 Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        var projects = GetFiles("./**/*.csproj");
        foreach(var project in projects)
        {
            DotNetCoreBuild(
                project.GetDirectory().FullPath,
                new DotNetCoreBuildSettings()
                {
                    Configuration = configuration
                });
        }
    });
 
// Look under a 'Tests' folder and run dotnet test against all of those projects.
// Then drop the XML test results file in the Artifacts folder at the root.
Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
    {
        var projects = GetFiles("./tests/**/*.csproj");
        foreach(var project in projects)
        {
            DotNetCoreTest(
                project.GetDirectory().FullPath,
                new DotNetCoreTestSettings()
                {
                    ArgumentCustomization = args => args
                        .Append("-xml")
                        .Append(artifactsDirectory.Path.CombineWithFilePath(project.GetFilenameWithoutExtension()).FullPath + ".xml"),
                    Configuration = configuration,
                    NoBuild = true
                });
        }
    });
 
// The default task to run if none is explicitly specified. In this case, we want
// to run everything starting from Clean, all the way up to Pack.
Task("Default")
    .IsDependentOn("Test");
 
// Executes the task specified in the target argument.
RunTarget(target);