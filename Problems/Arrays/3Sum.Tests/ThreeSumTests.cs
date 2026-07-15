public class ThreeSumTests
{
    [Fact]
    public void ThreeSum_ReturnsTripletsSummingToZero()
    {
        var sol = new Solution();
        var expected = new List<IList<int>> { new List<int> { -1, -1, 2 }, new List<int> { -1, 0, 1 } };

        var result = sol.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ThreeSum_ReturnsEmptyWhenNoTripletSumsToZero()
    {
        var sol = new Solution();

        var result = sol.ThreeSum(new int[] { 0, 1, 1 });

        Assert.Empty(result);
    }

    [Fact]
    public void ThreeSum_ReturnsSingleTripletOfZeros()
    {
        var sol = new Solution();
        var expected = new List<IList<int>> { new List<int> { 0, 0, 0 } };

        var result = sol.ThreeSum(new int[] { 0, 0, 0 });

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ThreeSum_ReturnsEmptyWhenFewerThanThreeElements()
    {
        var sol = new Solution();

        var result = sol.ThreeSum(new int[] { 1, 2 });

        Assert.Empty(result);
    }
}
