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
    /// Extensions to <see cref="Verbosity"/>
    /// </summary>
    public static class VerbosityExtensions
    {
        /// <summary>
        /// Convert a <see cref="Verbosity"/> to the best equivalent <see cref="JekyllLogLevel"/>.
        /// </summary>
        /// <param name="verbosity">The log level.</param>
        /// <returns>The mapped <see cref="JekyllLogLevel"/></returns>
        public static JekyllLogLevel ToJekyllLogLevel(this Verbosity verbosity)
        {
            switch (verbosity)
            {
                case Verbosity.Quiet:
                    return JekyllLogLevel.Quiet;

                case Verbosity.Verbose:
                case Verbosity.Diagnostic:
                    return JekyllLogLevel.Verbose;

                default:
                    return JekyllLogLevel.Default;
            }
        }

        /// <summary>
        /// Convert a <see cref="Verbosity"/> to the best equivalent <see cref="JekyllLogLevel"/>.
        /// </summary>
        /// <param name="verbosity">The log level.</param>
        /// <returns>The mapped <see cref="JekyllLogLevel"/></returns>
        public static JekyllLogLevel ToJekyllLogLevel(this Verbosity? verbosity)
        {
            return verbosity.HasValue ? ToJekyllLogLevel(verbosity.Value) : JekyllLogLevel.Default;
        }
    }
}
