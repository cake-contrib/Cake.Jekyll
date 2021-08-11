| README.md |
|:---|

<div align="center">

![Cake.Jekyll](asset/cake-jekyll-logo.png)

</div>

<h1 align="center">Cake.Jekyll</h1>
<div align="center">

Cross-platform addin for the [Cake](https://cakebuild.net) build automation system that makes [Jekyll](https://jekyllrb.com) available in Cake builds. Cake.Jekyll works on Windows, Linux, and macOS. Jekyll is a blog-aware, static site generator in Ruby.

[![NuGet Version](https://img.shields.io/nuget/v/Cake.Jekyll.svg?color=blue&style=flat-square)](https://www.nuget.org/packages/Cake.Jekyll/) [![Stack Overflow Cake Build](https://img.shields.io/badge/stack%20overflow-cakebuild-orange.svg?style=flat-square)](http://stackoverflow.com/questions/tagged/cakebuild)

</div>

## Give a Star! :star:

If you like or are using this project please give it a star. Thanks!

## Prerequisites

In order to use Cake.Jekyll, you will need to install [Jekyll](https://jekyllrb.com) first. By default, Cake.Jekyll uses [Bundler](https://bundler.io) to run Jekyll, but this can be disabled via settings if you want to run Jekyll directly. For more information on why using Bundler might be a good idea, read "[Using Jekyll with Bundler](https://jekyllrb.com/tutorials/using-jekyll-with-bundler/)".

## Getting started :rocket:

This addin exposes the functionality of [Jekyll](https://jekyllrb.com) to the Cake DSL by being a very thin wrapper around its command line interface; this means that you can use the [Jekyll commands](https://jekyllrb.com/docs/usage/) you would normally use via command line, but with a Cake-friendly interface.

First of all, you need to import `Cake.Jekyll` in your build script by using the [`addin`](http://cakebuild.net/docs/fundamentals/preprocessor-directives) directive:

```csharp
#addin "nuget:?package=Cake.Jekyll&version=1.0.1"
```

_Make sure the `&version=` attribute references the [latest version of Cake.Jekyll](https://www.nuget.org/packages/Cake.Jekyll/) compatible with the Cake runner that you are using. Check the [compatibility table](#compatibility) to see which version of Cake.Jekyll to choose_.

Next, call the Jekyll commands you'd like to use:

```csharp
#addin "nuget:?package=Cake.Jekyll&version=1.0.1"

Task("Build")
    .Does(() =>
{
    JekyllBuild(settings => settings
        .RenderDrafts()
        .EnableIncrementalBuild()
        .EnableTrace()
    );
});

RunTarget("Build");
```

## Jekyll command aliases available

| Method                              | Description                                                              | Settings                   |
| ----------------------------------- | ------------------------------------------------------------------------ | -------------------------- |
| [`JekyllClean`](#jekyllclean)       | Clean your site (removes site output and metadata file) without building | [`JekyllCleanSettings`]    |
| [`JekyllBuild`](#jekyllbuild)       | Build your Jekyll site                                                   | [`JekyllBuildSettings`]    |
| [`JekyllServe`](#jekyllserve)       | Serve your Jekyll site locally                                           | [`JekyllServeSettings`]    |
| [`JekyllDoctor`](#jekylldoctor)     | Search your site and print specific deprecation warnings                 | [`JekyllDoctorSettings`]   |
| [`JekyllNew`](#jekyllnew)           | Create a new Jekyll site scaffold                                        | [`JekyllNewSettings`]      |
| [`JekyllNewTheme`](#jekyllnewtheme) | Create a new Jekyll theme scaffold                                       | [`JekyllNewThemeSettings`] |
| [`JekyllVersion`](#jekyllversion)   | Print the name and version                                               | `N/A`                      |

[`JekyllCleanSettings`]: src/Cake.Jekyll/Commands/Clean/JekyllCleanSettings.cs
[`JekyllBuildSettings`]: src/Cake.Jekyll/Commands/Build/JekyllBuildSettings.cs
[`JekyllServeSettings`]: src/Cake.Jekyll/Commands/Serve/JekyllServeSettings.cs
[`JekyllDoctorSettings`]: src/Cake.Jekyll/Commands/Doctor/JekyllDoctorSettings.cs
[`JekyllNewSettings`]: src/Cake.Jekyll/Commands/New/JekyllNewSettings.cs
[`JekyllNewThemeSettings`]: src/Cake.Jekyll/Commands/NewTheme/JekyllNewThemeSettings.cs

### Usage Examples

In the [sample](sample/) folder, there are several examples of usage:

- [Simple pipeline with `JekyllxxxSettings` instance](sample/jekyll-settings.cake)
- [Simple pipeline using the configurator pattern](sample/jekyll-configurator.cake)

### JekyllClean

<details>
  <summary>JekyllClean settings. Click to expand.</summary>

| Property            | Extension Method         | Description                                     |
| ------------------- | ------------------------ | ----------------------------------------------- |
| `Configuration`     | `WithConfiguration`      | Custom configuration file                       |
| `Source`            | `SetSource`              | Custom source directory                         |
| `Destination`       | `SetDestination`         | Custom destination directory                    |
| `Future`            | `PublishFuture`          | Publishes posts with a future date              |
| `LimitPosts`        | `LimitPosts`             | Limits the number of posts to parse and publish |
| `Watch`             | `EnableWatch`            | Watch for changes and rebuild                   |
| `BaseUrl`           | `SetBaseUrl`             | Serve the website from the given base URL       |
| `ForcePolling`      | `ForcePolling`           | Force watch to use polling                      |
| `Lsi`               | `UseLsi`                 | Use LSI for improved related posts              |
| `Drafts`            | `RenderDrafts`           | Render posts in the `_drafts` folder            |
| `Unpublished`       | `RenderUnpublished`      | Render posts that were marked as unpublished    |
| `DisableDiskCache`  | `DisableDiskCache`       | Disable caching to disk in non-safe mode        |
| `IncrementalBuild`  | `EnableIncrementalBuild` | Enable incremental rebuild                      |
| `StrictFrontMatter` | `UseStrictFrontMatter`   | Fail if errors are present in front matter      |
| `SafeMode`          | `EnableSafeMode`         | Safe mode                                       |
| `Plugins`           | `WithPlugins`            | Plugins directory (defaults to `./_plugins`)    |
| `Layouts`           | `SetLayouts`             | Layouts directory (defaults to `./_layouts`)    |
| `LiquidProfile`     | `EnableLiquidProfile`    | Generate a Liquid rendering profile             |
| `Trace`             | `EnableTrace`            | Show the full backtrace when an error occurs    |
| `LogLevel`          | `SetLogLevel`            | Print verbose output or silence output          |
| `WorkingDirectory`  | `SetWorkingDirectory`    | The working directory to run Jekyll             |
| `DoNotUseBundler`   | `DoNotUseBundler`        | Run Jekyll directly, without Bundler            |

</details>

### JekyllBuild

<details>
  <summary>JekyllBuild settings. Click to expand.</summary>

| Property            | Extension Method         | Description                                     |
| ------------------- | ------------------------ | ----------------------------------------------- |
| `Configuration`     | `WithConfiguration`      | Custom configuration file                       |
| `Source`            | `SetSource`              | Custom source directory                         |
| `Destination`       | `SetDestination`         | Custom destination directory                    |
| `Future`            | `PublishFuture`          | Publishes posts with a future date              |
| `LimitPosts`        | `LimitPosts`             | Limits the number of posts to parse and publish |
| `Watch`             | `EnableWatch`            | Watch for changes and rebuild                   |
| `BaseUrl`           | `SetBaseUrl`             | Serve the website from the given base URL       |
| `ForcePolling`      | `ForcePolling`           | Force watch to use polling                      |
| `Lsi`               | `UseLsi`                 | Use LSI for improved related posts              |
| `Drafts`            | `RenderDrafts`           | Render posts in the `_drafts` folder            |
| `Unpublished`       | `RenderUnpublished`      | Render posts that were marked as unpublished    |
| `DisableDiskCache`  | `DisableDiskCache`       | Disable caching to disk in non-safe mode        |
| `IncrementalBuild`  | `EnableIncrementalBuild` | Enable incremental rebuild                      |
| `StrictFrontMatter` | `UseStrictFrontMatter`   | Fail if errors are present in front matter      |
| `SafeMode`          | `EnableSafeMode`         | Safe mode                                       |
| `Plugins`           | `WithPlugins`            | Plugins directory (defaults to `./_plugins`)    |
| `Layouts`           | `SetLayouts`             | Layouts directory (defaults to `./_layouts`)    |
| `LiquidProfile`     | `EnableLiquidProfile`    | Generate a Liquid rendering profile             |
| `Trace`             | `EnableTrace`            | Show the full backtrace when an error occurs    |
| `LogLevel`          | `SetLogLevel`            | Print verbose output or silence output          |
| `WorkingDirectory`  | `SetWorkingDirectory`    | The working directory to run Jekyll             |
| `DoNotUseBundler`   | `DoNotUseBundler`        | Run Jekyll directly, without Bundler            |

</details>

### JekyllServe

<details>
  <summary>JekyllServe settings. Click to expand.</summary>

| Property             | Extension Method         | Description                                                            |
| -------------------- | ------------------------ | ---------------------------------------------------------------------- |
| `SslCertificate`     | `UseSslCertificate`      | X.509 (SSL) certificate                                                |
| `SslKey`             | `UseSslKey`              | X.509 (SSL) private key                                                |
| `Hostname`           | `SetHostname`            | Host to bind to                                                        |
| `Port`               | `SetPort`                | Port to listen on                                                      |
| `OpenUrl`            | `OpenUrl`                | Launch your site in a browser                                          |
| `Detach`             | `Detach`                 | Run the server in the background                                       |
| `ShowDirListing`     | `ShowDirListing`         | Show a directory listing instead of loading your index file            |
| `SkipInitialBuild`   | `SkipInitialBuild`       | Skips the initial site build which occurs before the server is started |
| `LiveReload`         | `UseLiveReload`          | Use LiveReload to automatically refresh browsers                       |
| `LiveReloadIgnore`   | `WithLiveReloadIgnore`   | Files for LiveReload to ignore                                         |
| `LiveReloadMinDelay` | `SetLiveReloadMinDelay`  | Minimum reload delay                                                   |
| `LiveReloadMaxDelay` | `SetLiveReloadMaxDelay`  | Maximum reload delay                                                   |
| `LiveReloadPort`     | `SetLiveReloadPort`      | Port for LiveReload to listen on                                       |
| `Configuration`      | `WithConfiguration`      | Custom configuration file                                              |
| `Source`             | `SetSource`              | Custom source directory                                                |
| `Destination`        | `SetDestination`         | Custom destination directory                                           |
| `Future`             | `PublishFuture`          | Publishes posts with a future date                                     |
| `LimitPosts`         | `LimitPosts`             | Limits the number of posts to parse and publish                        |
| `Watch`              | `EnableWatch`            | Watch for changes and rebuild                                          |
| `BaseUrl`            | `SetBaseUrl`             | Serve the website from the given base URL                              |
| `ForcePolling`       | `ForcePolling`           | Force watch to use polling                                             |
| `Lsi`                | `UseLsi`                 | Use LSI for improved related posts                                     |
| `Drafts`             | `RenderDrafts`           | Render posts in the `_drafts` folder                                   |
| `Unpublished`        | `RenderUnpublished`      | Render posts that were marked as unpublished                           |
| `DisableDiskCache`   | `DisableDiskCache`       | Disable caching to disk in non-safe mode                               |
| `IncrementalBuild`   | `EnableIncrementalBuild` | Enable incremental rebuild                                             |
| `StrictFrontMatter`  | `UseStrictFrontMatter`   | Fail if errors are present in front matter                             |
| `SafeMode`           | `EnableSafeMode`         | Safe mode                                                              |
| `Plugins`            | `WithPlugins`            | Plugins directory (defaults to `./_plugins`)                           |
| `Layouts`            | `SetLayouts`             | Layouts directory (defaults to `./_layouts`)                           |
| `LiquidProfile`      | `EnableLiquidProfile`    | Generate a Liquid rendering profile                                    |
| `Trace`              | `EnableTrace`            | Show the full backtrace when an error occurs                           |
| `LogLevel`           | `SetLogLevel`            | Print verbose output or silence output                                 |
| `WorkingDirectory`   | `SetWorkingDirectory`    | The working directory to run Jekyll                                    |
| `DoNotUseBundler`    | `DoNotUseBundler`        | Run Jekyll directly, without Bundler                                   |

</details>

### JekyllDoctor

<details>
  <summary>JekyllDoctor settings. Click to expand.</summary>

| Property           | Extension Method      | Description                                  |
| ------------------ | --------------------- | -------------------------------------------- |
| `Configuration`    | `WithConfiguration`   | Custom configuration file                    |
| `Source`           | `SetSource`           | Custom source directory                      |
| `Destination`      | `SetDestination`      | Custom destination directory                 |
| `SafeMode`         | `EnableSafeMode`      | Safe mode                                    |
| `Plugins`          | `WithPlugins`         | Plugins directory (defaults to `./_plugins`) |
| `Layouts`          | `SetLayouts`          | Layouts directory (defaults to `./_layouts`) |
| `LiquidProfile`    | `EnableLiquidProfile` | Generate a Liquid rendering profile          |
| `Trace`            | `EnableTrace`         | Show the full backtrace when an error occurs |
| `WorkingDirectory` | `SetWorkingDirectory` | The working directory to run Jekyll          |
| `DoNotUseBundler`  | `DoNotUseBundler`     | Run Jekyll directly, without Bundler         |

</details>

### JekyllNew

<details>
  <summary>JekyllNew settings. Click to expand.</summary>

| Property           | Extension Method      | Description                                  |
| ------------------ | --------------------- | -------------------------------------------- |
| `Path`             |                       | Path to scaffold the site                    |
| `Force`            | `EnableForce`         | Force creation even if PATH already exists   |
| `Blank`            | `EnableBlank`         | Creates scaffolding but with empty files     |
| `SkipBundle`       | `SkipBundle`          | Skip `bundle install`                        |
| `Source`           | `SetSource`           | Custom source directory                      |
| `Destination`      | `SetDestination`      | Custom destination directory                 |
| `SafeMode`         | `EnableSafeMode`      | Safe mode                                    |
| `Plugins`          | `WithPlugins`         | Plugins directory (defaults to `./_plugins`) |
| `Layouts`          | `SetLayouts`          | Layouts directory (defaults to `./_layouts`) |
| `LiquidProfile`    | `EnableLiquidProfile` | Generate a Liquid rendering profile          |
| `Trace`            | `EnableTrace`         | Show the full backtrace when an error occurs |
| `WorkingDirectory` | `SetWorkingDirectory` | The working directory to run Jekyll          |
| `DoNotUseBundler`  | `DoNotUseBundler`     | Run Jekyll directly, without Bundler         |

</details>

### JekyllNewTheme

<details>
  <summary>JekyllNewTheme settings. Click to expand.</summary>

| Property           | Extension Method       | Description                                  |
| ------------------ | ---------------------- | -------------------------------------------- |
| `Name`             |                        | The name of the theme                        |
| `CodeOfConduct`    | `IncludeCodeOfConduct` | Include a Code of Conduct                    |
| `Source`           | `SetSource`            | Custom source directory                      |
| `Destination`      | `SetDestination`       | Custom destination directory                 |
| `SafeMode`         | `EnableSafeMode`       | Safe mode                                    |
| `Plugins`          | `WithPlugins`          | Plugins directory (defaults to `./_plugins`) |
| `Layouts`          | `SetLayouts`           | Layouts directory (defaults to `./_layouts`) |
| `LiquidProfile`    | `EnableLiquidProfile`  | Generate a Liquid rendering profile          |
| `Trace`            | `EnableTrace`          | Show the full backtrace when an error occurs |
| `WorkingDirectory` | `SetWorkingDirectory`  | The working directory to run Jekyll          |
| `DoNotUseBundler`  | `DoNotUseBundler`      | Run Jekyll directly, without Bundler         |

</details>

### JekyllVersion

<details>
  <summary>JekyllNewTheme settings. Click to expand.</summary>

| Property           | Extension Method      | Description                          |
| ------------------ | --------------------- | ------------------------------------ |
| `WorkingDirectory` | `SetWorkingDirectory` | The working directory to run Jekyll  |
| `DoNotUseBundler`  | `DoNotUseBundler`     | Run Jekyll directly, without Bundler |

</details>

## Compatibility

Cake.Jekyll is compatible with all [Cake runners](https://cakebuild.net/docs/running-builds/runners/), and below you can find which version of Cake.Jekyll you should use based on the version of the Cake runner you're using.

| Cake runner     | Cake.Jekyll            | Cake addin directive                                |
|:---------------:|:----------------------:| --------------------------------------------------- |
| 1.0.0 or higher | 1.0.0 or higher        | `#addin "nuget:?package=Cake.Jekyll&version=1.0.1"` |
| < 1.0.0         | _N/A_                  | _(not supported)_                                   |

## Discussion

For questions and to discuss ideas & feature requests, use the [GitHub discussions on the Cake GitHub repository](https://github.com/cake-build/cake/discussions), under the [Extension Q&A](https://github.com/cake-build/cake/discussions/categories/extension-q-a) category.

[![Join in the discussion on the Cake repository](https://img.shields.io/badge/GitHub-Discussions-green?logo=github)](https://github.com/cake-build/cake/discussions)

## Release History

Click on the [Releases](https://github.com/cake-contrib/Cake.Jekyll/releases) tab on GitHub.

---

_Copyright &copy; 2021 C. Augusto Proiete & Contributors - Provided under the [MIT License](LICENSE)._
