var target = Argument("target", "Default");
var configuration = Argument("configuration", "Debug");
var buildNumber = 0;
 
// A directory path to an Artifacts directory.
var artifactsDirectory = Directory("./artifacts");
var sourceDir          = Directory("./src");
var testsDir           = Directory("./tests");
 
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
        DotNetCoreRestore("./src/MeetupApi.sln");
    });
 
// Find all csproj projects and build them using the build configuration specified as an argument.
 Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        var projects = GetFiles("./**/*.csproj");
        foreach(var project in projects)
        {
            Information(project.GetDirectory().FullPath);
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
            Information(project.ToString());
            DotNetCoreTest(
                project.ToString(),
                new DotNetCoreTestSettings()
                {
                    Configuration = configuration
                });
        }
    });
 
// The default task to run if none is explicitly specified. In this case, we want
// to run everything starting from Clean, all the way up to Pack.
Task("Default")
    .IsDependentOn("Test");
 
// Executes the task specified in the target argument.
RunTarget(target);