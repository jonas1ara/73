using System;
using System.Collections.Generic;

// Using a Trie - Time: AddWord: O(n) and Search: O(m)

public class TrieNode
{
    public TrieNode[] Next = new TrieNode[26];
    public bool End = false;
}

public class WordDictionary
{
    private TrieNode root;

    public WordDictionary()
    {
        root = new TrieNode();
    }

    public void AddWord(string word)
    {
        var node = root;
        foreach (char c in word)
        {
            if (node.Next[c - 'a'] == null)
                node.Next[c - 'a'] = new TrieNode();
            node = node.Next[c - 'a'];
        }
        node.End = true;
    }

    private bool Dfs(TrieNode node, string word, int i)
    {
        if (node == null)
            return false;
        if (i == word.Length)
            return node.End;
        if (word[i] != '.')
            return Dfs(node.Next[word[i] - 'a'], word, i + 1);

        for (int j = 0; j < 26; j++)
        {
            if (Dfs(node.Next[j], word, i + 1))
            {
                return true;
            }
        }
        return false;
    }

    public bool Search(string word)
    {
        return Dfs(root, word, 0);
    }
}

class Program
{
    static List<bool?> PerformOperations(List<string> operations, List<List<string>> inputs)
    {
        WordDictionary wordDictionary = null;
        List<bool?> results = new List<bool?>();

        for (int i = 0; i < operations.Count; i++)
        {
            if (operations[i] == "WordDictionary")
            {
                wordDictionary = new WordDictionary();
                results.Add(null);
            }
            else if (operations[i] == "addWord")
            {
                wordDictionary.AddWord(inputs[i][0]);
                results.Add(null);
            }
            else if (operations[i] == "search")
            {
                results.Add(wordDictionary.Search(inputs[i][0]));
            }
        }

        return results;
    }

    static void Main()
    {
        List<string> operations = new List<string> { "WordDictionary", "addWord", "addWord", "addWord", "search", "search", "search", "search" };
        List<List<string>> inputs = new List<List<string>> { new List<string>(), new List<string> { "bad" }, new List<string> { "dad" }, new List<string> { "mad" }, new List<string> { "pad" }, new List<string> { "bad" }, new List<string> { ".ad" }, new List<string> { "b.." } };

        List<bool?> results = PerformOperations(operations, inputs);

        for (int i = 0; i < results.Count; i++)
        {
            Console.Write("Operation: " + operations[i]);
            if (inputs[i].Count > 0)
            {
                Console.Write(", Input: " + inputs[i][0]);
            }

            if (operations[i] == "WordDictionary")
            {
                Console.WriteLine(", Result: null");
            }
            else if (operations[i] == "addWord")
            {
                Console.WriteLine(", Result: null");
            }
            else if (operations[i] == "search")
            {
                Console.WriteLine(", Result: " + (results[i] ?? false));
            }
        }
    }
}
