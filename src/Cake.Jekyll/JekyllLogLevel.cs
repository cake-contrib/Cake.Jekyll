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

namespace Cake.Jekyll
{
    /// <summary>
    /// Define the Jekyll log levels
    /// </summary>
    public enum JekyllLogLevel
    {
        /// <summary>
        /// Use the equivalent log level by the running Cake build.
        /// </summary>
        Default,

        /// <summary>
        /// Silence the normal output from Jekyll during a build.
        /// -q, --quiet
        /// </summary>
        Quiet,

        /// <summary>
        /// Print verbose output.
        /// -V, --verbose
        /// </summary>
        Verbose,
    }
}
