public class MaximumProductSubarrayTests
{
    [Theory]
    [InlineData(new int[] { 2, 3, -2, 4 }, 6)]
    [InlineData(new int[] { -2, 0, -1 }, 0)]
    [InlineData(new int[] { -2 }, -2)]
    [InlineData(new int[] { 0, 2 }, 2)]
    [InlineData(new int[] { -2, 3, -4 }, 24)]
    public void MaxProduct_ReturnsLargestProductOfContiguousSubarray(int[] nums, int expected)
    {
        var sol = new Solution();

        var result = sol.MaxProduct(nums);

        Assert.Equal(expected, result);
    }
}
