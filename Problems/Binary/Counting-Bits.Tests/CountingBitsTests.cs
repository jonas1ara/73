public class CountingBitsTests
{
    [Theory]
    [InlineData(2, new int[] { 0, 1, 1 })]
    [InlineData(5, new int[] { 0, 1, 1, 2, 1, 2 })]
    [InlineData(0, new int[] { 0 })]
    [InlineData(1, new int[] { 0, 1 })]
    public void CountBits_ReturnsBitCountsForEachNumberUpToN(int n, int[] expected)
    {
        var sol = new Solution();

        var result = sol.CountBits(n);

        Assert.Equal(expected, result);
    }
}
