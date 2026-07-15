public class WordSearchIITests
{
    private static char[][] BuildBoard(string[] rows)
    {
        var board = new char[rows.Length][];
        for (int i = 0; i < rows.Length; i++)
        {
            board[i] = rows[i].ToCharArray();
        }
        return board;
    }

    [Fact]
    public void FindWords_OfficialExample_ReturnsMatchingWords()
    {
        var board = BuildBoard(new[] { "oaan", "etae", "ihkr", "iflv" });
        var words = new[] { "oath", "pea", "eat", "rain" };
        var sol = new Solution();

        var result = sol.FindWords(board, words);

        Assert.Equal(new[] { "eat", "oath" }, result.OrderBy(w => w));
    }

    [Fact]
    public void FindWords_WordRequiresReusingCell_ReturnsEmpty()
    {
        var board = BuildBoard(new[] { "ab", "cd" });
        var words = new[] { "abcb" };
        var sol = new Solution();

        var result = sol.FindWords(board, words);

        Assert.Empty(result);
    }

    [Fact]
    public void FindWords_NoWordsProvided_ReturnsEmpty()
    {
        var board = BuildBoard(new[] { "ab", "cd" });
        var sol = new Solution();

        var result = sol.FindWords(board, Array.Empty<string>());

        Assert.Empty(result);
    }
}
