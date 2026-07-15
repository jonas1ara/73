public class GroupAnagramsTests
{
    [Fact]
    public void GroupAnagrams_GroupsWordsWithSameLetterCounts()
    {
        var sol = new Solution();
        var input = new[] { "eat", "tea", "tan", "ate", "nat", "bat" };

        var result = sol.GroupAnagrams(input);

        var expected = new[] { new[] { "eat", "tea", "ate" }, new[] { "tan", "nat" }, new[] { "bat" } };
        AssertGroupsMatch(expected, result);
    }

    [Fact]
    public void GroupAnagrams_SingleEmptyString_ReturnsOneGroup()
    {
        var sol = new Solution();
        var input = new[] { "" };

        var result = sol.GroupAnagrams(input);

        var expected = new[] { new[] { "" } };
        AssertGroupsMatch(expected, result);
    }

    [Fact]
    public void GroupAnagrams_SingleCharacter_ReturnsOneGroup()
    {
        var sol = new Solution();
        var input = new[] { "a" };

        var result = sol.GroupAnagrams(input);

        var expected = new[] { new[] { "a" } };
        AssertGroupsMatch(expected, result);
    }

    [Fact]
    public void GroupAnagrams_NoAnagrams_ReturnsGroupPerWord()
    {
        var sol = new Solution();
        var input = new[] { "abc", "def", "ghi" };

        var result = sol.GroupAnagrams(input);

        var expected = new[] { new[] { "abc" }, new[] { "def" }, new[] { "ghi" } };
        AssertGroupsMatch(expected, result);
    }

    private static void AssertGroupsMatch(IEnumerable<IEnumerable<string>> expected, IEnumerable<IEnumerable<string>> actual)
    {
        var normalizedExpected = expected
            .Select(g => g.OrderBy(x => x, StringComparer.Ordinal).ToList())
            .OrderBy(g => string.Join(",", g), StringComparer.Ordinal)
            .ToList();
        var normalizedActual = actual
            .Select(g => g.OrderBy(x => x, StringComparer.Ordinal).ToList())
            .OrderBy(g => string.Join(",", g), StringComparer.Ordinal)
            .ToList();

        Assert.Equal(normalizedExpected.Count, normalizedActual.Count);
        for (int i = 0; i < normalizedExpected.Count; i++)
        {
            Assert.Equal(normalizedExpected[i], normalizedActual[i]);
        }
    }
}
