/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
**/

public class TrieNode
{
    public TrieNode[] Next { get; } = new TrieNode[26];
    public bool Word { get; set; }
}

public class Trie
{
    private TrieNode root = new TrieNode();

    private TrieNode Find(string word)
    {
        var node = root;
        foreach (char c in word)
        {
            if (node.Next[c - 'a'] == null)
                return null;
            node = node.Next[c - 'a'];
        }
        return node;
    }

    public void Insert(string word)
    {
        var node = root;
        foreach (char c in word)
        {
            if (node.Next[c - 'a'] == null)
                node.Next[c - 'a'] = new TrieNode();
            node = node.Next[c - 'a'];
        }
        node.Word = true;
    }

    public bool Search(string word)
    {
        var node = Find(word);
        return node != null && node.Word;
    }

    public bool StartsWith(string prefix)
    {
        return Find(prefix) != null;
    }
}

