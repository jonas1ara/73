public class NumberOfConnectedComponentsInAnUndirectedGraphTests
{
    public static IEnumerable<object[]> CountComponentsCases()
    {
        yield return new object[] { 5, new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 3, 4 } }, 2 };
        yield return new object[] { 5, new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 3, 4 } }, 1 };
        yield return new object[] { 1, new int[][] { }, 1 };
        yield return new object[] { 3, new int[][] { }, 3 };
    }

    [Theory]
    [MemberData(nameof(CountComponentsCases))]
    public void CountComponents_ReturnsNumberOfConnectedComponents(int n, int[][] edges, int expected)
    {
        var sol = new Solution();

        var result = sol.CountComponents(n, edges);

        Assert.Equal(expected, result);
    }
}
