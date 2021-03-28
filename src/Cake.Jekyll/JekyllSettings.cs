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
using System.Globalization;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Jekyll.Core;
using Cake.Jekyll.Core.IO;

namespace Cake.Jekyll
{
    /// <summary>
    /// Jekyll tool settings.
    /// </summary>
    public abstract class JekyllSettings : ToolSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JekyllSettings"/> class.
        /// </summary>
        /// <param name="command">Command to run.</param>
        protected JekyllSettings(string command)
        {
            Command = command;
        }

        /// <summary>
        /// Gets or sets if Bundler should *not* be used to execute Jekyll (defaults to <see langword="false"/>).
        /// `jekyll` instead of `bundle exec`...
        /// </summary>
        public bool? DoNotUseBundler { get; set; }

        /// <summary>
        /// Gets or sets the Log level set by Cake.
        /// </summary>
        internal Verbosity? CakeVerbosityLevel { get; set; }

        /// <summary>
        /// Gets the command which should be run.
        /// </summary>
        protected string Command { get; }

        /// <summary>
        /// Evaluates the settings and writes them to <paramref name="args"/>.
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        internal void Evaluate(ProcessArgumentBuilder args)
        {
            args.Append(Command);

            EvaluateCore(args);
        }

        /// <summary>
        /// Evaluates the settings and writes them to <paramref name="args"/>.
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        protected virtual void EvaluateCore(ProcessArgumentBuilder args)
        {
        }

        /// <summary>
        /// Apply option from a string value
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        /// <param name="value">The string value.</param>
        protected void ApplyValue(ProcessArgumentBuilder args, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            args.AppendQuoted(value);
        }

        /// <summary>
        /// Apply option from a string value
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        /// <param name="optionName">The option name.</param>
        /// <param name="value">The string value.</param>
        protected void ApplyOption(ProcessArgumentBuilder args, string optionName, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            args.Append(optionName);
            args.AppendQuoted(value);
        }

        /// <summary>
        /// Apply option from a nullable boolean value
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        /// <param name="optionName">The option name.</param>
        /// <param name="optionValue">The nullable boolean value.</param>
        protected void ApplyOption(ProcessArgumentBuilder args, string optionName, bool? optionValue)
        {
            if (!optionValue.GetValueOrDefault(false))
            {
                return;
            }

            args.Append(optionName);
        }

        /// <summary>
        /// Apply option from a nullable int value
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        /// <param name="optionName">The option name.</param>
        /// <param name="optionValue">The nullable int value.</param>
        protected void ApplyOption(ProcessArgumentBuilder args, string optionName, int? optionValue)
        {
            if (!optionValue.HasValue)
            {
                return;
            }

            args.Append(optionName);
            args.Append(optionValue.Value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Apply option from file path(s)
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        /// <param name="optionName">The option name.</param>
        /// <param name="optionValue">The file path(s).</param>
        protected void ApplyOption(ProcessArgumentBuilder args, string optionName, OneOrMoreFilePaths optionValue)
        {
            if (optionValue is null || optionValue.Count == 0)
            {
                return;
            }

            args.Append(optionName);

            foreach (var filePath in optionValue)
            {
                args.AppendQuoted(filePath.FullPath);
            }
        }

        /// <summary>
        /// Apply option from directory path(s)
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        /// <param name="optionName">The option name.</param>
        /// <param name="optionValue">The directory path(s).</param>
        protected void ApplyOption(ProcessArgumentBuilder args, string optionName, OneOrMoreDirectoryPaths optionValue)
        {
            if (optionValue is null || optionValue.Count == 0)
            {
                return;
            }

            args.Append(optionName);

            foreach (var filePath in optionValue)
            {
                args.AppendQuoted(filePath.FullPath);
            }
        }

        /// <summary>
        /// Apply option for the Jekyll Log Level
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        /// <param name="logLevel">The Jekyll log level.</param>
        protected void ApplyOption(ProcessArgumentBuilder args, JekyllLogLevel? logLevel)
        {
            if (logLevel is null && CakeVerbosityLevel.HasValue)
            {
                logLevel = CakeVerbosityLevel.ToJekyllLogLevel();
            }

            switch (logLevel)
            {
                case JekyllLogLevel.Quiet:
                    args.Append("--quiet");
                    break;
                case JekyllLogLevel.Verbose:
                    args.Append("--verbose");
                    break;
            }
        }

        /// <summary>
        /// Apply option from one or more string values
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        /// <param name="optionName">The option name.</param>
        /// <param name="optionValue">The string value(s).</param>
        protected void ApplyOption(ProcessArgumentBuilder args, string optionName, OneOrMoreStrings optionValue)
        {
            if (optionValue is null || optionValue.Count == 0)
            {
                return;
            }

            args.Append(optionName);

            foreach (var value in optionValue)
            {
                args.AppendQuoted(value);
            }
        }

        /// <summary>
        /// Apply option from one or more string values
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        /// <param name="optionName">The option name.</param>
        /// <param name="optionValue">The string value(s).</param>
        protected void ApplyOption(ProcessArgumentBuilder args, string optionName, TimeSpan? optionValue)
        {
            if (optionValue is null)
            {
                return;
            }

            args.Append(optionName);
            args.Append(((int)optionValue.Value.TotalSeconds).ToString(CultureInfo.InvariantCulture));
        }
    }
}
