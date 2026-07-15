public class HouseRobberTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 1 }, 4)]
    [InlineData(new int[] { 2, 7, 9, 3, 1 }, 12)]
    [InlineData(new int[] { 5 }, 5)]
    [InlineData(new int[] { }, 0)]
    public void Rob_ReturnsMaxMoneyWithoutAdjacentHouses(int[] nums, int expected)
    {
        var sol = new Solution();

        var result = sol.Rob(nums);

        Assert.Equal(expected, result);
    }
}
