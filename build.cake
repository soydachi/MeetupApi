// #tool "nuget:?package=TextTransform

// Target - The task you want to start. Runs the Default task if not specified.
var target = Argument("Target", "Default");
// Configuration - The build configuration (Debug/Release) to use.
var configuration = Argument("configuration", "Release");
// The build number to use in the version number of the built NuGet packages.
// There are multiple ways this value can be passed, this is a common pattern.
// 1. If command line parameter parameter passed, use that.
// 2. Otherwise if running on AppVeyor, get it's build number.
// 3. Otherwise if running on Travis CI, get it's build number.
// 4. Otherwise if an Environment variable exists, use that.
// 5. Otherwise default the build number to 0.
var buildNumber =
    HasArgument("BuildNumber") ? Argument<int>("BuildNumber") :
    AppVeyor.IsRunningOnAppVeyor ? AppVeyor.Environment.Build.Number :
    EnvironmentVariable("BuildNumber") != null ? int.Parse(EnvironmentVariable("BuildNumber")) : 0;
 
// A directory path to an Artifacts directory.
var artifactsDirectory = Directory("./artifacts");
var sourceDir          = new DirectoryPath("./src");
var testsDir           = new DirectoryPath("./tests");
 
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
        if (AppVeyor.IsRunningOnAppVeyor)
        {   
            Information(
            @"Environment:
            ApiUrl: {0}
            Configuration: {1}
            JobId: {2}
            JobName: {3}
            Platform: {4}
            ScheduledBuild: {5}",
            AppVeyor.Environment.ApiUrl,
            AppVeyor.Environment.Configuration,
            AppVeyor.Environment.JobId,
            AppVeyor.Environment.JobName,
            AppVeyor.Environment.Platform,
            AppVeyor.Environment.ScheduledBuild
        );

            TransformTextFile(sourceDir.Combine("Meetup.Api/SecretKeys.cs").ToString(), "*{", "}*")
            .WithToken("Secret", AppVeyor.Environment.Configuration("SecrectKey"))
            .Save(sourceDir.Combine("Meetup.Api/SecretKeys.cs").ToString());
        }

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