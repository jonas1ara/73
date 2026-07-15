public class LongestRepeatingCharacterReplacementTests
{
    [Theory]
    [InlineData("ABAB", 2, 4)]
    [InlineData("AABABBA", 1, 4)]
    [InlineData("A", 0, 1)]
    [InlineData("AAAA", 0, 4)]
    public void CharacterReplacement_ReturnsLongestWindowAfterAtMostKReplacements(string s, int k, int expected)
    {
        var sol = new Solution();

        var result = sol.CharacterReplacement(s, k);

        Assert.Equal(expected, result);
    }
}
