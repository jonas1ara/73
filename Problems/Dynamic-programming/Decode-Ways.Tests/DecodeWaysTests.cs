public class DecodeWaysTests
{
    [Theory]
    [InlineData("12", 2)]
    [InlineData("226", 3)]
    [InlineData("06", 0)]
    public void NumDecodings_ReturnsNumberOfWaysToDecode(string s, int expected)
    {
        var sol = new Solution();

        var result = sol.NumDecodings(s);

        Assert.Equal(expected, result);
    }
}
