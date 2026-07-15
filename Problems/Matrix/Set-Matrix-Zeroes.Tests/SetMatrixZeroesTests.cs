public class SetMatrixZeroesTests
{
    public static IEnumerable<object[]> SetZeroesCases()
    {
        yield return new object[]
        {
            new int[][]
            {
                new int[] { 1, 1, 1 },
                new int[] { 1, 0, 1 },
                new int[] { 1, 1, 1 },
            },
            new int[][]
            {
                new int[] { 1, 0, 1 },
                new int[] { 0, 0, 0 },
                new int[] { 1, 0, 1 },
            },
        };

        yield return new object[]
        {
            new int[][]
            {
                new int[] { 0, 1, 2, 0 },
                new int[] { 3, 4, 5, 2 },
                new int[] { 1, 3, 1, 5 },
            },
            new int[][]
            {
                new int[] { 0, 0, 0, 0 },
                new int[] { 0, 4, 5, 0 },
                new int[] { 0, 3, 1, 0 },
            },
        };

        yield return new object[]
        {
            new int[][]
            {
                new int[] { 1 },
            },
            new int[][]
            {
                new int[] { 1 },
            },
        };

        yield return new object[]
        {
            new int[][]
            {
                new int[] { 0 },
            },
            new int[][]
            {
                new int[] { 0 },
            },
        };

        yield return new object[]
        {
            new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 3, 4 },
            },
            new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 3, 4 },
            },
        };
    }

    [Theory]
    [MemberData(nameof(SetZeroesCases))]
    public void SetZeroes_ZeroesRowsAndColumnsInPlace(int[][] matrix, int[][] expected)
    {
        var sol = new Solution();

        sol.SetZeroes(matrix);

        Assert.Equal(expected, matrix);
    }
}
