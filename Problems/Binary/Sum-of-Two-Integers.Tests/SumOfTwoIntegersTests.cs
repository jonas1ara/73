public class SumOfTwoIntegersTests
{
    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(2, 3, 5)]
    [InlineData(0, 0, 0)]
    [InlineData(-1, 1, 0)]
    [InlineData(-2, -3, -5)]
    [InlineData(int.MaxValue, 0, int.MaxValue)]
    public void GetSum_ReturnsSumWithoutPlusOrMinusOperators(int a, int b, int expected)
    {
        var sol = new Solution();

        var result = sol.GetSum(a, b);

        Assert.Equal(expected, result);
    }
}
