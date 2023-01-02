#region Copyright 2021-2023 C. Augusto Proiete & Contributors
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

namespace Cake.Jekyll.Commands.Version;

/// <summary>
/// Extensions for <see cref="JekyllVersionSettings"/>.
/// </summary>
public static class JekyllVersionSettingsExtensions
{
    /// <summary>
    /// Sets the working directory which should be used to run the Jekyll command.
    /// </summary>
    /// <param name="settings">The settings.</param>
    /// <param name="path">Working directory which should be used to run the Jekyll command.</param>
    /// <exception cref="ArgumentNullException"/>
    /// <returns>The <paramref name="settings"/> instance with <see cref="Cake.Core.Tooling.ToolSettings.WorkingDirectory"/> set to <paramref name="path"/>.</returns>
    public static JekyllVersionSettings SetWorkingDirectory(this JekyllVersionSettings settings, DirectoryPath path)
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
    public static JekyllVersionSettings DoNotUseBundler(this JekyllVersionSettings settings, bool? enable = true)
    {
        if (settings is null)
        {
            throw new ArgumentNullException(nameof(settings));
        }

        settings.DoNotUseBundler = enable;

        return settings;
    }
}
