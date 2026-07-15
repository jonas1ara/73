public class ValidParenthesesTests
{
    [Theory]
    [InlineData("()", true)]
    [InlineData("()[]{}", true)]
    [InlineData("(]", false)]
    [InlineData("", true)]
    [InlineData("(", false)]
    [InlineData(")", false)]
    [InlineData("({[()]})", true)]
    [InlineData("([)]", false)]
    public void IsValid_ChecksBracketMatchingAndOrder(string s, bool expected)
    {
        var sol = new Solution();

        var result = sol.IsValid(s);

        Assert.Equal(expected, result);
    }
}
