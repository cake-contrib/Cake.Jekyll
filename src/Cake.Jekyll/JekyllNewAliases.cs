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
using Cake.Core.IO;
using Cake.Jekyll.Commands.New;

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
    [CakeNamespaceImport("Cake.Jekyll.Commands.New")]
    public static class JekyllNewAliases
    {
        /// <summary>
        /// Create a new Jekyll site scaffold using the default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The path to scaffold the site.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// JekyllNew("myblog");
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("New")]
        public static void JekyllNew(this ICakeContext context, DirectoryPath path)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (path is null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            context.JekyllNew(path, new JekyllNewSettings());
        }

        /// <summary>
        /// Create a new Jekyll site scaffold using the settings returned by a configurator.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The path to scaffold the site.</param>
        /// <param name="configurator">The settings configurator.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// JekyllNew("myblog", settings => settings
        ///     .EnableForce()
        ///     .SkipBundle()
        /// );
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("New")]
        public static void JekyllNew(this ICakeContext context, DirectoryPath path, Action<JekyllNewSettings> configurator)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (path is null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (configurator is null)
            {
                throw new ArgumentNullException(nameof(configurator));
            }

            var settings = new JekyllNewSettings
            {
                Path = path,
            };

            configurator(settings);

            context.JekyllNew(path, settings);
        }

        /// <summary>
        /// Create a new Jekyll site scaffold using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The path to scaffold the site.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// var settings = new JekyllNewSettings 
        /// {
        ///     Force = true,
        ///     SkipBundle = true,
        /// };
        /// 
        /// JekyllNew("myblog", settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("New")]
        public static void JekyllNew(this ICakeContext context, DirectoryPath path, JekyllNewSettings settings)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (path is null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            AddinInformation.LogVersionInformation(context.Log);

            settings.Path = path;

            var command = new JekyllNewCommand(context.FileSystem, context.Environment, context.ProcessRunner,
                context.Tools, context.Log);

            command.New(settings);
        }
    }
}
