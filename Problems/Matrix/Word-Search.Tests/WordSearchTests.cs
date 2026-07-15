public class WordSearchTests
{
    private static char[][] Board() => new char[][]
    {
        new char[] { 'A', 'B', 'C', 'E' },
        new char[] { 'S', 'F', 'C', 'S' },
        new char[] { 'A', 'D', 'E', 'E' },
    };

    public static IEnumerable<object[]> ExistCases()
    {
        yield return new object[] { Board(), "ABCCED", true };
        yield return new object[] { Board(), "SEE", true };
        yield return new object[] { Board(), "ABCB", false };
        yield return new object[] { new char[][] { new char[] { 'A' } }, "A", true };
        yield return new object[] { new char[][] { new char[] { 'A' } }, "B", false };
    }

    [Theory]
    [MemberData(nameof(ExistCases))]
    public void Exist_FindsWordInBoard(char[][] board, string word, bool expected)
    {
        var sol = new Solution();

        var result = sol.Exist(board, word);

        Assert.Equal(expected, result);
    }
}
