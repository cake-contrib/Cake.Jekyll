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

using Cake.Jekyll.Commands.Version;
using FluentAssertions;
using Xunit;

namespace Cake.Jekyll.Tests.Commands.Version;

public class JekyllVersionSettingsExtensionsTests
{
    [Fact]
    public void SetWorkingDirectory_Should_Set_WorkingDirectory()
    {
        var settings = new JekyllVersionSettings();

        settings.SetWorkingDirectory(@"c:\workingDir");

        settings.WorkingDirectory.Should().NotBeNull();
        settings.WorkingDirectory.FullPath.Should().Be("c:/workingDir");
    }

    [Fact]
    public void DoNotUseBundler_Should_Set_DoNotUseBundler()
    {
        var settings = new JekyllVersionSettings();

        settings.DoNotUseBundler();

        settings.DoNotUseBundler.Should().BeTrue();
    }
}
