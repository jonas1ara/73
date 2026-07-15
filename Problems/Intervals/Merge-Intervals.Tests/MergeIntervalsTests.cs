public class MergeIntervalsTests
{
    [Fact]
    public void Merge_OverlappingIntervals_MergesFirstTwo()
    {
        var sol = new Solution();
        int[][] intervals = new int[][]
        {
            new int[] { 1, 3 },
            new int[] { 2, 6 },
            new int[] { 8, 10 },
            new int[] { 15, 18 }
        };

        var result = sol.Merge(intervals);

        Assert.Equal(new int[][] { new int[] { 1, 6 }, new int[] { 8, 10 }, new int[] { 15, 18 } }, result);
    }

    [Fact]
    public void Merge_TouchingIntervals_ConsideredOverlapping()
    {
        var sol = new Solution();
        int[][] intervals = new int[][] { new int[] { 1, 4 }, new int[] { 4, 5 } };

        var result = sol.Merge(intervals);

        Assert.Equal(new int[][] { new int[] { 1, 5 } }, result);
    }

    [Fact]
    public void Merge_SingleInterval_ReturnsSameInterval()
    {
        var sol = new Solution();
        int[][] intervals = new int[][] { new int[] { 1, 4 } };

        var result = sol.Merge(intervals);

        Assert.Equal(new int[][] { new int[] { 1, 4 } }, result);
    }

    [Fact]
    public void Merge_NoOverlaps_ReturnsAllIntervalsUnchanged()
    {
        var sol = new Solution();
        int[][] intervals = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } };

        var result = sol.Merge(intervals);

        Assert.Equal(new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } }, result);
    }

    [Fact]
    public void Merge_EmptyIntervals_ReturnsEmptyArray()
    {
        var sol = new Solution();
        int[][] intervals = new int[0][];

        var result = sol.Merge(intervals);

        Assert.Empty(result);
    }
}
