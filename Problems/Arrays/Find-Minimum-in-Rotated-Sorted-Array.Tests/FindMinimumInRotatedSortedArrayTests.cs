public class FindMinimumInRotatedSortedArrayTests
{
    [Theory]
    [InlineData(new int[] { 3, 4, 5, 1, 2 }, 1)]
    [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0)]
    [InlineData(new int[] { 11, 13, 15, 17 }, 11)]
    [InlineData(new int[] { 1 }, 1)]
    [InlineData(new int[] { 2, 1 }, 1)]
    public void FindMin_ReturnsSmallestElement(int[] nums, int expected)
    {
        var sol = new Solution();

        var result = sol.FindMin(nums);

        Assert.Equal(expected, result);
    }
}
