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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cake.Core.IO;

namespace Cake.Jekyll.Core.IO;

/// <summary>
/// Represents one or more <see cref="DirectoryPath"/>
/// </summary>
public class OneOrMoreDirectoryPaths : IEnumerable<DirectoryPath>
{
    private readonly List<DirectoryPath> _directoryPaths = new List<DirectoryPath>();

    /// <summary>
    /// Create an instance of <see cref="OneOrMoreDirectoryPaths"/>
    /// </summary>
    /// <param name="directoryPath">The file path</param>
    public OneOrMoreDirectoryPaths(DirectoryPath directoryPath)
    {
        _directoryPaths.Add(directoryPath);
    }

    /// <summary>
    /// Create an instance of <see cref="OneOrMoreDirectoryPaths"/>
    /// </summary>
    /// <param name="directoryPaths"></param>
    public OneOrMoreDirectoryPaths(IEnumerable<DirectoryPath> directoryPaths)
    {
        _directoryPaths.AddRange(directoryPaths.ToList());
    }

    /// <summary>
    /// Gets the number of file paths contained in the <see cref="OneOrMoreDirectoryPaths"/>.</summary>
    /// <returns>The number of file paths contained in the <see cref="OneOrMoreDirectoryPaths"/>.</returns>
    public int Count => _directoryPaths.Count;

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
    public DirectoryPath this[int index] => _directoryPaths[index];

    /// <summary>
    /// Implicitly convert a <see cref="string"/> to <see cref="OneOrMoreDirectoryPaths"/> using <see cref="DirectoryPath"/>
    /// </summary>
    /// <param name="directoryPath">The file path</param>
    public static implicit operator OneOrMoreDirectoryPaths(string directoryPath)
    {
        return new OneOrMoreDirectoryPaths(new DirectoryPath(directoryPath));
    }

    /// <summary>
    /// Implicitly convert an array of <see cref="string"/> to <see cref="OneOrMoreDirectoryPaths"/> using <see cref="DirectoryPath"/>
    /// </summary>
    /// <param name="directoryPaths">The array of file paths</param>
    public static implicit operator OneOrMoreDirectoryPaths(string[] directoryPaths)
    {
        return new OneOrMoreDirectoryPaths(directoryPaths.Select(DirectoryPath.FromString));
    }

    /// <summary>
    /// Implicitly convert a list of <see cref="string"/> to a <see cref="OneOrMoreDirectoryPaths"/> using <see cref="DirectoryPath"/>
    /// </summary>
    /// <param name="directoryPaths">The list of file paths</param>
    public static implicit operator OneOrMoreDirectoryPaths(List<string> directoryPaths)
    {
        return new OneOrMoreDirectoryPaths(directoryPaths.Select(DirectoryPath.FromString));
    }

    /// <summary>
    /// Implicitly convert a <see cref="DirectoryPath"/> to <see cref="OneOrMoreDirectoryPaths"/>
    /// </summary>
    /// <param name="directoryPath">The file path</param>
    public static implicit operator OneOrMoreDirectoryPaths(DirectoryPath directoryPath)
    {
        return new OneOrMoreDirectoryPaths(directoryPath);
    }

    /// <summary>
    /// Implicitly convert a array of <see cref="DirectoryPath"/> to <see cref="OneOrMoreDirectoryPaths"/> using <see cref="DirectoryPath"/>
    /// </summary>
    /// <param name="directoryPaths">The array of file paths</param>
    public static implicit operator OneOrMoreDirectoryPaths(DirectoryPath[] directoryPaths)
    {
        return new OneOrMoreDirectoryPaths(directoryPaths);
    }

    /// <summary>
    /// Implicitly convert a list of <see cref="DirectoryPath"/> to a <see cref="OneOrMoreDirectoryPaths"/> using <see cref="DirectoryPath"/>
    /// </summary>
    /// <param name="directoryPaths">The list of file paths</param>
    public static implicit operator OneOrMoreDirectoryPaths(List<DirectoryPath> directoryPaths)
    {
        return new OneOrMoreDirectoryPaths(directoryPaths);
    }

    /// <summary>
    /// Return an enumerator that iterates through a list of <see cref="DirectoryPath"/>.
    /// </summary>
    /// <returns>An enumerator of <see cref="DirectoryPath"/></returns>
    public IEnumerator<DirectoryPath> GetEnumerator()
    {
        return _directoryPaths.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
