public class LongestIncreasingSubsequenceTests
{
    [Theory]
    [InlineData(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 }, 4)]
    [InlineData(new int[] { 0, 1, 0, 3, 2, 3 }, 4)]
    [InlineData(new int[] { 7, 7, 7, 7, 7, 7, 7 }, 1)]
    [InlineData(new int[] { }, 0)]
    public void LengthOfLIS_ReturnsLengthOfLongestIncreasingSubsequence(int[] nums, int expected)
    {
        var sol = new Solution();

        var result = sol.LengthOfLIS(nums);

        Assert.Equal(expected, result);
    }
}
