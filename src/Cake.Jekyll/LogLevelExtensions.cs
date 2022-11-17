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

using Cake.Core.Diagnostics;

namespace Cake.Jekyll
{
    /// <summary>
    /// Extensions to <see cref="LogLevel"/>
    /// </summary>
    public static class LogLevelExtensions
    {
        /// <summary>
        /// Convert a <see cref="LogLevel"/> to the best equivalent <see cref="JekyllLogLevel"/>.
        /// </summary>
        /// <param name="logLevel">The log level.</param>
        /// <returns>The mapped <see cref="JekyllLogLevel"/></returns>
        public static JekyllLogLevel ToJekyllLogLevel(this LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Fatal:
                case LogLevel.Error:
                    return JekyllLogLevel.Quiet;

                case LogLevel.Verbose:
                case LogLevel.Debug:
                    return JekyllLogLevel.Verbose;

                default:
                    return JekyllLogLevel.Default;
            }
        }

        /// <summary>
        /// Convert a nullable <see cref="LogLevel"/> to the best equivalent <see cref="JekyllLogLevel"/>.
        /// </summary>
        /// <param name="logLevel">The log level.</param>
        /// <returns>The mapped <see cref="JekyllLogLevel"/></returns>
        public static JekyllLogLevel ToJekyllLogLevel(this LogLevel? logLevel)
        {
            return logLevel.HasValue ? ToJekyllLogLevel(logLevel.Value) : JekyllLogLevel.Default;
        }
    }
}
