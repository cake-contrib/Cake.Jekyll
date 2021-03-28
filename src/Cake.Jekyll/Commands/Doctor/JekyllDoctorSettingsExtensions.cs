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

namespace Cake.Jekyll.Commands.Doctor
{
    /// <summary>
    /// Extensions for <see cref="JekyllDoctorSettings"/>.
    /// </summary>
    public static class JekyllDoctorSettingsExtensions
    {
        /// <summary>
        /// Sets the working directory which should be used to run the Jekyll command.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="path">Working directory which should be used to run the Jekyll command.</param>
        /// <exception cref="ArgumentNullException"/>
        /// <returns>The <paramref name="settings"/> instance with <see cref="Cake.Core.Tooling.ToolSettings.WorkingDirectory"/> set to <paramref name="path"/>.</returns>
        public static JekyllDoctorSettings SetWorkingDirectory(this JekyllDoctorSettings settings, DirectoryPath path)
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
        public static JekyllDoctorSettings DoNotUseBundler(this JekyllDoctorSettings settings, bool? enable = true)
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
        public static JekyllDoctorSettings WithConfiguration(this JekyllDoctorSettings settings, params FilePath[] configurationFilePaths)
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
        public static JekyllDoctorSettings SetSource(this JekyllDoctorSettings settings, DirectoryPath sourceDirectoryPath)
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
        public static JekyllDoctorSettings SetDestination(this JekyllDoctorSettings settings, DirectoryPath destinationDirectoryPath)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.Destination = destinationDirectoryPath;

            return settings;
        }

        /// <summary>
        /// Sets if both non-whitelisted plugins and caching to disk should be disabled, and if symbolic links should be ignore.
        /// --safe
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="enable"><see langword="true"/> to disable non-whitelisted plugins, caching safe disk, and ignore symbolic links, otherwise <see langword="false"/>.</param>
        /// <returns>The <paramref name="settings"/> instance with the <see cref="JekyllDoctorSettings.SafeMode"/> property updated with the value provided in <paramref name="enable"/>.</returns>
        public static JekyllDoctorSettings EnableSafeMode(this JekyllDoctorSettings settings, bool enable = true)
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
        public static JekyllDoctorSettings WithPlugins(this JekyllDoctorSettings settings, params DirectoryPath[] pluginDirectoryPaths)
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
        public static JekyllDoctorSettings SetLayouts(this JekyllDoctorSettings settings, DirectoryPath layoutsDirectory)
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
        /// <returns>The <paramref name="settings"/> instance with the <see cref="JekyllDoctorSettings.LiquidProfile"/> property updated with the value provided in <paramref name="enable"/>.</returns>
        public static JekyllDoctorSettings EnableLiquidProfile(this JekyllDoctorSettings settings, bool enable = true)
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
        /// <returns>The <paramref name="settings"/> instance with the <see cref="JekyllDoctorSettings.Trace"/> property updated with the value provided in <paramref name="enable"/>.</returns>
        public static JekyllDoctorSettings EnableTrace(this JekyllDoctorSettings settings, bool enable = true)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.Trace = enable;

            return settings;
        }
    }
}
