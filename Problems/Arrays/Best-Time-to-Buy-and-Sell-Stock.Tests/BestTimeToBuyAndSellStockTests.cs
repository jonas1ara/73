public class BestTimeToBuyAndSellStockTests
{
    [Theory]
    [InlineData(new int[] { 7, 1, 5, 3, 6, 4 }, 5)]
    [InlineData(new int[] { 7, 6, 4, 3, 1 }, 0)]
    [InlineData(new int[] { 5 }, 0)]
    [InlineData(new int[] { 1, 2 }, 1)]
    [InlineData(new int[] { 2, 1 }, 0)]
    public void MaxProfit_ReturnsMaximumAchievableProfit(int[] prices, int expected)
    {
        var sol = new Solution();

        var result = sol.MaxProfit(prices);

        Assert.Equal(expected, result);
    }
}
