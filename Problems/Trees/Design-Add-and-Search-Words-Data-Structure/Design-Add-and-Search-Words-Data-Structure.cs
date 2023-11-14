/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */

public class TrieNode
{
    public TrieNode[] Next { get; } = new TrieNode[26];
    public bool End { get; set; }
}

public class WordDictionary
{
    private TrieNode root = new TrieNode();

    private bool DFS(TrieNode node, string word, int i)
    {
        if (node == null) return false;
        if (i == word.Length) return node.End;
        if (word[i] != '.') return DFS(node.Next[word[i] - 'a'], word, i + 1);

        for (int j = 0; j < 26; ++j)
        {
            if (DFS(node.Next[j], word, i + 1)) return true;
        }
        return false;
    }

    public void AddWord(string word)
    {
        var node = root;
        foreach (char c in word)
        {
            if (node.Next[c - 'a'] == null) node.Next[c - 'a'] = new TrieNode();
            node = node.Next[c - 'a'];
        }
        node.End = true;
    }

    public bool Search(string word)
    {
        return DFS(root, word, 0);
    }
}

