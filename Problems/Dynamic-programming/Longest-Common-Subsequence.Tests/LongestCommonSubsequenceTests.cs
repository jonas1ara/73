public class LongestCommonSubsequenceTests
{
    [Theory]
    [InlineData("abcde", "ace", 3)]
    [InlineData("abc", "abc", 3)]
    [InlineData("abc", "def", 0)]
    public void LongestCommonSubsequence_ReturnsLengthOfLongestCommonSubsequence(string text1, string text2, int expected)
    {
        var sol = new Solution();

        var result = sol.LongestCommonSubsequence(text1, text2);

        Assert.Equal(expected, result);
    }
}
