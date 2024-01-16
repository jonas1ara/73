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

class Program
{
    static void Main()
    {
        // Ejemplo de uso
        WordDictionary wordDictionary = new WordDictionary();
        wordDictionary.AddWord("bad");
        wordDictionary.AddWord("dad");
        wordDictionary.AddWord("mad");

        bool param_1 = wordDictionary.Search("pad"); // Debería ser false
        bool param_2 = wordDictionary.Search("bad"); // Debería ser true
        bool param_3 = wordDictionary.Search(".ad"); // Debería ser true
        bool param_4 = wordDictionary.Search("b.."); // Debería ser true

        // Mostrar resultados
        Console.WriteLine("Search('pad'): " + param_1);
        Console.WriteLine("Search('bad'): " + param_2);
        Console.WriteLine("Search('.ad'): " + param_3);
        Console.WriteLine("Search('b..'): " + param_4);
    }
}
