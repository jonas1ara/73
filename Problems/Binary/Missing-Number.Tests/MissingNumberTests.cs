public class MissingNumberTests
{
    [Theory]
    [InlineData(new int[] { 3, 0, 1 }, 2)]
    [InlineData(new int[] { 0, 1 }, 2)]
    [InlineData(new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 }, 8)]
    [InlineData(new int[] { 0 }, 1)]
    [InlineData(new int[] { 1 }, 0)]
    public void MissingNumber_ReturnsTheMissingValueInRange(int[] nums, int expected)
    {
        var sol = new Solution();

        var result = sol.MissingNumber(nums);

        Assert.Equal(expected, result);
    }
}
