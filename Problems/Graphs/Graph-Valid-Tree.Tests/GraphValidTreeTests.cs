public class GraphValidTreeTests
{
    public static IEnumerable<object[]> ValidTreeCases()
    {
        yield return new object[] { 5, new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 0, 3 }, new int[] { 1, 4 } }, true };
        yield return new object[] { 5, new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 1, 3 }, new int[] { 1, 4 } }, false };
        yield return new object[] { 1, new int[][] { }, true };
        yield return new object[] { 2, new int[][] { }, false };
        yield return new object[] { 4, new int[][] { new int[] { 0, 1 }, new int[] { 2, 3 } }, false };
    }

    [Theory]
    [MemberData(nameof(ValidTreeCases))]
    public void ValidTree_DeterminesWhetherEdgesFormATree(int n, int[][] edges, bool expected)
    {
        var sol = new Solution();

        var result = sol.ValidTree(n, edges);

        Assert.Equal(expected, result);
    }
}
