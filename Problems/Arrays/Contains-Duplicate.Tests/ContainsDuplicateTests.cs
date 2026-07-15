public class ContainsDuplicateTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 1 }, true)]
    [InlineData(new int[] { 1, 2, 3, 4 }, false)]
    [InlineData(new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }, true)]
    [InlineData(new int[] { }, false)]
    [InlineData(new int[] { 1 }, false)]
    public void ContainsDuplicate_DetectsRepeatedValues(int[] nums, bool expected)
    {
        var sol = new Solution();

        var result = sol.ContainsDuplicate(nums);

        Assert.Equal(expected, result);
    }
}
