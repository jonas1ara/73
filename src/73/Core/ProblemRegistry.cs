using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode73.Core;

public static partial class ProblemRegistry
{
    public static IReadOnlyList<Problem> All => _problems;

    public static Problem? FindByNumber(int number) =>
        _problems.FirstOrDefault(p => p.Number == number);

    public static Problem? FindById(string id) =>
        _problems.FirstOrDefault(p => string.Equals(p.Id, id, StringComparison.OrdinalIgnoreCase));

    public static Problem? FindBySlug(string slug) =>
        _problems.FirstOrDefault(p => string.Equals(p.Slug, slug, StringComparison.OrdinalIgnoreCase));

    public static Problem? FindByMethod(string methodName)
    {
        if (string.IsNullOrWhiteSpace(methodName)) return null;
        return _problems.FirstOrDefault(p =>
            string.Equals(p.ExpectedMethod, methodName, StringComparison.OrdinalIgnoreCase));
    }

    public static Problem? FindByClass(string className)
    {
        if (string.IsNullOrWhiteSpace(className) || className == "Solution") return null;
        return _problems.FirstOrDefault(p =>
            string.Equals(p.ExpectedClass, className, StringComparison.OrdinalIgnoreCase));
    }

    public static Problem? FindByFuzzy(string query)
    {
        if (string.IsNullOrWhiteSpace(query)) return null;

        query = query.Trim();

        // 1. Check numeric
        if (int.TryParse(query, out int num))
        {
            var byNum = FindByNumber(num);
            if (byNum != null) return byNum;
        }

        // Clean query: remove file extensions like .cs
        if (query.EndsWith(".cs", StringComparison.OrdinalIgnoreCase))
            query = query[..^3];

        var normQuery = Normalize(query);

        // 2. Exact match on normalized slug or id
        var exact = _problems.FirstOrDefault(p =>
            Normalize(p.Slug) == normQuery ||
            Normalize(p.Id) == normQuery ||
            Normalize(p.Title) == normQuery);
        if (exact != null) return exact;

        // 3. Check aliases
        var byAlias = _problems.FirstOrDefault(p =>
            p.Aliases.Any(a => Normalize(a) == normQuery));
        if (byAlias != null) return byAlias;

        // 4. Starts with slug or title
        var starts = _problems.FirstOrDefault(p =>
            Normalize(p.Slug).StartsWith(normQuery) ||
            Normalize(p.Title).StartsWith(normQuery));
        if (starts != null) return starts;

        // 5. Contains slug or title
        var contains = _problems.FirstOrDefault(p =>
            Normalize(p.Slug).Contains(normQuery) ||
            Normalize(p.Title).Contains(normQuery));
        if (contains != null) return contains;

        // 6. By method name
        var byMethod = FindByMethod(query);
        if (byMethod != null) return byMethod;

        // 7. By class name
        var byClass = FindByClass(query);
        if (byClass != null) return byClass;

        return null;
    }

    public static IEnumerable<string> GetCategories() =>
        _problems.Select(p => p.Category).Distinct(StringComparer.OrdinalIgnoreCase);

    public static IEnumerable<Problem> GetByCategory(string category) =>
        _problems.Where(p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));

    private static string Normalize(string input) =>
        new string(input.ToLowerInvariant().Where(char.IsLetterOrDigit).ToArray());
}
