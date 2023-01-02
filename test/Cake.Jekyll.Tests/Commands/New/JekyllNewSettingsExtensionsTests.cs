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

using Cake.Jekyll.Commands.New;
using FluentAssertions;
using Xunit;

namespace Cake.Jekyll.Tests.Commands.New;

public class JekyllNewSettingsExtensionsTests
{
    [Fact]
    public void SetWorkingDirectory_Should_Set_WorkingDirectory()
    {
        var settings = new JekyllNewSettings();

        settings.SetWorkingDirectory(@"c:\workingDir");

        settings.WorkingDirectory.Should().NotBeNull();
        settings.WorkingDirectory.FullPath.Should().Be("c:/workingDir");
    }

    [Fact]
    public void DoNotUseBundler_Should_Set_DoNotUseBundler()
    {
        var settings = new JekyllNewSettings();

        settings.DoNotUseBundler();

        settings.DoNotUseBundler.Should().BeTrue();
    }

    [Fact]
    public void EnableForce_Should_Set_Force()
    {
        var settings = new JekyllNewSettings();

        settings.EnableForce();

        settings.Force.Should().BeTrue();
    }

    [Fact]
    public void EnableBlank_Should_Set_Blank()
    {
        var settings = new JekyllNewSettings();

        settings.EnableBlank();

        settings.Blank.Should().BeTrue();
    }

    [Fact]
    public void SkipBundle_Should_Set_SkipBundle()
    {
        var settings = new JekyllNewSettings();

        settings.SkipBundle();

        settings.SkipBundle.Should().BeTrue();
    }

    [Fact]
    public void SetSource_Should_Set_Source()
    {
        var settings = new JekyllNewSettings();

        settings.SetSource(@"c:\sourceDir");

        settings.Source.Should().NotBeNull();
        settings.Source.FullPath.Should().Be("c:/sourceDir");
    }

    [Fact]
    public void SetDestination_Should_Set_Destination()
    {
        var settings = new JekyllNewSettings();

        settings.SetDestination(@"c:\destinationDir");

        settings.Destination.Should().NotBeNull();
        settings.Destination.FullPath.Should().Be("c:/destinationDir");
    }

    [Fact]
    public void EnableSafeMode_Should_Set_SafeMode()
    {
        var settings = new JekyllNewSettings();

        settings.EnableSafeMode();

        settings.SafeMode.Should().BeTrue();
    }

    [Fact]
    public void WithPlugins_Should_Set_Plugins()
    {
        var settings = new JekyllNewSettings();

        settings.WithPlugins(@"c:\pluginDir\");

        settings.Plugins.Should().NotBeNull();
        settings.Plugins.Count.Should().Be(1);
        settings.Plugins[0].FullPath.Should().Be("c:/pluginDir");
    }

    [Fact]
    public void SetLayouts_Should_Set_Layouts()
    {
        var settings = new JekyllNewSettings();

        settings.SetLayouts(@"c:\layoutsDir");

        settings.Layouts.Should().NotBeNull();
        settings.Layouts.FullPath.Should().Be("c:/layoutsDir");
    }

    [Fact]
    public void EnableLiquidProfile_Should_Set_LiquidProfile()
    {
        var settings = new JekyllNewSettings();

        settings.EnableLiquidProfile();

        settings.LiquidProfile.Should().BeTrue();
    }

    [Fact]
    public void EnableTrace_Should_Set_Trace()
    {
        var settings = new JekyllNewSettings();

        settings.EnableTrace();

        settings.Trace.Should().BeTrue();
    }
}
