public class JumpGameTests
{
    [Theory]
    [InlineData(new int[] { 2, 3, 1, 1, 4 }, true)]
    [InlineData(new int[] { 3, 2, 1, 0, 4 }, false)]
    [InlineData(new int[] { 0 }, true)]
    public void CanJump_ReturnsWhetherLastIndexIsReachable(int[] nums, bool expected)
    {
        var sol = new Solution();

        var result = sol.CanJump(nums);

        Assert.Equal(expected, result);
    }
}
