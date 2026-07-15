public class WordDictionaryTests
{
    [Fact]
    public void AddAndSearch_MatchesLeetCodeExample()
    {
        var wordDictionary = new WordDictionary();
        wordDictionary.AddWord("bad");
        wordDictionary.AddWord("dad");
        wordDictionary.AddWord("mad");

        Assert.False(wordDictionary.Search("pad"));
        Assert.True(wordDictionary.Search("bad"));
        Assert.True(wordDictionary.Search(".ad"));
        Assert.True(wordDictionary.Search("b.."));
    }

    [Fact]
    public void Search_WordNotAdded_ReturnsFalse()
    {
        var wordDictionary = new WordDictionary();
        wordDictionary.AddWord("a");

        Assert.False(wordDictionary.Search("b"));
    }

    [Fact]
    public void Search_AllDotsMatchingWordLength_ReturnsTrue()
    {
        var wordDictionary = new WordDictionary();
        wordDictionary.AddWord("word");

        Assert.True(wordDictionary.Search("...."));
    }

    [Fact]
    public void Search_DotPatternWithDifferentLength_ReturnsFalse()
    {
        var wordDictionary = new WordDictionary();
        wordDictionary.AddWord("word");

        Assert.False(wordDictionary.Search("..."));
        Assert.False(wordDictionary.Search("....."));
    }

    [Fact]
    public void Search_PrefixOnlyWithoutFullWord_ReturnsFalse()
    {
        var wordDictionary = new WordDictionary();
        wordDictionary.AddWord("apple");

        Assert.False(wordDictionary.Search("app"));
    }
}
