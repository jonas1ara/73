public class MinimumWindowSubstringTests
{
    [Theory]
    [InlineData("ADOBECODEBANC", "ABC", "BANC")]
    [InlineData("a", "a", "a")]
    [InlineData("a", "aa", "")]
    [InlineData("a", "b", "")]
    public void MinWindow_ReturnsShortestSubstringCoveringT(string s, string t, string expected)
    {
        var sol = new Solution();

        var result = sol.MinWindow(s, t);

        Assert.Equal(expected, result);
    }
}
