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
using Cake.Jekyll.Commands.Serve;
using FluentAssertions;
using Xunit;

namespace Cake.Jekyll.Tests.Commands.Serve;

public class JekyllServeSettingsExtensionsTests
{
    [Fact]
    public void SetWorkingDirectory_Should_Set_WorkingDirectory()
    {
        var settings = new JekyllServeSettings();

        settings.SetWorkingDirectory(@"c:\workingDir");

        settings.WorkingDirectory.Should().NotBeNull();
        settings.WorkingDirectory.FullPath.Should().Be("c:/workingDir");
    }

    [Fact]
    public void DoNotUseBundler_Should_Set_DoNotUseBundler()
    {
        var settings = new JekyllServeSettings();

        settings.DoNotUseBundler();

        settings.DoNotUseBundler.Should().BeTrue();
    }

    [Fact]
    public void WithConfiguration_Should_Set_Configuration()
    {
        var settings = new JekyllServeSettings();

        settings.WithConfiguration(@"c:\_config.yml");

        settings.Configuration.Should().NotBeNull();
        settings.Configuration.Count.Should().Be(1);
        settings.Configuration[0].FullPath.Should().Be("c:/_config.yml");
    }

    [Fact]
    public void SetSource_Should_Set_Source()
    {
        var settings = new JekyllServeSettings();

        settings.SetSource(@"c:\sourceDir");

        settings.Source.Should().NotBeNull();
        settings.Source.FullPath.Should().Be("c:/sourceDir");
    }

    [Fact]
    public void SetDestination_Should_Set_Destination()
    {
        var settings = new JekyllServeSettings();

        settings.SetDestination(@"c:\destinationDir");

        settings.Destination.Should().NotBeNull();
        settings.Destination.FullPath.Should().Be("c:/destinationDir");
    }

    [Fact]
    public void PublishFuture_Should_Set_Future()
    {
        var settings = new JekyllServeSettings();

        settings.PublishFuture();

        settings.Future.Should().BeTrue();
    }

    [Fact]
    public void LimitPosts_Should_Set_LimitPosts()
    {
        var settings = new JekyllServeSettings();

        settings.LimitPosts(42);

        settings.LimitPosts.Should().Be(42);
    }

    [Fact]
    public void EnableWatch_Should_Set_Watch()
    {
        var settings = new JekyllServeSettings();

        settings.EnableWatch();

        settings.Watch.Should().BeTrue();
    }

    [Fact]
    public void SetBaseUrl_Should_Set_BaseUrl()
    {
        var settings = new JekyllServeSettings();

        settings.SetBaseUrl("http://localhost:8042");

        settings.BaseUrl.Should().Be("http://localhost:8042");
    }

    [Fact]
    public void ForcePolling_Should_Set_ForcePolling()
    {
        var settings = new JekyllServeSettings();

        settings.ForcePolling();

        settings.ForcePolling.Should().BeTrue();
    }

    [Fact]
    public void Use_Should_Set_Lsi()
    {
        var settings = new JekyllServeSettings();

        settings.UseLsi();

        settings.Lsi.Should().BeTrue();
    }

    [Fact]
    public void RenderDrafts_Should_Set_Drafts()
    {
        var settings = new JekyllServeSettings();

        settings.RenderDrafts();

        settings.Drafts.Should().BeTrue();
    }

    [Fact]
    public void RenderUnpublished_Should_Set_Unpublished()
    {
        var settings = new JekyllServeSettings();

        settings.RenderUnpublished();

        settings.Unpublished.Should().BeTrue();
    }

    [Fact]
    public void DisableDiskCache_Should_Set_DisableDiskCache()
    {
        var settings = new JekyllServeSettings();

        settings.DisableDiskCache();

        settings.DisableDiskCache.Should().BeTrue();
    }

    [Fact]
    public void EnableIncrementalBuild_Should_Set_IncrementalBuild()
    {
        var settings = new JekyllServeSettings();

        settings.EnableIncrementalBuild();

        settings.IncrementalBuild.Should().BeTrue();
    }

    [Fact]
    public void UseStrictFrontMatter_Should_Set_StrictFrontMatter()
    {
        var settings = new JekyllServeSettings();

        settings.UseStrictFrontMatter();

        settings.StrictFrontMatter.Should().BeTrue();
    }

    [Fact]
    public void Safe_Should_Set_SafeMode()
    {
        var settings = new JekyllServeSettings();

        settings.EnableSafeMode();

        settings.SafeMode.Should().BeTrue();
    }

