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

namespace Cake.Jekyll.Tests.Core.IO;

public class OneOrMoreDirectoryPathsTests
{
    [Fact]
    public void OneOrMoreDirectoryPath_has_implicit_conversion_from_string()
    {
        OneOrMoreDirectoryPaths target = "folder";

        target.Should().NotBeNull();
        target.Count.Should().Be(1);
        target[0].FullPath.Should().Be("folder");
    }

    [Fact]
    public void OneOrMoreDirectoryPath_has_implicit_conversion_from_string_array()
    {
        OneOrMoreDirectoryPaths target = new [] { "folder1", "folder2" };

        target.Should().NotBeNull();
        target.Count.Should().Be(2);
        target[0].FullPath.Should().Be("folder1");
        target[1].FullPath.Should().Be("folder2");
    }

    [Fact]
    public void OneOrMoreDirectoryPath_has_implicit_conversion_from_List_of_String()
    {
        OneOrMoreDirectoryPaths target = new List<string> { "folder1", "folder2" };

        target.Should().NotBeNull();
        target.Count.Should().Be(2);
        target[0].FullPath.Should().Be("folder1");
        target[1].FullPath.Should().Be("folder2");
    }

    [Fact]
    public void OneOrMoreDirectoryPath_has_implicit_conversion_from_DirectoryPath()
    {
        OneOrMoreDirectoryPaths target = DirectoryPath.FromString("folder");

        target.Should().NotBeNull();
        target.Count.Should().Be(1);
        target[0].FullPath.Should().Be("folder");
    }

    [Fact]
    public void OneOrMoreDirectoryPath_has_implicit_conversion_from_DirectoryPath_array()
    {
        OneOrMoreDirectoryPaths target = new [] { DirectoryPath.FromString("folder1"), DirectoryPath.FromString("folder2") };

        target.Should().NotBeNull();
        target.Count.Should().Be(2);
        target[0].FullPath.Should().Be("folder1");
        target[1].FullPath.Should().Be("folder2");
    }

    [Fact]
    public void OneOrMoreDirectoryPath_has_implicit_conversion_from_List_of_DirectoryPath()
    {
        OneOrMoreDirectoryPaths target = new List<DirectoryPath> { DirectoryPath.FromString("folder1"), DirectoryPath.FromString("folder2") };

        target.Should().NotBeNull();
        target.Count.Should().Be(2);
        target[0].FullPath.Should().Be("folder1");
        target[1].FullPath.Should().Be("folder2");
    }
}
