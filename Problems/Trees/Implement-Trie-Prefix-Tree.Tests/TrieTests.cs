public class TrieTests
{
    [Fact]
    public void InsertSearchStartsWith_MatchesLeetCodeExample()
    {
        var trie = new Trie();
        trie.Insert("apple");

        Assert.True(trie.Search("apple"));
        Assert.False(trie.Search("app"));
        Assert.True(trie.StartsWith("app"));

        trie.Insert("app");

        Assert.True(trie.Search("app"));
    }

    [Fact]
    public void Search_EmptyTrie_ReturnsFalse()
    {
        var trie = new Trie();

        Assert.False(trie.Search("anything"));
        Assert.False(trie.StartsWith("a"));
    }

    [Fact]
    public void StartsWith_PrefixOfInsertedWord_ReturnsTrue()
    {
        var trie = new Trie();
        trie.Insert("banana");

        Assert.True(trie.StartsWith("ban"));
        Assert.True(trie.StartsWith("banana"));
        Assert.False(trie.StartsWith("bananas"));
    }

    [Fact]
    public void Search_IsCaseSensitiveToExactWord()
    {
        var trie = new Trie();
        trie.Insert("cat");
        trie.Insert("car");

        Assert.True(trie.Search("cat"));
        Assert.True(trie.Search("car"));
        Assert.False(trie.Search("ca"));
    }
}
