public class ReverseBitsTests
{
    [Theory]
    [InlineData(43261596u, 964176192u)]
    [InlineData(4294967293u, 3221225471u)]
    [InlineData(0u, 0u)]
    [InlineData(1u, 2147483648u)]
    [InlineData(4294967295u, 4294967295u)]
    public void ReverseBits_ReturnsBitReversedValue(uint n, uint expected)
    {
        var sol = new Solution();

        var result = sol.reverseBits(n);

        Assert.Equal(expected, result);
    }
}
