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
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Jekyll.Commands.Build;

/// <summary>
/// Build your Jekyll site.
/// jekyll build
/// </summary>
/// <seealso cref="JekyllTool{JekyllBuildSettings}" />
internal class JekyllBuildCommand : JekyllTool<JekyllBuildSettings>
{
    public JekyllBuildCommand(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
        IToolLocator tools, ICakeLog log)
        : base(fileSystem, environment, processRunner, tools, log)
    {
    }

    public void Build(JekyllBuildSettings settings)
    {
        if (settings is null)
        {
            throw new ArgumentNullException(nameof(settings));
        }

        RunCore(settings);
    }
}
