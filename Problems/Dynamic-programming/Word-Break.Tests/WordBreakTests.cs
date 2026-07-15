public class WordBreakTests
{
    [Theory]
    [InlineData("leetcode", new string[] { "leet", "code" }, true)]
    [InlineData("applepenapple", new string[] { "apple", "pen" }, true)]
    [InlineData("catsandog", new string[] { "cats", "dog", "sand", "and", "cat" }, false)]
    public void WordBreak_ReturnsWhetherStringCanBeSegmented(string s, string[] wordDict, bool expected)
    {
        var sol = new Solution();

        var result = sol.WordBreak(s, wordDict);

        Assert.Equal(expected, result);
    }
}
