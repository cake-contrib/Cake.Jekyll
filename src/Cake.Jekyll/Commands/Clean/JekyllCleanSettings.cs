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

using Cake.Core.IO;
using Cake.Jekyll.Core.IO;

namespace Cake.Jekyll.Commands.Clean;

/// <summary>
/// Contains settings used by <see cref="JekyllCleanCommand"/>.
/// </summary>
public class JekyllCleanSettings : JekyllSettings
{
    /// <summary>
    /// Initializes a new instance of the <see cref="JekyllCleanSettings"/> class.
    /// </summary>
    public JekyllCleanSettings()
        : base("clean")
    {
    }

    /// <summary>
    /// Specifies one or more configuration file(s) instead of using `_config.yml` automatically.
    /// Settings in later files override settings in earlier files.
    /// </summary>
    public OneOrMoreFilePaths Configuration { get; set; }

    /// <summary>
    /// Site Source directory, the directory where Jekyll will read files (defaults to `./`).
    /// -s, --source DIR
    /// </summary>
    public DirectoryPath Source { get; set; }

    /// <summary>
    /// Site Destination directory, the directory where Jekyll will write files (defaults to `./_site`).
    /// -d, --destination DIR
    /// 
    /// Important: The contents of <see cref="Destination"/> are automatically cleaned, by default, when the site is built.
    /// Files or folders that are not created by your site will be removed.
    /// Some files could be retained by specifying them within the `keep_files` configuration directive.
    /// Do not use an important location for <see cref="Destination"/>; instead, use it as a staging area and copy files from there to your web server.
    /// </summary>
    public DirectoryPath Destination { get; set; }

    /// <summary>
    /// Publish posts or collection documents with a future date (defaults to <see langword="false"/>).
    /// --future
    /// </summary>
    public bool? Future { get; set; }

    /// <summary>
    /// Limit the number of posts to parse and publish.
    /// --limit_posts NUM
    /// </summary>
    public int? LimitPosts { get; set; }

    /// <summary>
    /// Enable auto-regeneration of the site when files are modified (defaults to <see langword="false"/>).
    /// -w, --[no-]watch
    /// </summary>
    public bool? Watch { get; set; }

    /// <summary>
    /// Serve the website from the given base URL.
    /// -b, --baseurl URL
    /// </summary>
    public string BaseUrl { get; set; }

    /// <summary>
    /// Force watch to use polling (defaults to <see langword="false"/>).
    /// --force_polling
    /// </summary>
    public bool? ForcePolling { get; set; }

    /// <summary>
    /// Produce an index for related posts using latent semantic indexing (LSI) for improved related posts (defaults to <see langword="false"/>).
    /// Requires the classifier-reborn plugin.
    /// --lsi
    /// </summary>
    public bool? Lsi { get; set; }

    /// <summary>
    /// Process and render draft posts in the `_drafts` folder (defaults to <see langword="false"/>).
    /// -D, --drafts
    /// </summary>
    public bool? Drafts { get; set; }

    /// <summary>
    /// Render posts that were marked as unpublished (defaults to <see langword="false"/>).
    /// --unpublished
    /// </summary>
    public bool? Unpublished { get; set; }

    /// <summary>
    /// Disable caching of content to disk in order to skip creating a `.jekyll-cache` or similar
    /// directory at the source to avoid interference with virtual environments and third-party
    /// directory watchers. Caching to disk is always disabled in safe mode (defaults to <see langword="false"/>).
    /// --disable-disk-cache
    /// </summary>
    public bool? DisableDiskCache { get; set; }

    /// <summary>
    /// Enable the experimental incremental build feature. Incremental build only re-builds posts
    /// and pages that have changed, resulting in significant performance improvements for large sites,
    /// but may also break site generation in certain cases (defaults to <see langword="false"/>).
    /// -I, --incremental
    /// </summary>
    public bool? IncrementalBuild { get; set; }

    /// <summary>
    /// Cause a build to fail if there is a YAML syntax error in a page's front matter (defaults to <see langword="false"/>).
    /// --strict_front_matter
    /// </summary>
    public bool? StrictFrontMatter { get; set; }

    /// <summary>
    /// Safe mode (defaults to <see langword="false"/>).
    /// --safe
    /// 
    /// Disable non-whitelisted plugins, caching to disk, and ignore symbolic links.
    /// </summary>
    public bool? SafeMode { get; set; }

    /// <summary>
    /// Specifies plugin directories instead of using `_plugins/` automatically.
    /// -p, --plugins DIR1[,DIR2,...]
    /// </summary>
    public OneOrMoreDirectoryPaths Plugins { get; set; }

    /// <summary>
    /// Specifies layout directory instead of using `_layouts/` automatically.
    /// --layouts DIR
    /// </summary>
    public DirectoryPath Layouts { get; set; }

    /// <summary>
    /// Generate a Liquid rendering profile to help you identify performance bottlenecks (defaults to <see langword="false"/>).
    /// --profile
    /// </summary>
    public bool? LiquidProfile { get; set; }

    /// <summary>
    /// Show the full backtrace when an error occurs.
    /// -t, --trace
    /// </summary>
    public bool? Trace { get; set; }

    /// <summary>
    /// Log level which should be used to run the Jekyll build command.
    /// -V, --verbose
    /// or
    /// -q, --quiet
    /// </summary>
    public JekyllLogLevel? LogLevel { get; set; }

    /// <summary>
    /// Evaluates the settings and writes them to <paramref name="args"/>.
    /// </summary>
    /// <param name="args">The argument builder into which the settings should be written.</param>
    protected override void EvaluateCore(ProcessArgumentBuilder args)
    {
        base.EvaluateCore(args);

        ApplyOption(args, "--config", Configuration);
        ApplyOption(args, "--source", Source?.FullPath);
        ApplyOption(args, "--destination", Destination?.FullPath);
        ApplyOption(args, "--future", Future);
        ApplyOption(args, "--limit_posts", LimitPosts);
        ApplyOption(args, "--watch", Watch);
        ApplyOption(args, "--no-watch", Watch.HasValue && !Watch.Value);
        ApplyOption(args, "--baseurl", BaseUrl);
        ApplyOption(args, "--force_polling", ForcePolling);
        ApplyOption(args, "--lsi", Lsi);
        ApplyOption(args, "--drafts", Drafts);
        ApplyOption(args, "--unpublished", Unpublished);
        ApplyOption(args, "--disable-disk-cache", DisableDiskCache);
        // --quiet is applied via LogLevel
        // --verbose is applied via LogLevel
        ApplyOption(args, "--incremental", IncrementalBuild);
        ApplyOption(args, "--strict_front_matter", StrictFrontMatter);
        ApplyOption(args, "--safe", SafeMode);
        ApplyOption(args, "--plugins", Plugins);
        ApplyOption(args, "--layouts", Layouts?.FullPath);
        ApplyOption(args, "--profile", LiquidProfile);
        ApplyOption(args, "--trace", Trace);

        ApplyOption(args, LogLevel);
    }
}
