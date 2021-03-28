#region Copyright 2021 C. Augusto Proiete & Contributors
//
// Licensed under the MIT (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://opensource.org/licenses/MIT
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

using System;
using Cake.Core.IO;

namespace Cake.Jekyll.Commands.Build
{
    /// <summary>
    /// Extensions for <see cref="JekyllBuildSettings"/>.
    /// </summary>
    public static class JekyllBuildSettingsExtensions
    {
        /// <summary>
        /// Sets the working directory which should be used to run the Jekyll command.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="path">Working directory which should be used to run the Jekyll command.</param>
        /// <exception cref="ArgumentNullException"/>
        /// <returns>The <paramref name="settings"/> instance with <see cref="Cake.Core.Tooling.ToolSettings.WorkingDirectory"/> set to <paramref name="path"/>.</returns>
        public static JekyllBuildSettings SetWorkingDirectory(this JekyllBuildSettings settings, DirectoryPath path)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (path is null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            settings.WorkingDirectory = path;

            return settings;
        }

        /// <summary>
        /// Specifies if Bundler should not be used to execute Jekyll.
        /// `jekyll` instead of `bundle exec`...
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="enable"><see langword="true"/> to use Bundler to execute Jekyll, otherwise <see langword="false"/>.</param>
        /// <exception cref="ArgumentNullException"/>
        /// <returns>The <paramref name="settings"/> instance with the <see cref="JekyllSettings.DoNotUseBundler"/> property updated with the value provided in <paramref name="enable"/>.</returns>
        public static JekyllBuildSettings DoNotUseBundler(this JekyllBuildSettings settings, bool? enable = true)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.DoNotUseBundler = enable;

            return settings;
        }

        /// <summary>
        /// Specifies one or more configuration file(s) instead of using `_config.yml` automatically.
        /// Settings in later files override settings in earlier files.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="configurationFilePaths">One or more custom configuration file(s).</param>
        /// <returns>The <paramref name="settings"/> instance with updated with the <paramref name="configurationFilePaths"/> provided.</returns>
        public static JekyllBuildSettings WithConfiguration(this JekyllBuildSettings settings, params FilePath[] configurationFilePaths)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.Configuration = configurationFilePaths;

