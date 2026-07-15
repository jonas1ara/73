public class MaximumSubarrayTests
{
    [Theory]
    [InlineData(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6)]
    [InlineData(new int[] { 1 }, 1)]
    [InlineData(new int[] { 5, 4, -1, 7, 8 }, 23)]
    [InlineData(new int[] { -1 }, -1)]
    [InlineData(new int[] { -3, -2, -1 }, -1)]
    public void MaxSubArray_ReturnsLargestSumOfContiguousSubarray(int[] nums, int expected)
    {
        var sol = new Solution();

        var result = sol.MaxSubArray(nums);

        Assert.Equal(expected, result);
    }
}
