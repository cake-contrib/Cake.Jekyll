#addin "nuget:?package=Cake.Jekyll&version=1.0.0"

var target = Argument("target", "build");

Task("clean")
    .Does(() =>
{
    var settings = new JekyllCleanSettings
    {
        Trace = true,
    };

    JekyllClean(settings);
});

Task("doctor")
    .IsDependentOn("clean")
    .Does(() =>
{
    var settings = new JekyllDoctorSettings
    {
        Configuration = new [] { "_config.yml", "_config2.yml" },
        LiquidProfile = true,
        Trace = true,
    };

    JekyllDoctor(settings);
});

Task("build")
    .IsDependentOn("doctor")
    .Does(() =>
{
    var settings = new JekyllBuildSettings
    {
        Configuration = new [] { "_config.yml", "_config2.yml" },
        Drafts = true,
        Future = true,
        LiquidProfile = true,
        Trace = true,
    };

    JekyllBuild(settings);
});

Task("preview")
    .IsDependentOn("build")
    .Does(() =>
{
    var settings = new JekyllServeSettings
    {
        Configuration = new [] { "_config.yml", "_config2.yml" },
        Drafts = true,
        Future = true,
        SkipInitialBuild = true,
        IncrementalBuild = true,
        LiveReload = true,
        Watch = true,
        OpenUrl = true,
        LiquidProfile = true,
        Trace = true,
    };

    JekyllServe(settings);
});

RunTarget(target);
