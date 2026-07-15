public class LongestSubstringWithoutRepeatingCharactersTests
{
    [Theory]
    [InlineData("abcabcbb", 3)]
    [InlineData("bbbbb", 1)]
    [InlineData("pwwkew", 3)]
    [InlineData("", 0)]
    [InlineData("a", 1)]
    [InlineData(" ", 1)]
    public void LengthOfLongestSubstring_ReturnsLongestUniqueWindow(string s, int expected)
    {
        var sol = new Solution();

        var result = sol.LengthOfLongestSubstring(s);

        Assert.Equal(expected, result);
    }
}
