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

using Cake.Jekyll.Commands.Doctor;
using FluentAssertions;
using Xunit;

namespace Cake.Jekyll.Tests.Commands.Doctor;

public class JekyllDoctorSettingsExtensionsTests
{
    [Fact]
    public void SetWorkingDirectory_Should_Set_WorkingDirectory()
    {
        var settings = new JekyllDoctorSettings();

        settings.SetWorkingDirectory(@"c:\workingDir");

        settings.WorkingDirectory.Should().NotBeNull();
        settings.WorkingDirectory.FullPath.Should().Be("c:/workingDir");
    }

    [Fact]
    public void DoNotUseBundler_Should_Set_DoNotUseBundler()
    {
        var settings = new JekyllDoctorSettings();

        settings.DoNotUseBundler();

        settings.DoNotUseBundler.Should().BeTrue();
    }

    [Fact]
    public void WithConfiguration_Should_Set_Configuration()
    {
        var settings = new JekyllDoctorSettings();

        settings.WithConfiguration(@"c:\_config.yml");

        settings.Configuration.Should().NotBeNull();
        settings.Configuration.Count.Should().Be(1);
        settings.Configuration[0].FullPath.Should().Be("c:/_config.yml");
    }

    [Fact]
    public void SetSource_Should_Set_Source()
    {
        var settings = new JekyllDoctorSettings();

        settings.SetSource(@"c:\sourceDir");

        settings.Source.Should().NotBeNull();
        settings.Source.FullPath.Should().Be("c:/sourceDir");
    }

    [Fact]
    public void SetDestination_Should_Set_Destination()
    {
        var settings = new JekyllDoctorSettings();

        settings.SetDestination(@"c:\destinationDir");

        settings.Destination.Should().NotBeNull();
        settings.Destination.FullPath.Should().Be("c:/destinationDir");
    }

    [Fact]
    public void Safe_Should_Set_SafeMode()
    {
        var settings = new JekyllDoctorSettings();

        settings.EnableSafeMode();

        settings.SafeMode.Should().BeTrue();
    }

    [Fact]
    public void WithPlugins_Should_Set_Plugins()
    {
        var settings = new JekyllDoctorSettings();

        settings.WithPlugins(@"c:\pluginDir\");

        settings.Plugins.Should().NotBeNull();
        settings.Plugins.Count.Should().Be(1);
        settings.Plugins[0].FullPath.Should().Be("c:/pluginDir");
    }

    [Fact]
    public void SetLayouts_Should_Set_Layouts()
    {
        var settings = new JekyllDoctorSettings();

        settings.SetLayouts(@"c:\layoutsDir");

        settings.Layouts.Should().NotBeNull();
        settings.Layouts.FullPath.Should().Be("c:/layoutsDir");
    }

    [Fact]
    public void EnableLiquidProfile_Should_Set_LiquidProfile()
    {
        var settings = new JekyllDoctorSettings();

        settings.EnableLiquidProfile();

        settings.LiquidProfile.Should().BeTrue();
    }

    [Fact]
    public void EnableTrace_Should_Set_Trace()
    {
        var settings = new JekyllDoctorSettings();

        settings.EnableTrace();

        settings.Trace.Should().BeTrue();
    }
}
