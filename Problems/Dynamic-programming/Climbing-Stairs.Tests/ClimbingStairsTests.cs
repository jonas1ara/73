public class ClimbingStairsTests
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    [InlineData(5, 8)]
    public void ClimbStairs_ReturnsNumberOfDistinctWays(int n, int expected)
    {
        var sol = new Solution();

        var result = sol.ClimbStairs(n);

        Assert.Equal(expected, result);
    }
}
