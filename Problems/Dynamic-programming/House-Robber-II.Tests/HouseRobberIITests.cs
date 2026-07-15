public class HouseRobberIITests
{
    [Theory]
    [InlineData(new int[] { 2, 3, 2 }, 3)]
    [InlineData(new int[] { 1, 2, 3, 1 }, 4)]
    [InlineData(new int[] { 1, 2, 3 }, 3)]
    [InlineData(new int[] { 5 }, 5)]
    public void Rob_ReturnsMaxMoneyWithoutAdjacentHousesInCircle(int[] nums, int expected)
    {
        var sol = new Solution();

        var result = sol.Rob(nums);

        Assert.Equal(expected, result);
    }
}
