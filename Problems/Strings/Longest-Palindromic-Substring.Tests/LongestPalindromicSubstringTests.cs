public class LongestPalindromicSubstringTests
{
    [Theory]
    [InlineData("babad", "bab")]
    [InlineData("cbbd", "bb")]
    [InlineData("a", "a")]
    [InlineData("", "")]
    [InlineData("ac", "a")]
    public void LongestPalindrome_ReturnsLongestPalindromicSubstring(string s, string expected)
    {
        var sol = new Solution();

        var result = sol.LongestPalindrome(s);

        Assert.Equal(expected, result);
    }
}
