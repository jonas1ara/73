public class CombinationSumIVTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3 }, 4, 7)]
    [InlineData(new int[] { 9 }, 3, 0)]
    public void CombinationSum4_ReturnsNumberOfOrderedCombinations(int[] nums, int target, int expected)
    {
        var sol = new Solution();

        var result = sol.CombinationSum4(nums, target);

        Assert.Equal(expected, result);
    }
}