    [Fact]
    public void WithPlugins_Should_Set_Plugins()
    {
        var settings = new JekyllServeSettings();

        settings.WithPlugins(@"c:\pluginDir\");

        settings.Plugins.Should().NotBeNull();
        settings.Plugins.Count.Should().Be(1);
        settings.Plugins[0].FullPath.Should().Be("c:/pluginDir");
    }

    [Fact]
    public void SetLayouts_Should_Set_Layouts()
    {
        var settings = new JekyllServeSettings();

        settings.SetLayouts(@"c:\layoutsDir");

        settings.Layouts.Should().NotBeNull();
        settings.Layouts.FullPath.Should().Be("c:/layoutsDir");
    }

    [Fact]
    public void EnableLiquidProfile_Should_Set_LiquidProfile()
    {
        var settings = new JekyllServeSettings();

        settings.EnableLiquidProfile();

        settings.LiquidProfile.Should().BeTrue();
    }

    [Fact]
    public void EnableTrace_Should_Set_Trace()
    {
        var settings = new JekyllServeSettings();

        settings.EnableTrace();

        settings.Trace.Should().BeTrue();
    }

    [MemberData(nameof(JekyllLogLevels))]
    [Theory]
    public void SetLogLevel_Should_Set_LogLevel(JekyllLogLevel? logLevel)
    {
        var settings = new JekyllServeSettings();

        settings.SetLogLevel(logLevel);

        settings.LogLevel.Should().Be(logLevel);
    }

    public static IEnumerable<object[]> JekyllLogLevels
    {
        get
        {
            var logLevelsMap = Enum.GetValues(typeof(JekyllLogLevel))
                .Cast<JekyllLogLevel?>()
                .ToList();

            return logLevelsMap
                .Select(v => new object[] { v })
                .Concat(new [] { new object[] { null } });
        }
    }

    [Fact]
    public void UseSslCertificate_Should_Set_SslCertificate()
    {
        var settings = new JekyllServeSettings();

        settings.UseSslCertificate(@"c:\localhost.crt");

        settings.SslCertificate.Should().NotBeNull();
        settings.SslCertificate.FullPath.Should().Be("c:/localhost.crt");
    }

    [Fact]
    public void UseSslKey_Should_Set_SslKey()
    {
        var settings = new JekyllServeSettings();

        settings.UseSslKey(@"c:\localhost.key");

        settings.SslKey.Should().NotBeNull();
        settings.SslKey.FullPath.Should().Be("c:/localhost.key");
    }

    [Fact]
    public void SetHostname_Should_Set_Hostname()
    {
        var settings = new JekyllServeSettings();

        settings.SetHostname("MACHINENAME");

        settings.Hostname.Should().Be("MACHINENAME");
    }

    [Fact]
    public void SetPort_Should_Set_Port()
    {
        var settings = new JekyllServeSettings();

        settings.SetPort(8042);

        settings.Port.Should().Be(8042);
    }

    [Fact]
    public void OpenUrl_Should_Set_OpenUrl()
    {
        var settings = new JekyllServeSettings();

        settings.OpenUrl();

        settings.OpenUrl.Should().BeTrue();
    }

    [Fact]
    public void Detach_Should_Set_Detach()
    {
        var settings = new JekyllServeSettings();

        settings.Detach();

        settings.Detach.Should().BeTrue();
    }

    [Fact]
    public void ShowDirListing_Should_Set_ShowDirListing()
    {
        var settings = new JekyllServeSettings();

        settings.ShowDirListing();

        settings.ShowDirListing.Should().BeTrue();
    }

    [Fact]
    public void SkipInitialBuild_Should_Set_SkipInitialBuild()
    {
        var settings = new JekyllServeSettings();

        settings.SkipInitialBuild();

        settings.SkipInitialBuild.Should().BeTrue();
    }

    [Fact]
    public void UseLiveReload_Should_Set_LiveReload()
    {
        var settings = new JekyllServeSettings();

        settings.UseLiveReload();

        settings.LiveReload.Should().BeTrue();
    }

    [Fact]
    public void WithLiveReloadIgnore_Should_Set_Configuration()
    {
        var settings = new JekyllServeSettings();

        settings.WithLiveReloadIgnore("*.cake");

        settings.LiveReloadIgnore.Should().NotBeNull();
        settings.LiveReloadIgnore.Count.Should().Be(1);
        settings.LiveReloadIgnore[0].Should().Be("*.cake");
    }

    [Fact]
    public void SetLiveReloadMinDelay_Should_Set_LiveReloadMinDelay()
    {
        var settings = new JekyllServeSettings();

        settings.SetLiveReloadMinDelay(TimeSpan.FromSeconds(42));

        settings.LiveReloadMinDelay.Should().Be(TimeSpan.FromSeconds(42));
    }

    [Fact]
    public void SetLiveReloadMaxDelay_Should_Set_LiveReloadMaxDelay()
    {
        var settings = new JekyllServeSettings();

        settings.SetLiveReloadMaxDelay(TimeSpan.FromSeconds(42));

        settings.LiveReloadMaxDelay.Should().Be(TimeSpan.FromSeconds(42));
    }

    [Fact]
    public void SetLiveReloadPort_Should_Set_LiveReloadPort()
    {
        var settings = new JekyllServeSettings();

        settings.SetLiveReloadPort(8042);

        settings.LiveReloadPort.Should().Be(8042);
    }
}
