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

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cake.Jekyll.Core
{
    /// <summary>
    /// Represents one or more <see cref="string"/>
    /// </summary>
    public class OneOrMoreStrings : IEnumerable<string>
    {
        private readonly List<string> _values = new List<string>();

        /// <summary>
        /// Create an instance of <see cref="OneOrMoreStrings"/>
        /// </summary>
        /// <param name="value">The file path</param>
        public OneOrMoreStrings(string value)
        {
            _values.Add(value);
        }

        /// <summary>
        /// Create an instance of <see cref="OneOrMoreStrings"/>
        /// </summary>
        /// <param name="values"></param>
        public OneOrMoreStrings(IEnumerable<string> values)
        {
            _values.AddRange(values.ToList());
        }

        /// <summary>
        /// Gets the number of string values contained in the <see cref="OneOrMoreStrings"/>.</summary>
        /// <returns>The number of string values contained in the <see cref="OneOrMoreStrings"/>.</returns>
        public int Count => _values.Count;

        /// <summary>
        /// Gets the string value at the specified index.</summary>
        /// <param name="index">The zero-based index of the file path to get or set.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="index" /> is less than 0.
        /// 
        /// -or-
        /// 
        /// <paramref name="index" /> is equal to or greater than <see cref="Count" />.</exception>
        /// <returns>The element at the specified index.</returns>
        public string this[int index] => _values[index];

        /// <summary>
        /// Implicitly convert a <see cref="string"/> to <see cref="OneOrMoreStrings"/>
        /// </summary>
        /// <param name="value">The string value</param>
        public static implicit operator OneOrMoreStrings(string value)
        {
            return new OneOrMoreStrings(value);
        }

        /// <summary>
        /// Implicitly convert an array of <see cref="string"/> to <see cref="OneOrMoreStrings"/>
        /// </summary>
        /// <param name="values">The array of string values</param>
        public static implicit operator OneOrMoreStrings(string[] values)
        {
            return new OneOrMoreStrings(values);
        }

        /// <summary>
        /// Implicitly convert a list of <see cref="string"/> to a <see cref="OneOrMoreStrings"/>
        /// </summary>
        /// <param name="values">The list of file paths</param>
        public static implicit operator OneOrMoreStrings(List<string> values)
        {
            return new OneOrMoreStrings(values);
        }

        /// <summary>
        /// Return an enumerator that iterates through a list of <see cref="string"/>.
        /// </summary>
        /// <returns>An enumerator of <see cref="string"/></returns>
        public IEnumerator<string> GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
