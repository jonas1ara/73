public class TwoSumTests
{
    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
    [InlineData(new int[] { -1, -2, -3, -4, -5 }, -8, new int[] { 2, 4 })]
    public void TwoSum_ReturnsIndicesOfMatchingPair(int[] nums, int target, int[] expected)
    {
        var sol = new Solution();

        var result = sol.TwoSum(nums, target);

        Assert.Equal(expected, result);
    }
}
