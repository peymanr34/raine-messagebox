var target = Argument("target", "Test");
var configuration = Argument("configuration", "Release");

var version = Argument("package-version", "");

var solution = "./Source/Raine.MessageBox.sln";
var artifacts = "./.artifacts";

Task("Clean")
    .Does(() =>
{
    CleanDirectory(artifacts);
    CleanDirectory($"./Source/Raine.MessageBox/bin/{configuration}");
});

Task("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetBuild(solution, new DotNetBuildSettings
    {
        NoIncremental = true,
        Configuration = configuration,
    });
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetTest(solution, new DotNetTestSettings
    {
        NoBuild = true,
        Configuration = configuration,
    });
});

Task("Pack")
    .IsDependentOn("Test")
    .Does(context =>
{
    var apiKey = context.EnvironmentVariable("NUGET_API_KEY");

    if (string.IsNullOrWhiteSpace(apiKey))
    {
        throw new CakeException("No NuGet API key specified.");
    }

    if (string.IsNullOrWhiteSpace(version))
    {
        throw new CakeException("No package version specified.");
    }

    string actualVersion = version;

    if (version.StartsWith("v"))
    {
        actualVersion = version.Substring(1);
    }

    DotNetPack(solution, new DotNetPackSettings
    {
        NoBuild = true,
        NoRestore = true,
        OutputDirectory = artifacts,
        Configuration = configuration,
        MSBuildSettings = new DotNetMSBuildSettings()
            .WithProperty("PackageVersion", actualVersion)
    });

    var files = GetFiles($"{artifacts}/*.nupkg");

    context.NuGetPush(files, new NuGetPushSettings
    {
        ApiKey = apiKey,
        Source = "https://api.nuget.org/v3/index.json",
    });
});

RunTarget(target);