            return settings;
        }

        /// <summary>
        /// Sets the Site Source directory, the directory where Jekyll will read files (defaults to `./`).
        /// -s, --source DIR
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="sourceDirectoryPath">The source directory (defaults to `./`).</param>
        /// <returns>The <paramref name="settings"/> instance with updated with the <paramref name="sourceDirectoryPath"/> provided.</returns>
        public static JekyllBuildSettings SetSource(this JekyllBuildSettings settings, DirectoryPath sourceDirectoryPath)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.Source = sourceDirectoryPath;

            return settings;
        }

        /// <summary>
        /// Sets the Site Destination directory (defaults to `./_site`).
        /// -d, --destination DIR
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="destinationDirectoryPath">The destination directory (defaults to `./_site`).</param>
        /// <returns>The <paramref name="settings"/> instance with updated with the <paramref name="destinationDirectoryPath"/> provided.</returns>
        public static JekyllBuildSettings SetDestination(this JekyllBuildSettings settings, DirectoryPath destinationDirectoryPath)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.Destination = destinationDirectoryPath;

            return settings;
        }

        /// <summary>
        /// Sets if posts or collection documents with a future date should be published.
        /// --future
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="enable"><see langword="true"/> to publish posts with a future date, otherwise <see langword="false"/>.</param>
        /// <returns>The <paramref name="settings"/> instance with the <see cref="JekyllBuildSettings.Future"/> property updated with the value provided in <paramref name="enable"/>.</returns>
        public static JekyllBuildSettings PublishFuture(this JekyllBuildSettings settings, bool enable = true)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.Future = enable;

            return settings;
        }

        /// <summary>
        /// Sets a limit to the number of posts to parse and publish.
        /// --limit_posts NUM
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="maxPosts">The maximum number of posts to parse and publish.</param>
        /// <returns>The <paramref name="settings"/> instance with updated with the <paramref name="maxPosts"/> provided.</returns>
        public static JekyllBuildSettings LimitPosts(this JekyllBuildSettings settings, int? maxPosts)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.LimitPosts = maxPosts;

            return settings;
        }

        /// <summary>
        /// Sets if auto-regeneration of the site when files are modified be enabled.
        /// -w, --[no-]watch
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="enable"><see langword="true"/> to watch for changes and rebuild, otherwise <see langword="false"/>.</param>
        /// <returns>The <paramref name="settings"/> instance with the <see cref="JekyllBuildSettings.Watch"/> property updated with the value provided in <paramref name="enable"/>.</returns>
        public static JekyllBuildSettings EnableWatch(this JekyllBuildSettings settings, bool enable = true)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.Watch = enable;

            return settings;
        }

        /// <summary>
        /// Sets the base URL to serve the website from.
        /// -b, --baseurl URL
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="baseUrl">The base URL to serve the website from.</param>
        /// <returns>The <paramref name="settings"/> instance with updated with the <paramref name="baseUrl"/> provided.</returns>
        public static JekyllBuildSettings SetBaseUrl(this JekyllBuildSettings settings, string baseUrl)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.BaseUrl = baseUrl;

            return settings;
        }

        /// <summary>
        /// Sets if polling should be used when watching for changes.
        /// --force_polling
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="enable"><see langword="true"/> to force polling when watching for changes, otherwise <see langword="false"/>.</param>
        /// <returns>The <paramref name="settings"/> instance with the <see cref="JekyllBuildSettings.ForcePolling"/> property updated with the value provided in <paramref name="enable"/>.</returns>
        public static JekyllBuildSettings ForcePolling(this JekyllBuildSettings settings, bool enable = true)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.ForcePolling = enable;

            return settings;
        }

        /// <summary>
        /// Sets if an index for related posts using latent semantic indexing (LSI) for improved related posts should be produced.
        /// Requires the classifier-reborn plugin.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="enable"><see langword="true"/> to use latent semantic indexing (LSI) for improved related posts, otherwise <see langword="false"/>.</param>
        /// <returns>The <paramref name="settings"/> instance with the <see cref="JekyllBuildSettings.Lsi"/> property updated with the value provided in <paramref name="enable"/>.</returns>
        public static JekyllBuildSettings UseLsi(this JekyllBuildSettings settings, bool enable = true)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.Lsi = enable;

            return settings;
        }

        /// <summary>
        /// Sets if posts in the `_drafts` folder should be processed and rendered.
        /// -D, --drafts
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="enable"><see langword="true"/> to render posts in the _drafts folder, otherwise <see langword="false"/>.</param>
        /// <returns>The <paramref name="settings"/> instance with the <see cref="JekyllBuildSettings.Drafts"/> property updated with the value provided in <paramref name="enable"/>.</returns>
        public static JekyllBuildSettings RenderDrafts(this JekyllBuildSettings settings, bool enable = true)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.Drafts = enable;

            return settings;
        }

        /// <summary>
        /// Sets if posts that were marked as unpublished should be rendered.
        /// --unpublished
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="enable"><see langword="true"/> to render posts that were marked as unpublished, otherwise <see langword="false"/>.</param>
        /// <returns>The <paramref name="settings"/> instance with the <see cref="JekyllBuildSettings.Unpublished"/> property updated with the value provided in <paramref name="enable"/>.</returns>
        public static JekyllBuildSettings RenderUnpublished(this JekyllBuildSettings settings, bool enable = true)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.Unpublished = enable;

            return settings;
        }

        /// <summary>
        /// Sets if caching to disk in non-safe mode should be disabled.
        /// --disable-disk-cache
        /// 
        /// Disable caching of content to disk in order to skip creating a `.jekyll-cache` or similar
        /// directory at the source to avoid interference with virtual environments and third-party
        /// directory watchers. Caching to disk is always disabled in safe mode.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="disable"><see langword="true"/> to disable caching to disk in non-safe mode, otherwise <see langword="false"/>.</param>
        /// <returns>The <paramref name="settings"/> instance with the <see cref="JekyllBuildSettings.DisableDiskCache"/> property updated with the value provided in <paramref name="disable"/>.</returns>
        public static JekyllBuildSettings DisableDiskCache(this JekyllBuildSettings settings, bool disable = true)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.DisableDiskCache = disable;

            return settings;
        }

        /// <summary>
        /// Sets if the experimental incremental rebuilds should be enabled.
        /// Incremental build only re-builds posts and pages that have changed, resulting in significant performance
        /// improvements for large sites, but may also break site generation in certain cases.
        /// -I, --incremental
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="enable"><see langword="true"/> to enable incremental rebuild, otherwise <see langword="false"/>.</param>
        /// <returns>The <paramref name="settings"/> instance with the <see cref="JekyllBuildSettings.IncrementalBuild"/> property updated with the value provided in <paramref name="enable"/>.</returns>
        public static JekyllBuildSettings EnableIncrementalBuild(this JekyllBuildSettings settings, bool enable = true)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.IncrementalBuild = enable;

            return settings;
        }

        /// <summary>
        /// Sets if the build should fail if there is a YAML syntax error in a page's front matter.
        /// --strict_front_matter
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="enable"><see langword="true"/> to fail if errors are present in front matter, otherwise <see langword="false"/>.</param>
        /// <returns>The <paramref name="settings"/> instance with the <see cref="JekyllBuildSettings.StrictFrontMatter"/> property updated with the value provided in <paramref name="enable"/>.</returns>
        public static JekyllBuildSettings UseStrictFrontMatter(this JekyllBuildSettings settings, bool enable = true)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.StrictFrontMatter = enable;

            return settings;
        }

        /// <summary>
        /// Sets if both non-whitelisted plugins and caching to disk should be disabled, and if symbolic links should be ignore.
        /// --safe
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="enable"><see langword="true"/> to disable non-whitelisted plugins, caching safe disk, and ignore symbolic links, otherwise <see langword="false"/>.</param>
        /// <returns>The <paramref name="settings"/> instance with the <see cref="JekyllBuildSettings.SafeMode"/> property updated with the value provided in <paramref name="enable"/>.</returns>
        public static JekyllBuildSettings EnableSafeMode(this JekyllBuildSettings settings, bool enable = true)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.SafeMode = enable;

            return settings;
        }

        /// <summary>
        /// Sets the Plugins directory instead of using `_plugins/` automatically.
        /// -p, --plugins DIR1[,DIR2,...]
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="pluginDirectoryPaths">One or more plugin directory path(s).</param>
        /// <returns>The <paramref name="settings"/> instance with updated with the <paramref name="pluginDirectoryPaths"/> provided.</returns>
        public static JekyllBuildSettings WithPlugins(this JekyllBuildSettings settings, params DirectoryPath[] pluginDirectoryPaths)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.Plugins = pluginDirectoryPaths;

            return settings;
        }

        /// <summary>
        /// Sets the layout directory instead of using `_layouts/` automatically
        /// --layouts DIR
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="layoutsDirectory">The layouts directory (defaults to ./_layouts).</param>
        /// <returns>The <paramref name="settings"/> instance with updated with the <paramref name="layoutsDirectory"/> provided.</returns>
        public static JekyllBuildSettings SetLayouts(this JekyllBuildSettings settings, DirectoryPath layoutsDirectory)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.Layouts = layoutsDirectory;

            return settings;
        }

        /// <summary>
        /// Sets if a Liquid rendering profile should be generated.
        /// --profile
        /// 
        /// Liquid rendering profile helps you identify performance bottlenecks.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="enable"><see langword="true"/> to generate a Liquid rendering profile, otherwise <see langword="false"/>.</param>
        /// <returns>The <paramref name="settings"/> instance with the <see cref="JekyllBuildSettings.LiquidProfile"/> property updated with the value provided in <paramref name="enable"/>.</returns>
        public static JekyllBuildSettings EnableLiquidProfile(this JekyllBuildSettings settings, bool enable = true)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.LiquidProfile = enable;

            return settings;
        }

        /// <summary>
        /// Sets if the full backtrace should be shown when an error occurs.
        /// -t, --trace
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="enable"><see langword="true"/> to show the full backtrace when an error occurs, otherwise <see langword="false"/>.</param>
        /// <returns>The <paramref name="settings"/> instance with the <see cref="JekyllBuildSettings.Trace"/> property updated with the value provided in <paramref name="enable"/>.</returns>
        public static JekyllBuildSettings EnableTrace(this JekyllBuildSettings settings, bool enable = true)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.Trace = enable;

            return settings;
        }

        /// <summary>
        /// Sets the log level which should be used to run the Jekyll command.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="logLevel">Log level which should be used to run the Jekyll command.</param>
        /// <returns>The <paramref name="settings"/> instance with updated with the <paramref name="logLevel"/> provided.</returns>
        public static JekyllBuildSettings SetLogLevel(this JekyllBuildSettings settings, JekyllLogLevel? logLevel)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.LogLevel = logLevel;

            return settings;
        }
    }
}
