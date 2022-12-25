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
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Cake.Jekyll.Tests.Commands.Build;

public class JekyllBuildCommandTests
{
    [Fact]
    public void Should_Throw_If_Settings_Are_Null()
    {
        var fixture = new JekyllBuildCommandFixture
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
        var fixture = new JekyllBuildCommandFixture();

        var result = fixture.Run();

        result.Args.Should().Be("exec jekyll build");
    }

    [Fact]
    public void Should_Add_Default_Arguments_When_Bundler_Is_Disabled()
    {
        var fixture = new JekyllBuildCommandFixture
        {
            Settings = { DoNotUseBundler = true },
        };

        fixture.GivenJekyllToolExist();

        var result = fixture.Run();

        result.Args.Should().Be("build");
    }

    [Fact]
    public void Should_Add_Single_Configuration_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllBuildCommandFixture
        {
            Settings = { Configuration = @"c:\_config.yml" },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll build --config ""c:/_config.yml""");
    }

    [Fact]
    public void Should_Add_Multiple_Configuration_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllBuildCommandFixture
        {
            Settings = { Configuration = new [] { @"c:\_config1.yml", @"c:\_config2.yml" } },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll build --config ""c:/_config1.yml"" ""c:/_config2.yml""");
    }

    [Fact]
    public void Should_Add_Source_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllBuildCommandFixture
        {
            Settings = { Source = @"c:\sourceDir" },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll build --source ""c:/sourceDir""");
    }

    [Fact]
    public void Should_Add_Destination_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllBuildCommandFixture
        {
            Settings = { Destination = @"c:\destinationDir" },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll build --destination ""c:/destinationDir""");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --future")]
    [Theory]
    public void Should_Add_Future_To_Arguments_If_Not_Null(bool? future, string expected)
    {
        var fixture = new JekyllBuildCommandFixture
        {
            Settings = { Future = future },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll build{expected}");
    }

    [InlineData(null, null)]
    [InlineData(5, " --limit_posts 5")]
    [Theory]
    public void Should_Add_LimitPosts_To_Arguments_If_Not_Null(int? limitPosts, string expected)
    {
        var fixture = new JekyllBuildCommandFixture
        {
            Settings = { LimitPosts = limitPosts },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll build{expected}");
    }

    [InlineData(null, null)]
    [InlineData(false, " --no-watch")]
    [InlineData(true, " --watch")]
    [Theory]
    public void Should_Add_Watch_To_Arguments_If_Not_Null(bool? regeneration, string expected)
    {
        var fixture = new JekyllBuildCommandFixture
        {
            Settings = { Watch = regeneration },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll build{expected}");
    }

    [Fact]
    public void Should_Add_BaseUrl_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllBuildCommandFixture
        {
            Settings = { BaseUrl = @"http://localhost:8042" },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll build --baseurl ""http://localhost:8042""");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --force_polling")]
    [Theory]
    public void Should_Add_ForcePolling_To_Arguments_If_Not_Null(bool? forcePolling, string expected)
    {
        var fixture = new JekyllBuildCommandFixture
        {
            Settings = { ForcePolling = forcePolling },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll build{expected}");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --lsi")]
    [Theory]
    public void Should_Add_Lsi_To_Arguments_If_Not_Null(bool? lsi, string expected)
    {
        var fixture = new JekyllBuildCommandFixture
        {
            Settings = { Lsi = lsi },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll build{expected}");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --drafts")]
    [Theory]
    public void Should_Add_Drafts_To_Arguments_If_Not_Null(bool? drafts, string expected)
    {
        var fixture = new JekyllBuildCommandFixture
        {
            Settings = { Drafts = drafts },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll build{expected}");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --unpublished")]
    [Theory]
    public void Should_Add_Unpublished_To_Arguments_If_Not_Null(bool? unpublished, string expected)
    {
        var fixture = new JekyllBuildCommandFixture
        {
            Settings = { Unpublished = unpublished },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll build{expected}");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --disable-disk-cache")]
    [Theory]
    public void Should_Add_DisableDiskCache_To_Arguments_If_Not_Null(bool? disableDiskCache, string expected)
    {
        var fixture = new JekyllBuildCommandFixture
        {
            Settings = { DisableDiskCache = disableDiskCache },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll build{expected}");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --incremental")]
    [Theory]
    public void Should_Add_IncrementalBuild_To_Arguments_If_Not_Null(bool? incrementalBuild, string expected)
    {
        var fixture = new JekyllBuildCommandFixture
        {
            Settings = { IncrementalBuild = incrementalBuild },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll build{expected}");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --strict_front_matter")]
    [Theory]
    public void Should_Add_StrictFrontMatter_To_Arguments_If_Not_Null(bool? strictFrontMatter, string expected)
    {
        var fixture = new JekyllBuildCommandFixture
        {
            Settings = { StrictFrontMatter = strictFrontMatter },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll build{expected}");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --safe")]
    [Theory]
    public void Should_Add_Safe_To_Arguments_If_Not_Null(bool? safeMode, string expected)
    {
        var fixture = new JekyllBuildCommandFixture
        {
            Settings = { SafeMode = safeMode },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll build{expected}");
    }

    [Fact]
    public void Should_Add_Single_Plugin_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllBuildCommandFixture
        {
            Settings = { Plugins = @"c:\pluginDir\" },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll build --plugins ""c:/pluginDir""");
    }

    [Fact]
    public void Should_Add_Multiple_Plugin_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllBuildCommandFixture
        {
            Settings = { Plugins = new [] { @"c:\pluginDir1", @"c:\pluginDir2" } },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll build --plugins ""c:/pluginDir1"" ""c:/pluginDir2""");
    }

    [Fact]
    public void Should_Add_Layouts_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllBuildCommandFixture
        {
            Settings = { Layouts = @"c:\layoutsDir" },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll build --layouts ""c:/layoutsDir""");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --profile")]
    [Theory]
    public void Should_Add_LiquidProfile_To_Arguments_If_Not_Null(bool? liquidProfile, string expected)
    {
        var fixture = new JekyllBuildCommandFixture
        {
            Settings = { LiquidProfile = liquidProfile },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll build{expected}");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --trace")]
    [Theory]
    public void Should_Add_Trace_To_Arguments_If_Not_Null(bool? trace, string expected)
    {
        var fixture = new JekyllBuildCommandFixture
        {
            Settings = { Trace = trace },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll build{expected}");
    }

    [MemberData(nameof(JekyllLogLevels))]
    [Theory]
    public void Should_Add_LogLevel_To_Arguments_If_Not_Null(JekyllLogLevel? logLevel, string expected)
    {
        var fixture = new JekyllBuildCommandFixture
        {
            Settings = { LogLevel = logLevel },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll build{expected}");
    }

    public static IEnumerable<object[]> JekyllLogLevels
    {
        get
        {
            var logLevelsMap = Enum.GetValues(typeof(JekyllLogLevel))
                .Cast<JekyllLogLevel?>()
                .ToDictionary(v => v, _ => string.Empty);

            logLevelsMap[JekyllLogLevel.Quiet] = " --quiet";
            logLevelsMap[JekyllLogLevel.Verbose] = " --verbose";

            return logLevelsMap
                .Select(kvp => new object[] { kvp.Key, kvp.Value })
                .Concat(new [] { new object[] { null, null } });
        }
    }
}
