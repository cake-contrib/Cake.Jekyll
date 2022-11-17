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

using System.Collections.Generic;
using Cake.Jekyll.Core;
using FluentAssertions;
using Xunit;

namespace Cake.Jekyll.Tests.Core
{
    public class OneOrMoreStringsTests
    {
        [Fact]
        public void OneOrMoreFilePath_has_implicit_conversion_from_string()
        {
            OneOrMoreStrings target = "Hello";

            target.Should().NotBeNull();
            target.Count.Should().Be(1);
            target[0].Should().Be("Hello");
        }

        [Fact]
        public void OneOrMoreFilePath_has_implicit_conversion_from_string_array()
        {
            OneOrMoreStrings target = new [] { "Hello1", "Hello2" };

            target.Should().NotBeNull();
            target.Count.Should().Be(2);
            target[0].Should().Be("Hello1");
            target[1].Should().Be("Hello2");
        }

        [Fact]
        public void OneOrMoreFilePath_has_implicit_conversion_from_List_of_String()
        {
            OneOrMoreStrings target = new List<string> { "Hello1", "Hello2" };

            target.Should().NotBeNull();
            target.Count.Should().Be(2);
            target[0].Should().Be("Hello1");
            target[1].Should().Be("Hello2");
        }
    }
}
