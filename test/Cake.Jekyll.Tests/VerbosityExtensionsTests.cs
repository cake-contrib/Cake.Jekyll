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
using Cake.Core.Diagnostics;
using FluentAssertions;
using Xunit;

namespace Cake.Jekyll.Tests;

public class VerbosityExtensionsTests
{
    [MemberData(nameof(VerbosityValues))]
    [Theory]
    public void ToJekyllLogLevel_should_convert_to_Verbosity(Verbosity verbosity, JekyllLogLevel expected)
    {
        var result = verbosity.ToJekyllLogLevel();
        result.Should().Be(expected);
    }

    [MemberData(nameof(NullableVerbosityValues))]
    [Theory]
    public void ToJekyllLogLevel_should_convert_Nullable_Verbosity(Verbosity? verbosity, JekyllLogLevel expected)
    {
        var result = verbosity.ToJekyllLogLevel();
        result.Should().Be(expected);
    }

    public static IEnumerable<object[]> VerbosityValues
    {
        get
        {
            var logLevelsMap = Enum.GetValues(typeof(Verbosity))
                .Cast<Verbosity>()
                .ToDictionary(v => v, _ => JekyllLogLevel.Default);

            logLevelsMap[Verbosity.Quiet] = JekyllLogLevel.Quiet;
            logLevelsMap[Verbosity.Verbose] = JekyllLogLevel.Verbose;
            logLevelsMap[Verbosity.Diagnostic] = JekyllLogLevel.Verbose;

            return logLevelsMap
                .Select(kvp => new object[] { kvp.Key, kvp.Value });
        }
    }

    public static IEnumerable<object[]> NullableVerbosityValues
    {
        get
        {
            var logLevelsMap = Enum.GetValues(typeof(Verbosity))
                .Cast<Verbosity?>()
                .ToDictionary(v => v, _ => JekyllLogLevel.Default);

            logLevelsMap[Verbosity.Quiet] = JekyllLogLevel.Quiet;
            logLevelsMap[Verbosity.Verbose] = JekyllLogLevel.Verbose;
            logLevelsMap[Verbosity.Diagnostic] = JekyllLogLevel.Verbose;

            return logLevelsMap
                .Select(kvp => new object[] { kvp.Key, kvp.Value })
                .Concat(new [] { new object[] { null, JekyllLogLevel.Default } });
        }
    }
}
