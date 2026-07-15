public class LongestConsecutiveSequenceTests
{
    [Theory]
    [InlineData(new int[] { 100, 4, 200, 1, 3, 2 }, 4)]
    [InlineData(new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }, 9)]
    [InlineData(new int[] { }, 0)]
    [InlineData(new int[] { 1, 2, 0, 1 }, 3)]
    public void LongestConsecutive_ReturnsLengthOfLongestRun(int[] nums, int expected)
    {
        var sol = new Solution();

        var result = sol.LongestConsecutive(nums);

        Assert.Equal(expected, result);
    }
}
