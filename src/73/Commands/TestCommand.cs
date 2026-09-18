using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Spectre.Console;
using LeetCode73.Core;
using LeetCode73.Runner;
using LeetCode73.UI;

namespace LeetCode73.Commands;

public static class TestCommand
{
    public static int Execute(string? target, int timeoutMs = 3000, bool benchmark = false, int iterations = 1000)
    {
        string? filePath = null;
        string? sourceCode = null;
        Problem? problem = null;

        // 1. If target is an existing file path
        if (!string.IsNullOrWhiteSpace(target) && File.Exists(target))
        {
            filePath = Path.GetFullPath(target);
            sourceCode = File.ReadAllText(filePath);
            problem = ProblemResolver.Resolve(filePath, sourceCode);
        }
        else
        {
            // 2. Try resolving target as a problem name/slug/number
            if (!string.IsNullOrWhiteSpace(target))
            {
                problem = ProblemResolver.Resolve(target);
            }

            // 3. If target is empty or not resolved yet, check current working directory
            if (problem == null)
            {
                problem = ProblemResolver.Resolve(Directory.GetCurrentDirectory());
            }

            // 4. Look for a solution file locally
            if (problem != null)
            {
                var cwd = Directory.GetCurrentDirectory();

                // 4a. Check direct standard candidate names in current directory
                var directCandidates = new[]
                {
                    Path.Combine(cwd, $"{problem.Slug}.cs"),
                    Path.Combine(cwd, "Solution.cs"),
                    Path.Combine(cwd, problem.SolutionFileName)
                };

                foreach (var candidate in directCandidates)
                {
                    if (File.Exists(candidate))
                    {
                        filePath = Path.GetFullPath(candidate);
                        sourceCode = File.ReadAllText(filePath);
                        break;
                    }
                }

                // 4b. Scan current directory and user subdirectories for any matching solution
                if (sourceCode == null && Directory.Exists(cwd))
                {
                    sourceCode = FindMatchingUserSource(cwd, problem, out filePath);
                }

                // 4c. Fallback: check if we are inside the repository and can point to the problem's own folder
                if (sourceCode == null)
                {
                    var repoCandidate = Path.Combine(cwd, problem.RelativePath, problem.SolutionFileName);
                    if (File.Exists(repoCandidate))
                    {
                        filePath = Path.GetFullPath(repoCandidate);
                        sourceCode = File.ReadAllText(filePath);
                    }
                }

                // 4d. Fallback: load reference template from embedded resources
                if (sourceCode == null)
                {
                    sourceCode = ResourceProvider.GetSolutionTemplate(problem);
                }
            }
        }

        if (problem == null)
        {
            AnsiConsole.MarkupLine($"[bold red]Error:[/] Could not identify problem matching '[yellow]{Markup.Escape(target ?? "")}[/]'.");
            AnsiConsole.MarkupLine("[grey]Try providing a valid .cs file (e.g. [cyan]73 two.cs[/]), or problem identifier (e.g. [cyan]73 test Two-Sum[/]).[/]");
            AnsiConsole.MarkupLine("[grey]Run [cyan]73 list[/] to view all 76 available problems.[/]");
            return 1;
        }

        if (string.IsNullOrWhiteSpace(sourceCode))
        {
            AnsiConsole.MarkupLine($"[bold red]Error:[/] No solution code found for problem [cyan]{problem.Title}[/].");
            AnsiConsole.MarkupLine($"[grey]Create one by running: [cyan]73 new {problem.Slug.ToLowerInvariant()}[/][/]");
            return 1;
        }

        // Render header
        ConsoleFormatter.RenderHeader(problem, filePath);

        // Run tests with Roslyn
        var result = RoslynRunner.Execute(problem, sourceCode, filePath, timeoutMs);

        // Render execution results
        ConsoleFormatter.RenderExecutionResult(result);

        if (benchmark && result.OverallVerdict == TestVerdict.Accepted)
        {
            var refSource = ResourceProvider.GetSolutionTemplate(problem);
            if (!string.IsNullOrWhiteSpace(refSource))
            {
                var benchReport = BenchmarkRunner.Run(
                    problem,
                    sourceCode,
                    filePath ?? "Your Solution",
                    refSource,
                    problem.SolutionFileName,
                    iterations);

                ConsoleFormatter.RenderBenchmarkReport(benchReport);
            }
        }

        return result.OverallVerdict == TestVerdict.Accepted ? 0 : 1;
    }

    private static string? FindMatchingUserSource(string rootDir, Problem problem, out string? foundPath)
    {
        foundPath = null;

        // 1. Check root directory top level
        foreach (var file in Directory.GetFiles(rootDir, "*.cs", SearchOption.TopDirectoryOnly))
        {
            if (IsUserSolution(file, problem, out var content))
            {
                foundPath = Path.GetFullPath(file);
                return content;
            }
        }

        // 2. Check subdirectories excluding framework and repo resource folders
        var ignoredDirs = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "bin", "obj", ".git", ".vs", "Problems", "nupkg"
        };

        try
        {
            foreach (var subDir in Directory.GetDirectories(rootDir, "*", SearchOption.TopDirectoryOnly))
            {
                var dirName = Path.GetFileName(subDir);
                if (dirName.StartsWith(".") || ignoredDirs.Contains(dirName))
                    continue;

                foreach (var file in Directory.GetFiles(subDir, "*.cs", SearchOption.AllDirectories))
                {
                    var parts = file.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                    if (parts.Any(p => ignoredDirs.Contains(p)))
                        continue;

                    if (IsUserSolution(file, problem, out var content))
                    {
                        foundPath = Path.GetFullPath(file);
                        return content;
                    }
                }
            }
        }
        catch
        {
            // Ignore filesystem access errors
        }

        return null;
    }

    private static bool IsUserSolution(string filePath, Problem problem, out string content)
    {
        content = string.Empty;
        var fileName = Path.GetFileName(filePath);
        if (fileName.StartsWith(".") ||
            fileName.EndsWith(".Tests.cs", StringComparison.OrdinalIgnoreCase) ||
            fileName.EndsWith(".g.cs", StringComparison.OrdinalIgnoreCase) ||
            fileName.Equals("CommonHelpers.cs", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        try
        {
            content = File.ReadAllText(filePath);
            var resolved = ProblemResolver.Resolve(filePath, content);
            return resolved != null && resolved.Number == problem.Number;
        }
        catch
        {
            return false;
        }
    }
}
