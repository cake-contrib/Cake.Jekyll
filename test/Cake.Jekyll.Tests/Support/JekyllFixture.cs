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
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Testing;
using Cake.Testing.Fixtures;

namespace Cake.Jekyll.Tests.Support
{
    internal abstract class JekyllFixture<TSettings> : JekyllFixture<TSettings, ToolFixtureResult>
        where TSettings : ToolSettings, new()
    {
        protected override ToolFixtureResult CreateResult(FilePath path, ProcessSettings process)
        {
            return new ToolFixtureResult(path, process);
        }
    }

    internal abstract class JekyllFixture<TSettings, TFixtureResult> : ToolFixture<TSettings, TFixtureResult>
        where TSettings : ToolSettings, new()
        where TFixtureResult : ToolFixtureResult
    {
        private readonly ICakeLog _log = new FakeLog();

        /// <summary>
        /// Ensures that the Jekyll tool exist under the tool settings tool path.
        /// </summary>
        public void GivenJekyllToolExist()
        {
            var jekyllToolPath = GetDefaultToolPath("jekyll");
            FileSystem.CreateFile(jekyllToolPath);
        }

        protected JekyllFixture()
            : base("bundle")
        {
            _log.Verbosity = Verbosity.Normal;
        }

        protected ICakeLog Log => _log;
    }
}
