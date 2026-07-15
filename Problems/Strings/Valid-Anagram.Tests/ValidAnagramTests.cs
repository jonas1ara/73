public class ValidAnagramTests
{
    [Theory]
    [InlineData("anagram", "nagaram", true)]
    [InlineData("rat", "car", false)]
    [InlineData("", "", true)]
    [InlineData("a", "ab", false)]
    [InlineData("a", "a", true)]
    public void IsAnagram_DeterminesWhetherTIsAnAnagramOfS(string s, string t, bool expected)
    {
        var sol = new Solution();

        var result = sol.IsAnagram(s, t);

        Assert.Equal(expected, result);
    }
}
