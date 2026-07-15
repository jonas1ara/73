public class ContainerWithMostWaterTests
{
    [Theory]
    [InlineData(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
    [InlineData(new int[] { 1, 1 }, 1)]
    [InlineData(new int[] { 4, 3, 2, 1, 4 }, 16)]
    [InlineData(new int[] { 1, 2, 1 }, 2)]
    public void MaxArea_ReturnsLargestContainerArea(int[] height, int expected)
    {
        var sol = new Solution();

        var result = sol.MaxArea(height);

        Assert.Equal(expected, result);
    }
}
