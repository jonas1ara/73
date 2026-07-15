public class CoinChangeTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 5 }, 11, 3)]
    [InlineData(new int[] { 2 }, 3, -1)]
    [InlineData(new int[] { 1 }, 0, 0)]
    public void CoinChange_ReturnsFewestCoinsForAmount(int[] coins, int amount, int expected)
    {
        var sol = new Solution();

        var result = sol.CoinChange(coins, amount);

        Assert.Equal(expected, result);
    }
}
