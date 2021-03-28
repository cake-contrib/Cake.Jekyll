#region Copyright 2021 C. Augusto Proiete & Contributors
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
using Cake.Jekyll.Commands.Build;
using FluentAssertions;
using Xunit;

namespace Cake.Jekyll.Tests.Commands.Build
{
    public class JekyllBuildSettingsExtensionsTests
    {
        [Fact]
        public void SetWorkingDirectory_Should_Set_WorkingDirectory()
        {
            var settings = new JekyllBuildSettings();

            settings.SetWorkingDirectory(@"c:\workingDir");

            settings.WorkingDirectory.Should().NotBeNull();
            settings.WorkingDirectory.FullPath.Should().Be("c:/workingDir");
        }

        [Fact]
        public void DoNotUseBundler_Should_Set_DoNotUseBundler()
        {
            var settings = new JekyllBuildSettings();

            settings.DoNotUseBundler();

            settings.DoNotUseBundler.Should().BeTrue();
        }

        [Fact]
        public void WithConfiguration_Should_Set_Configuration()
        {
            var settings = new JekyllBuildSettings();

            settings.WithConfiguration(@"c:\_config.yml");

            settings.Configuration.Should().NotBeNull();
            settings.Configuration.Count.Should().Be(1);
            settings.Configuration[0].FullPath.Should().Be("c:/_config.yml");
        }

        [Fact]
        public void SetSource_Should_Set_Source()
        {
            var settings = new JekyllBuildSettings();

            settings.SetSource(@"c:\sourceDir");

            settings.Source.Should().NotBeNull();
            settings.Source.FullPath.Should().Be("c:/sourceDir");
        }

        [Fact]
        public void SetDestination_Should_Set_Destination()
        {
            var settings = new JekyllBuildSettings();

            settings.SetDestination(@"c:\destinationDir");

            settings.Destination.Should().NotBeNull();
            settings.Destination.FullPath.Should().Be("c:/destinationDir");
        }

        [Fact]
        public void PublishFuture_Should_Set_Future()
        {
            var settings = new JekyllBuildSettings();

            settings.PublishFuture();

            settings.Future.Should().BeTrue();
        }

        [Fact]
        public void LimitPosts_Should_Set_LimitPosts()
        {
            var settings = new JekyllBuildSettings();

            settings.LimitPosts(42);

            settings.LimitPosts.Should().Be(42);
        }

        [Fact]
        public void EnableWatch_Should_Set_Watch()
        {
            var settings = new JekyllBuildSettings();

            settings.EnableWatch();

            settings.Watch.Should().BeTrue();
        }

        [Fact]
        public void SetBaseUrl_Should_Set_BaseUrl()
        {
            var settings = new JekyllBuildSettings();

            settings.SetBaseUrl("http://localhost:8042");

            settings.BaseUrl.Should().Be("http://localhost:8042");
        }

        [Fact]
        public void ForcePolling_Should_Set_ForcePolling()
        {
            var settings = new JekyllBuildSettings();

            settings.ForcePolling();

            settings.ForcePolling.Should().BeTrue();
        }

        [Fact]
        public void Use_Should_Set_Lsi()
        {
            var settings = new JekyllBuildSettings();

            settings.UseLsi();

            settings.Lsi.Should().BeTrue();
        }

        [Fact]
        public void RenderDrafts_Should_Set_Drafts()
        {
            var settings = new JekyllBuildSettings();

            settings.RenderDrafts();

            settings.Drafts.Should().BeTrue();
        }

        [Fact]
        public void RenderUnpublished_Should_Set_Unpublished()
        {
            var settings = new JekyllBuildSettings();

            settings.RenderUnpublished();

            settings.Unpublished.Should().BeTrue();
        }

        [Fact]
        public void DisableDiskCache_Should_Set_DisableDiskCache()
        {
            var settings = new JekyllBuildSettings();

            settings.DisableDiskCache();

            settings.DisableDiskCache.Should().BeTrue();
        }

        [Fact]
        public void EnableIncrementalBuild_Should_Set_IncrementalBuild()
        {
            var settings = new JekyllBuildSettings();

            settings.EnableIncrementalBuild();

            settings.IncrementalBuild.Should().BeTrue();
        }

        [Fact]
        public void UseStrictFrontMatter_Should_Set_StrictFrontMatter()
        {
            var settings = new JekyllBuildSettings();

            settings.UseStrictFrontMatter();

            settings.StrictFrontMatter.Should().BeTrue();
        }

        [Fact]
        public void EnableSafeMode_Should_Set_SafeMode()
        {
            var settings = new JekyllBuildSettings();

            settings.EnableSafeMode();

            settings.SafeMode.Should().BeTrue();
        }

        [Fact]
        public void WithPlugins_Should_Set_Plugins()
        {
            var settings = new JekyllBuildSettings();

            settings.WithPlugins(@"c:\pluginDir\");

            settings.Plugins.Should().NotBeNull();
            settings.Plugins.Count.Should().Be(1);
            settings.Plugins[0].FullPath.Should().Be("c:/pluginDir");
        }

        [Fact]
        public void SetLayouts_Should_Set_Layouts()
        {
            var settings = new JekyllBuildSettings();

            settings.SetLayouts(@"c:\layoutsDir");

            settings.Layouts.Should().NotBeNull();
            settings.Layouts.FullPath.Should().Be("c:/layoutsDir");
        }

        [Fact]
        public void EnableLiquidProfile_Should_Set_LiquidProfile()
        {
            var settings = new JekyllBuildSettings();

            settings.EnableLiquidProfile();

            settings.LiquidProfile.Should().BeTrue();
        }

        [Fact]
        public void EnableTrace_Should_Set_Trace()
        {
            var settings = new JekyllBuildSettings();

            settings.EnableTrace();

            settings.Trace.Should().BeTrue();
        }

        [MemberData(nameof(JekyllLogLevels))]
        [Theory]
        public void SetLogLevel_Should_Set_LogLevel(JekyllLogLevel? logLevel)
        {
            var settings = new JekyllBuildSettings();

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
    }
}
