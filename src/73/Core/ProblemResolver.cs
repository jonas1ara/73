using System;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LeetCode73.Core;

public static class ProblemResolver
{
    private static readonly HashSet<string> _ignoredFolderNames = new(StringComparer.OrdinalIgnoreCase)
    {
        "73", "src", "Problems", "bin", "obj", "Debug", "Release", "net10.0", "net8.0", "net11.0"
    };

    public static Problem? Resolve(string? input, string? sourceCode = null)
    {
        // 1. If input is a path to an existing file
        if (!string.IsNullOrWhiteSpace(input) && File.Exists(input))
        {
            // Exact problem path match (e.g. Problems/Arrays/Two-Sum/...)
            var exact = ResolveExactProblemPath(input);
            if (exact != null) return exact;

            sourceCode ??= File.ReadAllText(input);
        }

        // 2. If source code is available, AST resolution takes precedence over weak fuzzy dir matches!
        if (!string.IsNullOrWhiteSpace(sourceCode))
        {
            var problemFromCode = ResolveFromCode(sourceCode);
            if (problemFromCode != null) return problemFromCode;
        }

        // 3. Try resolving by filename or fuzzy query
        if (!string.IsNullOrWhiteSpace(input))
        {
            var problemFromPath = ResolveFromPath(input);
            if (problemFromPath != null) return problemFromPath;

            var problemFromFuzzy = ProblemRegistry.FindByFuzzy(input);
            if (problemFromFuzzy != null) return problemFromFuzzy;
        }

        // 4. Try current working directory
        var cwd = Directory.GetCurrentDirectory();
        var cwdName = Path.GetFileName(cwd);
        if (!_ignoredFolderNames.Contains(cwdName))
        {
            var problemFromCwd = ProblemRegistry.FindByFuzzy(cwdName);
            if (problemFromCwd != null) return problemFromCwd;
        }

        return null;
    }

    public static Problem? ResolveExactProblemPath(string path)
    {
        if (string.IsNullOrWhiteSpace(path)) return null;
        var fullPath = Path.GetFullPath(path).Replace('\\', '/');

        foreach (var problem in ProblemRegistry.All)
        {
            if (fullPath.Contains($"/{problem.Slug}/", StringComparison.OrdinalIgnoreCase) ||
                fullPath.EndsWith($"/{problem.SolutionFileName}", StringComparison.OrdinalIgnoreCase))
            {
                return problem;
            }
        }

        return null;
    }

    public static Problem? ResolveFromPath(string path)
    {
        if (string.IsNullOrWhiteSpace(path)) return null;

        var exact = ResolveExactProblemPath(path);
        if (exact != null) return exact;

        // Check filename without extension
        var fileName = Path.GetFileNameWithoutExtension(path);
        if (!string.IsNullOrWhiteSpace(fileName) &&
            !string.Equals(fileName, "solution", StringComparison.OrdinalIgnoreCase) &&
            !string.Equals(fileName, "test", StringComparison.OrdinalIgnoreCase) &&
            !string.Equals(fileName, "program", StringComparison.OrdinalIgnoreCase) &&
            !_ignoredFolderNames.Contains(fileName))
        {
            var match = ProblemRegistry.FindByFuzzy(fileName);
            if (match != null) return match;
        }

        // Check parent directory name if not ignored
        var parentDir = Path.GetFileName(Path.GetDirectoryName(Path.GetFullPath(path)));
        if (!string.IsNullOrWhiteSpace(parentDir) && !_ignoredFolderNames.Contains(parentDir))
        {
            var match = ProblemRegistry.FindByFuzzy(parentDir);
            if (match != null) return match;
        }

        return null;
    }

    public static Problem? ResolveFromCode(string sourceCode)
    {
        if (string.IsNullOrWhiteSpace(sourceCode)) return null;

        try
        {
            var tree = CSharpSyntaxTree.ParseText(sourceCode);
            var root = tree.GetCompilationUnitRoot();

            var classDecls = root.DescendantNodes().OfType<ClassDeclarationSyntax>().ToList();

            // 1. Check for specialized design classes (Twitter, MedianFinder, Trie, WordDictionary, Codec)
            foreach (var cls in classDecls)
            {
                var name = cls.Identifier.Text;
                var match = ProblemRegistry.FindByClass(name);
                if (match != null) return match;
            }

            // 2. Check public methods in class Solution
            var solutionClass = classDecls.FirstOrDefault(c => c.Identifier.Text == "Solution");
            var methodOwner = solutionClass ?? classDecls.FirstOrDefault();

            if (methodOwner != null)
            {
                var methods = methodOwner.Members
                    .OfType<MethodDeclarationSyntax>()
                    .Where(m => m.Modifiers.Any(SyntaxKind.PublicKeyword))
                    .Select(m => m.Identifier.Text)
                    .ToList();

                foreach (var method in methods)
                {
                    var match = ProblemRegistry.FindByMethod(method);
                    if (match != null) return match;
                }
            }
        }
        catch
        {
            // Fallback: ignore syntax errors and continue
        }

        return null;
    }
}
