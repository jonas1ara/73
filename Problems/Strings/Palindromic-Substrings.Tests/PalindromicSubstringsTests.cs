public class PalindromicSubstringsTests
{
    [Theory]
    [InlineData("abc", 3)]
    [InlineData("aaa", 6)]
    [InlineData("a", 1)]
    [InlineData("", 0)]
    [InlineData("aa", 3)]
    public void CountSubstrings_CountsAllPalindromicSubstrings(string s, int expected)
    {
        var sol = new Solution();

        var result = sol.CountSubstrings(s);

        Assert.Equal(expected, result);
    }
}
