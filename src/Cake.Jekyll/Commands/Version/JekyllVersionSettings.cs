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


namespace Cake.Jekyll.Commands.Version
{
    /// <summary>
    /// Contains settings used by <see cref="JekyllVersionCommand"/>.
    /// </summary>
    public class JekyllVersionSettings : JekyllSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JekyllVersionCommand"/> class.
        /// </summary>
        public JekyllVersionSettings()
            : base("--version")
        {
        }
    }
}
