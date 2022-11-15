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

using System.Collections.Generic;
using Cake.Core.IO;
using Cake.Jekyll.Core.IO;
using FluentAssertions;
using Xunit;

namespace Cake.Jekyll.Tests.Core.IO
{
    public class OneOrMoreFilePathsTests
    {
        [Fact]
        public void OneOrMoreFilePath_has_implicit_conversion_from_string()
        {
            OneOrMoreFilePaths target = "_config.yml";

            target.Should().NotBeNull();
            target.Count.Should().Be(1);
            target[0].FullPath.Should().Be("_config.yml");
        }

        [Fact]
        public void OneOrMoreFilePath_has_implicit_conversion_from_string_array()
        {
            OneOrMoreFilePaths target = new [] { "_config1.yml", "_config2.yml" };

            target.Should().NotBeNull();
            target.Count.Should().Be(2);
            target[0].FullPath.Should().Be("_config1.yml");
            target[1].FullPath.Should().Be("_config2.yml");
        }

        [Fact]
        public void OneOrMoreFilePath_has_implicit_conversion_from_List_of_String()
        {
            OneOrMoreFilePaths target = new List<string> { "_config1.yml", "_config2.yml" };

            target.Should().NotBeNull();
            target.Count.Should().Be(2);
            target[0].FullPath.Should().Be("_config1.yml");
            target[1].FullPath.Should().Be("_config2.yml");
        }

        [Fact]
        public void OneOrMoreFilePath_has_implicit_conversion_from_FilePath()
        {
            OneOrMoreFilePaths target = FilePath.FromString("_config.yml");

            target.Should().NotBeNull();
            target.Count.Should().Be(1);
            target[0].FullPath.Should().Be("_config.yml");
        }

        [Fact]
        public void OneOrMoreFilePath_has_implicit_conversion_from_FilePath_array()
        {
            OneOrMoreFilePaths target = new [] { FilePath.FromString("_config1.yml"), FilePath.FromString("_config2.yml") };

            target.Should().NotBeNull();
            target.Count.Should().Be(2);
            target[0].FullPath.Should().Be("_config1.yml");
            target[1].FullPath.Should().Be("_config2.yml");
        }

        [Fact]
        public void OneOrMoreFilePath_has_implicit_conversion_from_List_of_FilePath()
        {
            OneOrMoreFilePaths target = new List<FilePath> { FilePath.FromString("_config1.yml"), FilePath.FromString("_config2.yml") };

            target.Should().NotBeNull();
            target.Count.Should().Be(2);
            target[0].FullPath.Should().Be("_config1.yml");
            target[1].FullPath.Should().Be("_config2.yml");
        }
    }
}
