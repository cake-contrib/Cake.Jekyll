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
using Cake.Jekyll.Commands.Build;

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
    [CakeNamespaceImport("Cake.Jekyll.Commands.Build")]
    public static class JekyllBuildAliases
    {
        /// <summary>
        /// Build your site using the default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// JekyllBuild();
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Build")]
        public static void JekyllBuild(this ICakeContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.JekyllBuild(new JekyllBuildSettings());
        }

        /// <summary>
        /// Build your site using the settings returned by a configurator.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="configurator">The settings configurator.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// JekyllBuild(settings => settings.SetLogLevel(JekyllLogLevel.Verbose));
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Build")]
        public static void JekyllBuild(this ICakeContext context, Action<JekyllBuildSettings> configurator)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (configurator is null)
            {
                throw new ArgumentNullException(nameof(configurator));
            }

            var settings = new JekyllBuildSettings();
            configurator(settings);

            context.JekyllBuild(settings);
        }

        /// <summary>
        /// Build your site using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// var settings = new JekyllBuildSettings 
        /// {
        ///     LogLevel = JekyllLogLevel.Verbose,
        /// };
        /// 
        /// JekyllBuild(settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Build")]
        public static void JekyllBuild(this ICakeContext context, JekyllBuildSettings settings)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            AddinInformation.LogVersionInformation(context.Log);

            var command = new JekyllBuildCommand(context.FileSystem, context.Environment, context.ProcessRunner,
                context.Tools, context.Log);

            command.Build(settings);
        }
    }
}
