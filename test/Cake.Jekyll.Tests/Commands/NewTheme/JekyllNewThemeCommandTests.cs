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
using FluentAssertions;
using Xunit;

namespace Cake.Jekyll.Tests.Commands.NewTheme;

public class JekyllNewThemeCommandTests
{
    [Fact]
    public void Should_Throw_If_Settings_Are_Null()
    {
        var fixture = new JekyllNewThemeCommandFixture
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
        var fixture = new JekyllNewThemeCommandFixture();

        var result = fixture.Run();

        result.Args.Should().Be("exec jekyll new-theme");
    }

    [Fact]
    public void Should_Add_Default_Arguments_When_Bundler_Is_Disabled()
    {
        var fixture = new JekyllNewThemeCommandFixture
        {
            Settings = { DoNotUseBundler = true },
        };

        fixture.GivenJekyllToolExist();

        var result = fixture.Run();

        result.Args.Should().Be("new-theme");
    }

    [Fact]
    public void Should_Add_Name_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllNewThemeCommandFixture
        {
            Settings = { Name = @"mytheme" },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll new-theme ""mytheme""");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --code-of-conduct")]
    [Theory]
    public void Should_Add_Blank_To_Arguments_If_Not_Null(bool? codeOfConduct, string expected)
    {
        var fixture = new JekyllNewThemeCommandFixture
        {
            Settings = { CodeOfConduct = codeOfConduct },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll new-theme{expected}");
    }

    [Fact]
    public void Should_Add_Source_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllNewThemeCommandFixture
        {
            Settings = { Source = @"c:\sourceDir" },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll new-theme --source ""c:/sourceDir""");
    }

    [Fact]
    public void Should_Add_Destination_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllNewThemeCommandFixture
        {
            Settings = { Destination = @"c:\destinationDir" },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll new-theme --destination ""c:/destinationDir""");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --safe")]
    [Theory]
    public void Should_Add_Safe_To_Arguments_If_Not_Null(bool? safeMode, string expected)
    {
        var fixture = new JekyllNewThemeCommandFixture
        {
            Settings = { SafeMode = safeMode },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll new-theme{expected}");
    }

    [Fact]
    public void Should_Add_Single_Plugin_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllNewThemeCommandFixture
        {
            Settings = { Plugins = @"c:\pluginDir\" },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll new-theme --plugins ""c:/pluginDir""");
    }

    [Fact]
    public void Should_Add_Multiple_Plugin_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllNewThemeCommandFixture
        {
            Settings = { Plugins = new [] { @"c:\pluginDir1", @"c:\pluginDir2" } },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll new-theme --plugins ""c:/pluginDir1"" ""c:/pluginDir2""");
    }

    [Fact]
    public void Should_Add_Layouts_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllNewThemeCommandFixture
        {
            Settings = { Layouts = @"c:\layoutsDir" },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll new-theme --layouts ""c:/layoutsDir""");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --profile")]
    [Theory]
    public void Should_Add_LiquidProfile_To_Arguments_If_Not_Null(bool? liquidProfile, string expected)
    {
        var fixture = new JekyllNewThemeCommandFixture
        {
            Settings = { LiquidProfile = liquidProfile },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll new-theme{expected}");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --trace")]
    [Theory]
    public void Should_Add_Trace_To_Arguments_If_Not_Null(bool? trace, string expected)
    {
        var fixture = new JekyllNewThemeCommandFixture
        {
            Settings = { Trace = trace },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll new-theme{expected}");
    }
}
