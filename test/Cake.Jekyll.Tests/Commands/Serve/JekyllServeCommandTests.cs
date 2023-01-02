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
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Cake.Jekyll.Tests.Commands.Serve;

public class JekyllServeCommandTests
{
    [Fact]
    public void Should_Throw_If_Settings_Are_Null()
    {
        var fixture = new JekyllServeCommandFixture
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
        var fixture = new JekyllServeCommandFixture();

        var result = fixture.Run();

        result.Args.Should().Be("exec jekyll serve");
    }

    [Fact]
    public void Should_Add_Default_Arguments_When_Bundler_Is_Disabled()
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { DoNotUseBundler = true },
        };

        fixture.GivenJekyllToolExist();

        var result = fixture.Run();

        result.Args.Should().Be("serve");
    }

    [Fact]
    public void Should_Add_Single_Configuration_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { Configuration = @"c:\_config.yml" },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll serve --config ""c:/_config.yml""");
    }

    [Fact]
    public void Should_Add_Multiple_Configuration_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { Configuration = new [] { @"c:\_config1.yml", @"c:\_config2.yml" } },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll serve --config ""c:/_config1.yml"" ""c:/_config2.yml""");
    }

    [Fact]
    public void Should_Add_Source_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { Source = @"c:\sourceDir" },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll serve --source ""c:/sourceDir""");
    }

    [Fact]
    public void Should_Add_Destination_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { Destination = @"c:\destinationDir" },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll serve --destination ""c:/destinationDir""");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --future")]
    [Theory]
    public void Should_Add_Future_To_Arguments_If_Not_Null(bool? future, string expected)
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { Future = future },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll serve{expected}");
    }

    [InlineData(null, null)]
    [InlineData(5, " --limit_posts 5")]
    [Theory]
    public void Should_Add_LimitPosts_To_Arguments_If_Not_Null(int? limitPosts, string expected)
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { LimitPosts = limitPosts },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll serve{expected}");
    }

    [InlineData(null, null)]
    [InlineData(false, " --no-watch")]
    [InlineData(true, " --watch")]
    [Theory]
    public void Should_Add_Watch_To_Arguments_If_Not_Null(bool? regeneration, string expected)
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { Watch = regeneration },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll serve{expected}");
    }

    [Fact]
    public void Should_Add_BaseUrl_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { BaseUrl = @"http://localhost:8042" },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll serve --baseurl ""http://localhost:8042""");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --force_polling")]
    [Theory]
    public void Should_Add_ForcePolling_To_Arguments_If_Not_Null(bool? forcePolling, string expected)
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { ForcePolling = forcePolling },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll serve{expected}");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --lsi")]
    [Theory]
    public void Should_Add_Lsi_To_Arguments_If_Not_Null(bool? lsi, string expected)
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { Lsi = lsi },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll serve{expected}");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --drafts")]
    [Theory]
    public void Should_Add_Drafts_To_Arguments_If_Not_Null(bool? drafts, string expected)
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { Drafts = drafts },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll serve{expected}");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --unpublished")]
    [Theory]
    public void Should_Add_Unpublished_To_Arguments_If_Not_Null(bool? unpublished, string expected)
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { Unpublished = unpublished },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll serve{expected}");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --disable-disk-cache")]
    [Theory]
    public void Should_Add_DisableDiskCache_To_Arguments_If_Not_Null(bool? disableDiskCache, string expected)
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { DisableDiskCache = disableDiskCache },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll serve{expected}");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --incremental")]
    [Theory]
    public void Should_Add_IncrementalBuild_To_Arguments_If_Not_Null(bool? incrementalBuild, string expected)
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { IncrementalBuild = incrementalBuild },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll serve{expected}");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --strict_front_matter")]
    [Theory]
    public void Should_Add_StrictFrontMatter_To_Arguments_If_Not_Null(bool? strictFrontMatter, string expected)
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { StrictFrontMatter = strictFrontMatter },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll serve{expected}");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --safe")]
    [Theory]
    public void Should_Add_Safe_To_Arguments_If_Not_Null(bool? safeMode, string expected)
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { SafeMode = safeMode },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll serve{expected}");
    }

    [Fact]
    public void Should_Add_Single_Plugin_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { Plugins = @"c:\pluginDir\" },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll serve --plugins ""c:/pluginDir""");
    }

    [Fact]
    public void Should_Add_Multiple_Plugin_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { Plugins = new [] { @"c:\pluginDir1", @"c:\pluginDir2" } },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll serve --plugins ""c:/pluginDir1"" ""c:/pluginDir2""");
    }

    [Fact]
    public void Should_Add_Layouts_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { Layouts = @"c:\layoutsDir" },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll serve --layouts ""c:/layoutsDir""");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --profile")]
    [Theory]
    public void Should_Add_LiquidProfile_To_Arguments_If_Not_Null(bool? liquidProfile, string expected)
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { LiquidProfile = liquidProfile },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll serve{expected}");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --trace")]
    [Theory]
    public void Should_Add_Trace_To_Arguments_If_Not_Null(bool? trace, string expected)
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { Trace = trace },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll serve{expected}");
    }

    [MemberData(nameof(JekyllLogLevels))]
    [Theory]
    public void Should_Add_LogLevel_To_Arguments_If_Not_Null(JekyllLogLevel? logLevel, string expected)
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { LogLevel = logLevel },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll serve{expected}");
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

    [Fact]
    public void Should_Add_SslCertificate_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { SslCertificate = @"c:\localhost.crt" },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll serve --ssl-cert ""c:/localhost.crt""");
    }

    [Fact]
    public void Should_Add_SslKey_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { SslKey = @"c:\localhost.key" },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll serve --ssl-key ""c:/localhost.key""");
    }

    [Fact]
    public void Should_Add_Hostname_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { Hostname = "MACHINENAME" },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll serve --host ""MACHINENAME""");
    }

    [Fact]
    public void Should_Add_Port_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { Port = 8042 },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll serve --port 8042");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --open-url")]
    [Theory]
    public void Should_Add_OpenUrl_To_Arguments_If_Not_Null(bool? openUrl, string expected)
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { OpenUrl = openUrl },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll serve{expected}");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --detach")]
    [Theory]
    public void Should_Add_Detach_To_Arguments_If_Not_Null(bool? detach, string expected)
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { Detach = detach },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll serve{expected}");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --show-dir-listing")]
    [Theory]
    public void Should_Add_ShowDirListing_To_Arguments_If_Not_Null(bool? showDirListing, string expected)
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { ShowDirListing = showDirListing },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll serve{expected}");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --skip-initial-build")]
    [Theory]
    public void Should_Add_SkipInitialBuild_To_Arguments_If_Not_Null(bool? skipInitialBuild, string expected)
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { SkipInitialBuild = skipInitialBuild },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll serve{expected}");
    }

    [InlineData(null, null)]
    [InlineData(false, null)]
    [InlineData(true, " --livereload")]
    [Theory]
    public void Should_Add_LiveReload_To_Arguments_If_Not_Null(bool? liveReload, string expected)
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { LiveReload = liveReload },
        };

        var result = fixture.Run();

        result.Args.Should().Be($"exec jekyll serve{expected}");
    }

    [Fact]
    public void Should_Add_Single_LiveReloadIgnore_Glob_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { LiveReloadIgnore = "*.cake" },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll serve --livereload-ignore ""*.cake""");
    }

    [Fact]
    public void Should_Add_Multiple_LiveReloadIgnore_Glob_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { LiveReloadIgnore = new [] { "*.cake", "*.cs" } },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll serve --livereload-ignore ""*.cake"" ""*.cs""");
    }

    [Fact]
    public void Should_Add_LiveReloadMinDelay_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { LiveReloadMinDelay = TimeSpan.FromSeconds(42) },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll serve --livereload-min-delay 42");
    }

    [Fact]
    public void Should_Add_LiveReloadMaxDelay_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { LiveReloadMaxDelay = TimeSpan.FromSeconds(42) },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll serve --livereload-max-delay 42");
    }

    [Fact]
    public void Should_Add_LiveReloadPort_To_Arguments_If_Not_Null()
    {
        var fixture = new JekyllServeCommandFixture
        {
            Settings = { LiveReloadPort = 8043 },
        };

        var result = fixture.Run();

        result.Args.Should().Be(@"exec jekyll serve --livereload-port 8043");
    }
}
