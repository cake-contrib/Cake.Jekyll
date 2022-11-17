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

namespace Cake.Jekyll.Tests.Commands.New
{
    public class JekyllNewCommandTests
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            var fixture = new JekyllNewCommandFixture
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
            var fixture = new JekyllNewCommandFixture();

            var result = fixture.Run();

            result.Args.Should().Be("exec jekyll new");
        }

        [Fact]
        public void Should_Add_Default_Arguments_When_Bundler_Is_Disabled()
        {
            var fixture = new JekyllNewCommandFixture
            {
                Settings = { DoNotUseBundler = true },
            };

            fixture.GivenJekyllToolExist();

            var result = fixture.Run();

            result.Args.Should().Be("new");
        }

        [Fact]
        public void Should_Add_Path_To_Arguments_If_Not_Null()
        {
            var fixture = new JekyllNewCommandFixture
            {
                Settings = { Path = @"c:\newSiteDir" },
            };

            var result = fixture.Run();

            result.Args.Should().Be(@"exec jekyll new ""c:/newSiteDir""");
        }

        [InlineData(null, null)]
        [InlineData(false, null)]
        [InlineData(true, " --force")]
        [Theory]
        public void Should_Add_Force_To_Arguments_If_Not_Null(bool? force, string expected)
        {
            var fixture = new JekyllNewCommandFixture
            {
                Settings = { Force = force },
            };

            var result = fixture.Run();

            result.Args.Should().Be($"exec jekyll new{expected}");
        }

        [InlineData(null, null)]
        [InlineData(false, null)]
        [InlineData(true, " --blank")]
        [Theory]
        public void Should_Add_Blank_To_Arguments_If_Not_Null(bool? blank, string expected)
        {
            var fixture = new JekyllNewCommandFixture
            {
                Settings = { Blank = blank },
            };

            var result = fixture.Run();

            result.Args.Should().Be($"exec jekyll new{expected}");
        }

        [InlineData(null, null)]
        [InlineData(false, null)]
        [InlineData(true, " --skip-bundle")]
        [Theory]
        public void Should_Add_SkipBundle_To_Arguments_If_Not_Null(bool? skipBundle, string expected)
        {
            var fixture = new JekyllNewCommandFixture
            {
                Settings = { SkipBundle = skipBundle },
            };

            var result = fixture.Run();

            result.Args.Should().Be($"exec jekyll new{expected}");
        }

        [Fact]
        public void Should_Add_Source_To_Arguments_If_Not_Null()
        {
            var fixture = new JekyllNewCommandFixture
            {
                Settings = { Source = @"c:\sourceDir" },
            };

            var result = fixture.Run();

            result.Args.Should().Be(@"exec jekyll new --source ""c:/sourceDir""");
        }

        [Fact]
        public void Should_Add_Destination_To_Arguments_If_Not_Null()
        {
            var fixture = new JekyllNewCommandFixture
            {
                Settings = { Destination = @"c:\destinationDir" },
            };

            var result = fixture.Run();

            result.Args.Should().Be(@"exec jekyll new --destination ""c:/destinationDir""");
        }

        [InlineData(null, null)]
        [InlineData(false, null)]
        [InlineData(true, " --safe")]
        [Theory]
        public void Should_Add_Safe_To_Arguments_If_Not_Null(bool? safeMode, string expected)
        {
            var fixture = new JekyllNewCommandFixture
            {
                Settings = { SafeMode = safeMode },
            };

            var result = fixture.Run();

            result.Args.Should().Be($"exec jekyll new{expected}");
        }

        [Fact]
        public void Should_Add_Single_Plugin_To_Arguments_If_Not_Null()
        {
            var fixture = new JekyllNewCommandFixture
            {
                Settings = { Plugins = @"c:\pluginDir\" },
            };

            var result = fixture.Run();

            result.Args.Should().Be(@"exec jekyll new --plugins ""c:/pluginDir""");
        }

        [Fact]
        public void Should_Add_Multiple_Plugin_To_Arguments_If_Not_Null()
        {
            var fixture = new JekyllNewCommandFixture
            {
                Settings = { Plugins = new [] { @"c:\pluginDir1", @"c:\pluginDir2" } },
            };

            var result = fixture.Run();

            result.Args.Should().Be(@"exec jekyll new --plugins ""c:/pluginDir1"" ""c:/pluginDir2""");
        }

        [Fact]
        public void Should_Add_Layouts_To_Arguments_If_Not_Null()
        {
            var fixture = new JekyllNewCommandFixture
            {
                Settings = { Layouts = @"c:\layoutsDir" },
            };

            var result = fixture.Run();

            result.Args.Should().Be(@"exec jekyll new --layouts ""c:/layoutsDir""");
        }

        [InlineData(null, null)]
        [InlineData(false, null)]
        [InlineData(true, " --profile")]
        [Theory]
        public void Should_Add_LiquidProfile_To_Arguments_If_Not_Null(bool? liquidProfile, string expected)
        {
            var fixture = new JekyllNewCommandFixture
            {
                Settings = { LiquidProfile = liquidProfile },
            };

            var result = fixture.Run();

            result.Args.Should().Be($"exec jekyll new{expected}");
        }

        [InlineData(null, null)]
        [InlineData(false, null)]
        [InlineData(true, " --trace")]
        [Theory]
        public void Should_Add_Trace_To_Arguments_If_Not_Null(bool? trace, string expected)
        {
            var fixture = new JekyllNewCommandFixture
            {
                Settings = { Trace = trace },
            };

            var result = fixture.Run();

            result.Args.Should().Be($"exec jekyll new{expected}");
        }
    }
}
