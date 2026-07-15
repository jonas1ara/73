public class ValidPalindromeTests
{
    [Theory]
    [InlineData("A man, a plan, a canal: Panama", true)]
    [InlineData("race a car", false)]
    [InlineData(" ", true)]
    [InlineData("", true)]
    [InlineData("a", true)]
    [InlineData("0P", false)]
    public void IsPalindrome_IgnoresCaseAndNonAlphanumericCharacters(string s, bool expected)
    {
        var sol = new Solution();

        var result = sol.IsPalindrome(s);

        Assert.Equal(expected, result);
    }
}
