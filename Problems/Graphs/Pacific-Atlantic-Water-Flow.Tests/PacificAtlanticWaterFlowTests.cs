public class PacificAtlanticWaterFlowTests
{
    [Fact]
    public void PacificAtlantic_FiveByFiveGrid_ReturnsCellsReachingBothOceans()
    {
        var sol = new Solution();
        var heights = new int[][]
        {
            new int[] { 1, 2, 2, 3, 5 },
            new int[] { 3, 2, 3, 4, 4 },
            new int[] { 2, 4, 5, 3, 1 },
            new int[] { 6, 7, 1, 4, 5 },
            new int[] { 5, 1, 1, 2, 4 },
        };

        var result = sol.PacificAtlantic(heights);

        Assert.Equal(new IList<int>[]
        {
            new List<int> { 0, 4 },
            new List<int> { 1, 3 },
            new List<int> { 1, 4 },
            new List<int> { 2, 2 },
            new List<int> { 3, 0 },
            new List<int> { 3, 1 },
            new List<int> { 4, 0 },
        }, result);
    }

    [Fact]
    public void PacificAtlantic_SingleCell_ReturnsThatCell()
    {
        var sol = new Solution();
        var heights = new int[][] { new int[] { 1 } };

        var result = sol.PacificAtlantic(heights);

        Assert.Equal(new IList<int>[] { new List<int> { 0, 0 } }, result);
    }

    [Fact]
    public void PacificAtlantic_EmptyHeights_ReturnsEmptyList()
    {
        var sol = new Solution();

        var result = sol.PacificAtlantic(Array.Empty<int[]>());

        Assert.Empty(result);
    }
}
