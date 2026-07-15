public class UniquePathsTests
{
    [Theory]
    [InlineData(3, 7, 28)]
    [InlineData(3, 2, 3)]
    [InlineData(1, 1, 1)]
    public void UniquePaths_ReturnsNumberOfUniquePathsToBottomRight(int m, int n, int expected)
    {
        var sol = new Solution();

        var result = sol.UniquePaths(m, n);

        Assert.Equal(expected, result);
    }
}
