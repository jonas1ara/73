public class SearchInRotatedSortedArrayTests
{
    [Theory]
    [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0, 4)]
    [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3, -1)]
    [InlineData(new int[] { 1 }, 0, -1)]
    [InlineData(new int[] { 1 }, 1, 0)]
    [InlineData(new int[] { }, 5, -1)]
    public void Search_ReturnsIndexOfTargetInRotatedArray(int[] nums, int target, int expected)
    {
        var sol = new Solution();

        var result = sol.Search(nums, target);

        Assert.Equal(expected, result);
    }
}
