using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LeetCode73.Core;

public static class ResourceProvider
{
    private static readonly Assembly _asm = typeof(ResourceProvider).Assembly;
    private static readonly string[] _resourceNames = _asm.GetManifestResourceNames();

    public static string? GetReadme(Problem problem)
    {
        // 1. Try local disk
        var localPath = FindLocalFile(problem.RelativePath, "README.md");
        if (localPath != null && File.Exists(localPath))
            return File.ReadAllText(localPath);

        // 2. Try embedded resource
        return ReadEmbeddedResource(problem.Slug, "README.md");
    }

    public static string? GetTestSource(Problem problem)
    {
        // 1. Try local disk
        var testRelPath = $"{problem.RelativePath}.Tests";
        var localPath = FindLocalFile(testRelPath, problem.TestFileName);
        if (localPath != null && File.Exists(localPath))
            return File.ReadAllText(localPath);

        // 2. Try embedded resource
        return ReadEmbeddedResource(problem.Slug, problem.TestFileName);
    }

    public static string? GetSolutionTemplate(Problem problem)
    {
        // 1. Try local disk
        var localPath = FindLocalFile(problem.RelativePath, problem.SolutionFileName);
        if (localPath != null && File.Exists(localPath))
            return File.ReadAllText(localPath);

        // 2. Try embedded resource
        var embedded = ReadEmbeddedResource(problem.Slug, problem.SolutionFileName);
        if (!string.IsNullOrWhiteSpace(embedded))
            return embedded;

        // 3. Fallback: generate boilerplate from signature
        return GenerateBoilerplate(problem);
    }

    public static string GenerateBoilerplate(Problem problem)
    {
        if (problem.ExpectedClass != "Solution")
        {
            return $@"using System;
using System.Collections.Generic;

public class {problem.ExpectedClass}
{{
    public {problem.ExpectedClass}()
    {{
    }}
}}
";
        }

        var sig = !string.IsNullOrWhiteSpace(problem.MethodSignature)
            ? problem.MethodSignature
            : $"public void {problem.ExpectedMethod}()";

        return $@"using System;
using System.Collections.Generic;

// Problem: {problem.FormattedNumber} - {problem.Title} [{problem.Difficulty}]
public class Solution
{{
    {sig}
    {{
        throw new NotImplementedException();
    }}
}}
";
    }

    private static string? FindLocalFile(string relativeDir, string fileName)
    {
        var current = new DirectoryInfo(Directory.GetCurrentDirectory());
        for (int i = 0; i < 6 && current != null; i++)
        {
            var candidate = Path.Combine(current.FullName, relativeDir, fileName);
            if (File.Exists(candidate)) return candidate;

            var candUnderProblems = Path.Combine(current.FullName, "Problems", Path.GetFileName(relativeDir), fileName);
            if (File.Exists(candUnderProblems)) return candUnderProblems;

            current = current.Parent;
        }
        return null;
    }

    private static string? ReadEmbeddedResource(string slug, string fileName)
    {
        // Find best match in _resourceNames
        var match = _resourceNames.FirstOrDefault(r =>
            r.EndsWith(fileName, StringComparison.OrdinalIgnoreCase) &&
            r.Contains(slug.Replace("-", "_"), StringComparison.OrdinalIgnoreCase));

        match ??= _resourceNames.FirstOrDefault(r =>
            r.EndsWith(fileName, StringComparison.OrdinalIgnoreCase));

        if (match == null) return null;

        using var stream = _asm.GetManifestResourceStream(match);
        if (stream == null) return null;
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}
