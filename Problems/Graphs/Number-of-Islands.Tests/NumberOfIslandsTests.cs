public class NumberOfIslandsTests
{
    public static IEnumerable<object[]> NumIslandsCases()
    {
        yield return new object[]
        {
            new char[][]
            {
                new char[] { '1', '1', '1', '1', '0' },
                new char[] { '1', '1', '0', '1', '0' },
                new char[] { '1', '1', '0', '0', '0' },
                new char[] { '0', '0', '0', '0', '0' },
            },
            1,
        };

        yield return new object[]
        {
            new char[][]
            {
                new char[] { '1', '1', '0', '0', '0' },
                new char[] { '1', '1', '0', '0', '0' },
                new char[] { '0', '0', '1', '0', '0' },
                new char[] { '0', '0', '0', '1', '1' },
            },
            3,
        };

        yield return new object[]
        {
            new char[][]
            {
                new char[] { '0', '0' },
                new char[] { '0', '0' },
            },
            0,
        };

        yield return new object[]
        {
            new char[][] { new char[] { '1' } },
            1,
        };
    }

    [Theory]
    [MemberData(nameof(NumIslandsCases))]
    public void NumIslands_CountsIslandsInGrid(char[][] grid, int expected)
    {
        var sol = new Solution();

        var result = sol.NumIslands(grid);

        Assert.Equal(expected, result);
    }
}
