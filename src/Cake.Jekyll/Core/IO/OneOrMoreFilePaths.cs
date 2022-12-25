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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cake.Core.IO;

namespace Cake.Jekyll.Core.IO;

/// <summary>
/// Represents one or more <see cref="FilePath"/>
/// </summary>
public class OneOrMoreFilePaths : IEnumerable<FilePath>
{
    private readonly List<FilePath> _filePaths = new List<FilePath>();

    /// <summary>
    /// Create an instance of <see cref="OneOrMoreFilePaths"/>
    /// </summary>
    /// <param name="filePath">The file path</param>
    public OneOrMoreFilePaths(FilePath filePath)
    {
        _filePaths.Add(filePath);
    }

    /// <summary>
    /// Create an instance of <see cref="OneOrMoreFilePaths"/>
    /// </summary>
    /// <param name="filePaths"></param>
    public OneOrMoreFilePaths(IEnumerable<FilePath> filePaths)
    {
        _filePaths.AddRange(filePaths.ToList());
    }

    /// <summary>
    /// Gets the number of file paths contained in the <see cref="OneOrMoreFilePaths"/>.</summary>
    /// <returns>The number of file paths contained in the <see cref="OneOrMoreFilePaths"/>.</returns>
    public int Count => _filePaths.Count;

    /// <summary>
    /// Gets the file path at the specified index.</summary>
    /// <param name="index">The zero-based index of the file path to get or set.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// <paramref name="index" /> is less than 0.
    /// 
    /// -or-
    /// 
    /// <paramref name="index" /> is equal to or greater than <see cref="Count" />.</exception>
    /// <returns>The element at the specified index.</returns>
    public FilePath this[int index] => _filePaths[index];

    /// <summary>
    /// Implicitly convert a <see cref="string"/> to <see cref="OneOrMoreFilePaths"/> using <see cref="FilePath"/>
    /// </summary>
    /// <param name="filePath">The file path</param>
    public static implicit operator OneOrMoreFilePaths(string filePath)
    {
        return new OneOrMoreFilePaths(new FilePath(filePath));
    }

    /// <summary>
    /// Implicitly convert an array of <see cref="string"/> to <see cref="OneOrMoreFilePaths"/> using <see cref="FilePath"/>
    /// </summary>
    /// <param name="filePaths">The array of file paths</param>
    public static implicit operator OneOrMoreFilePaths(string[] filePaths)
    {
        return new OneOrMoreFilePaths(filePaths.Select(FilePath.FromString));
    }

    /// <summary>
    /// Implicitly convert a list of <see cref="string"/> to a <see cref="OneOrMoreFilePaths"/> using <see cref="FilePath"/>
    /// </summary>
    /// <param name="filePaths">The list of file paths</param>
    public static implicit operator OneOrMoreFilePaths(List<string> filePaths)
    {
        return new OneOrMoreFilePaths(filePaths.Select(FilePath.FromString));
    }

    /// <summary>
    /// Implicitly convert a <see cref="FilePath"/> to <see cref="OneOrMoreFilePaths"/>
    /// </summary>
    /// <param name="filePath">The file path</param>
    public static implicit operator OneOrMoreFilePaths(FilePath filePath)
    {
        return new OneOrMoreFilePaths(filePath);
    }

    /// <summary>
    /// Implicitly convert a array of <see cref="FilePath"/> to <see cref="OneOrMoreFilePaths"/> using <see cref="FilePath"/>
    /// </summary>
    /// <param name="filePaths">The array of file paths</param>
    public static implicit operator OneOrMoreFilePaths(FilePath[] filePaths)
    {
        return new OneOrMoreFilePaths(filePaths);
    }

    /// <summary>
    /// Implicitly convert a list of <see cref="FilePath"/> to a <see cref="OneOrMoreFilePaths"/> using <see cref="FilePath"/>
    /// </summary>
    /// <param name="filePaths">The list of file paths</param>
    public static implicit operator OneOrMoreFilePaths(List<FilePath> filePaths)
    {
        return new OneOrMoreFilePaths(filePaths);
    }

    /// <summary>
    /// Return an enumerator that iterates through a list of <see cref="FilePath"/>.
    /// </summary>
    /// <returns>An enumerator of <see cref="FilePath"/></returns>
    public IEnumerator<FilePath> GetEnumerator()
    {
        return _filePaths.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
