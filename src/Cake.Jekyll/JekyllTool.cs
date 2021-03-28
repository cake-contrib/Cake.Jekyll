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
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Jekyll
{
    /// <summary>
    /// Base class for all Jekyll tools.
    /// </summary>
    /// <typeparam name="TSettings">The settings type.</typeparam>
    public abstract class JekyllTool<TSettings>: Tool<TSettings>
        where TSettings : JekyllSettings
    {
        private bool _useBundler;

        /// <summary>
        /// Initializes a new instance of the <see cref="JekyllTool{TSettings}"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        /// <param name="log">Cake log instance.</param>
        protected JekyllTool(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IToolLocator tools, ICakeLog log)
            : base(fileSystem, environment, processRunner, tools)
        {
            CakeLog = log ?? throw new ArgumentNullException(nameof(log));
        }

        /// <summary>
        /// Cake log instance.
        /// </summary>
        public ICakeLog CakeLog { get; }

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>The name of the tool.</returns>
        protected sealed override string GetToolName()
        {
            return "Jekyll";
        }

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>The tool executable name.</returns>
        protected sealed override IEnumerable<string> GetToolExecutableNames()
        {
            return _useBundler
                ? new[] { "bundle.cmd", "bundle.exe", "bundle" }
                : new[] { "jekyll.cmd", "jekyll.exe", "jekyll" };
        }

        /// <summary>
        /// Runs Jekyll.
        /// </summary>
        /// <param name="settings">The settings.</param>
        protected void RunCore(TSettings settings)
        {
            RunCore(settings, new ProcessSettings(), null);
        }

        /// <summary>
        /// Runs Jekyll.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="processSettings">The process settings. <c>null</c> for default settings.</param>
        /// <param name="postAction">Action which should be executed after running Jekyll. <c>null</c> for no action.</param>
        protected void RunCore(TSettings settings, ProcessSettings processSettings, Action<IProcess> postAction)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            _useBundler = !settings.DoNotUseBundler.GetValueOrDefault(false);

            settings.CakeVerbosityLevel ??= CakeLog.Verbosity;

            var args = GetArguments(settings);
            Run(settings, args, processSettings, postAction);
        }

        /// <summary>
        /// Builds the arguments for Jekyll.
        /// </summary>
        /// <param name="settings">Settings used for building the arguments.</param>
        /// <returns>Argument builder containing the arguments based on <paramref name="settings"/>.</returns>
        protected ProcessArgumentBuilder GetArguments(TSettings settings)
        {
            var args = new ProcessArgumentBuilder();

            if (_useBundler)
            {
                args.Append("exec");
                args.Append("jekyll");
            }

            settings.Evaluate(args);

            CakeLog.Verbose(_useBundler ? "Bundler arguments: {0}" : "Jekyll arguments: {0}", args.RenderSafe());

            return args;
        }
    }
}
