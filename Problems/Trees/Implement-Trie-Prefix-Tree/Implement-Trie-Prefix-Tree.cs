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

class Program
{
    static void Main()
    {
        // Ejemplo de uso
        Trie obj = new Trie();
        obj.Insert("apple");
        bool param_2 = obj.Search("apple");
        bool param_3 = obj.StartsWith("app");

        // Mostrar resultados
        Console.WriteLine("Search('apple'): " + param_2); // Debería ser true
        Console.WriteLine("StartsWith('app'): " + param_3); // Debería ser true
    }
}
