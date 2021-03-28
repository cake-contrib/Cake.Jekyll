#addin "nuget:?package=Cake.Jekyll&version=1.0.0"

var target = Argument("target", "build");

Task("clean")
    .Does(() =>
{
    JekyllClean(settings => settings
        .EnableTrace()
    );
});

Task("doctor")
    .IsDependentOn("clean")
    .Does(() =>
{
    JekyllDoctor(settings => settings
        .WithConfiguration("_config.yml", "_config2.yml")
        .EnableLiquidProfile()
        .EnableTrace()
    );
});

Task("build")
    .IsDependentOn("doctor")
    .Does(() =>
{
    JekyllBuild(settings => settings
        .WithConfiguration("_config.yml", "_config2.yml")
        .RenderDrafts()
        .PublishFuture()
        .EnableLiquidProfile()
        .EnableTrace()
    );
});

Task("preview")
    .IsDependentOn("build")
    .Does(() =>
{
    JekyllServe(settings => settings
        .WithConfiguration("_config.yml", "_config2.yml")
        .RenderDrafts()
        .PublishFuture()
        .SkipInitialBuild()
        .EnableIncrementalBuild()
        .UseLiveReload()
        .EnableWatch()
        .OpenUrl()
        .EnableLiquidProfile()
        .EnableTrace()
    );
});

RunTarget(target);
