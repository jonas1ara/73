public class NonOverlappingIntervalsTests
{
    [Fact]
    public void EraseOverlapIntervals_OneOverlap_ReturnsOne()
    {
        var sol = new Solution();
        int[][] intervals = new int[][]
        {
            new int[] { 1, 2 },
            new int[] { 2, 3 },
            new int[] { 3, 4 },
            new int[] { 1, 3 }
        };

        var result = sol.EraseOverlapIntervals(intervals);

        Assert.Equal(1, result);
    }

    [Fact]
    public void EraseOverlapIntervals_AllIdentical_ReturnsCountMinusOne()
    {
        var sol = new Solution();
        int[][] intervals = new int[][]
        {
            new int[] { 1, 2 },
            new int[] { 1, 2 },
            new int[] { 1, 2 }
        };

        var result = sol.EraseOverlapIntervals(intervals);

        Assert.Equal(2, result);
    }

    [Fact]
    public void EraseOverlapIntervals_NoOverlap_ReturnsZero()
    {
        var sol = new Solution();
        int[][] intervals = new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 } };

        var result = sol.EraseOverlapIntervals(intervals);

        Assert.Equal(0, result);
    }

    [Fact]
    public void EraseOverlapIntervals_SingleInterval_ReturnsZero()
    {
        var sol = new Solution();
        int[][] intervals = new int[][] { new int[] { 1, 2 } };

        var result = sol.EraseOverlapIntervals(intervals);

        Assert.Equal(0, result);
    }

    [Fact]
    public void EraseOverlapIntervals_EmptyIntervals_ReturnsZero()
    {
        var sol = new Solution();
        int[][] intervals = new int[0][];

        var result = sol.EraseOverlapIntervals(intervals);

        Assert.Equal(0, result);
    }
}
