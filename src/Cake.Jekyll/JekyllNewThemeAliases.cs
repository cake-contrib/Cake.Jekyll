#region Copyright 2021-2022 C. Augusto Proiete & Contributors
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
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Jekyll.Commands.NewTheme;

namespace Cake.Jekyll
{
    /// <summary>
    /// <para>Functions to execute the <see href="https://jekyllrb.com">Jekyll</see> commands in Cake builds.</para>
    /// <para>
    /// In order to use this Cake addin, Bundle and/or Jekyll must be installed.
    /// </para>
    /// <para>
    /// In order to use it, add the following to your Cake build script:
    /// <code>
    /// <![CDATA[
    /// #addin "nuget:?package=Cake.Jekyll&version=x.y.z"
    /// ]]>
    /// </code>
    ///
    /// Where `x.y.z` is the version of the Cake.Jekyll package to use (latest version is recommended).
    /// </para>
    /// </summary>
    [CakeAliasCategory("Jekyll")]
    [CakeNamespaceImport("Cake.Jekyll.Commands.NewTheme")]
    public static class JekyllNewThemeAliases
    {
        /// <summary>
        /// Create a new Jekyll theme scaffold using the default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name of the theme.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// JekyllNewTheme("mytheme");
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("NewTheme")]
        public static void JekyllNewTheme(this ICakeContext context, string name)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            }

            context.JekyllNewTheme(name, new JekyllNewThemeSettings());
        }

        /// <summary>
        /// Create a new Jekyll theme scaffold using the settings returned by a configurator.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name of the theme.</param>
        /// <param name="configurator">The settings configurator.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// JekyllNewTheme("mytheme", settings => settings
        ///     .IncludeCodeOfConduct()
        /// );
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("NewTheme")]
        public static void JekyllNewTheme(this ICakeContext context, string name, Action<JekyllNewThemeSettings> configurator)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            }

            if (configurator is null)
            {
                throw new ArgumentNullException(nameof(configurator));
            }

            var settings = new JekyllNewThemeSettings
            {
                Name = name,
            };

            configurator(settings);

            context.JekyllNewTheme(name, settings);
        }

        /// <summary>
        /// Create a new Jekyll theme scaffold using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name of the theme.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// var settings = new JekyllNewThemeSettings 
        /// {
        ///     CodeOfConduct = true,
        /// };
        /// 
        /// JekyllNewTheme("mytheme", settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("NewTheme")]
        public static void JekyllNewTheme(this ICakeContext context, string name, JekyllNewThemeSettings settings)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            }

            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            AddinInformation.LogVersionInformation(context.Log);

            settings.Name = name;

            var command = new JekyllNewThemeCommand(context.FileSystem, context.Environment, context.ProcessRunner,
                context.Tools, context.Log);

            command.NewTheme(settings);
        }
    }
}
