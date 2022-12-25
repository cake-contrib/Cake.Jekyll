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

using System;
using FluentAssertions;
using Xunit;

namespace Cake.Jekyll.Tests.Commands.Version;

public class JekyllVersionCommandTests
{
    [Fact]
    public void Should_Throw_If_Settings_Are_Null()
    {
        var fixture = new JekyllVersionCommandFixture
        {
            Settings = null,
        };

        Action action = () => fixture.Run();

        action.Should().Throw<ArgumentNullException>()
            .Which.ParamName.Should().Be("settings");
    }

    [Fact]
    public void Should_Add_Default_Arguments()
    {
        var fixture = new JekyllVersionCommandFixture();

        var result = fixture.Run();

        result.Args.Should().Be("exec jekyll --version");
    }

    [Fact]
    public void Should_Add_Default_Arguments_When_Bundler_Is_Disabled()
    {
        var fixture = new JekyllVersionCommandFixture
        {
            Settings = { DoNotUseBundler = true },
        };

        fixture.GivenJekyllToolExist();

        var result = fixture.Run();

        result.Args.Should().Be("--version");
    }
}
