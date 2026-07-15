public class InsertIntervalTests
{
    [Fact]
    public void Insert_MergesOverlappingIntervalIntoMiddle()
    {
        var sol = new Solution();
        int[][] intervals = new int[][] { new int[] { 1, 3 }, new int[] { 6, 9 } };
        int[] newInterval = new int[] { 2, 5 };

        var result = sol.Insert(intervals, newInterval);

        Assert.Equal(new int[][] { new int[] { 1, 5 }, new int[] { 6, 9 } }, result);
    }

    [Fact]
    public void Insert_MergesMultipleOverlappingIntervals()
    {
        var sol = new Solution();
        int[][] intervals = new int[][]
        {
            new int[] { 1, 2 },
            new int[] { 3, 5 },
            new int[] { 6, 7 },
            new int[] { 8, 10 },
            new int[] { 12, 16 }
        };
        int[] newInterval = new int[] { 4, 8 };

        var result = sol.Insert(intervals, newInterval);

        Assert.Equal(new int[][] { new int[] { 1, 2 }, new int[] { 3, 10 }, new int[] { 12, 16 } }, result);
    }

    [Fact]
    public void Insert_EmptyIntervals_ReturnsOnlyNewInterval()
    {
        var sol = new Solution();
        int[][] intervals = new int[0][];
        int[] newInterval = new int[] { 5, 7 };

        var result = sol.Insert(intervals, newInterval);

        Assert.Equal(new int[][] { new int[] { 5, 7 } }, result);
    }

    [Fact]
    public void Insert_NoOverlap_InsertsInOrder()
    {
        var sol = new Solution();
        int[][] intervals = new int[][] { new int[] { 1, 2 }, new int[] { 10, 12 } };
        int[] newInterval = new int[] { 4, 6 };

        var result = sol.Insert(intervals, newInterval);

        Assert.Equal(new int[][] { new int[] { 1, 2 }, new int[] { 4, 6 }, new int[] { 10, 12 } }, result);
    }
}
