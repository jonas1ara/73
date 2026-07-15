public class SpiralMatrixTests
{
    public static IEnumerable<object[]> SpiralOrderCases()
    {
        yield return new object[]
        {
            new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 },
            },
            new List<int> { 1, 2, 3, 6, 9, 8, 7, 4, 5 },
        };

        yield return new object[]
        {
            new int[][]
            {
                new int[] { 1, 2, 3, 4 },
                new int[] { 5, 6, 7, 8 },
                new int[] { 9, 10, 11, 12 },
            },
            new List<int> { 1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7 },
        };

        yield return new object[]
        {
            new int[][]
            {
                new int[] { 1 },
            },
            new List<int> { 1 },
        };

        yield return new object[]
        {
            new int[][]
            {
                new int[] { 1, 2, 3, 4 },
            },
            new List<int> { 1, 2, 3, 4 },
        };

        yield return new object[]
        {
            new int[][]
            {
                new int[] { 1 },
                new int[] { 2 },
                new int[] { 3 },
            },
            new List<int> { 1, 2, 3 },
        };
    }

    [Theory]
    [MemberData(nameof(SpiralOrderCases))]
    public void SpiralOrder_ReturnsElementsInSpiralOrder(int[][] matrix, List<int> expected)
    {
        var sol = new Solution();

        var result = sol.SpiralOrder(matrix);

        Assert.Equal(expected, result);
    }
}
