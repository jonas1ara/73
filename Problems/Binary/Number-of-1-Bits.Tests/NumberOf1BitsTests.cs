public class NumberOf1BitsTests
{
    [Theory]
    [InlineData(11u, 3)]
    [InlineData(128u, 1)]
    [InlineData(4294967293u, 31)]
    [InlineData(0u, 0)]
    [InlineData(4294967295u, 32)]
    public void HammingWeight_ReturnsCountOfSetBits(uint n, int expected)
    {
        var sol = new Solution();

        var result = sol.HammingWeight(n);

        Assert.Equal(expected, result);
    }
}
