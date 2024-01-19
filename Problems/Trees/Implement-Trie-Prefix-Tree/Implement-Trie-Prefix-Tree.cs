using System;
using System.Collections.Generic;

// Using a Trie - Time O(w) for insert, search and startsWith, where w is the length of the word

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
            {
                return null;
            }

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
            {
                node.Next[c - 'a'] = new TrieNode();
            }

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
    static List<bool> PerformOperations(List<string> operations, List<List<string>> inputs)
    {
        Trie obj = new Trie();
        List<bool> results = new List<bool>();

        for (int i = 0; i < operations.Count; i++)
        {
            if (operations[i] == "Trie")
            {
                obj = new Trie(); 
                results.Add(false); 
            }
            else if (operations[i] == "insert")
            {
                obj.Insert(inputs[i][0]);
                results.Add(false); 
            }
            else if (operations[i] == "search")
            {
                results.Add(obj.Search(inputs[i][0]));
            }
            else if (operations[i] == "startsWith")
            {
                results.Add(obj.StartsWith(inputs[i][0]));
            }
        }

        return results;
    }

    static void Main()
    {
        List<string> operations = new List<string> { "Trie", "insert", "search", "search", "startsWith", "insert", "search" };
        List<List<string>> inputs = new List<List<string>> { new List<string>(), new List<string> { "apple" }, new List<string> { "apple" }, new List<string> { "app" }, new List<string> { "app" }, new List<string> { "app" }, new List<string> { "app" } };

        List<bool> results = PerformOperations(operations, inputs);

        for (int i = 0; i < results.Count; i++)
        {
            Console.Write("Operation: " + operations[i]);
            if (inputs[i].Count > 0)
            {
                Console.Write(", Input: " + inputs[i][0]);
            }

            if (operations[i] == "Trie")
            {
                Console.WriteLine(", Result: Trie initialized.");
            }
            else if (operations[i] == "insert")
            {
                Console.WriteLine(", Result: null");
            }
            else if (operations[i] == "search")
            {
                Console.WriteLine(", Result: " + (results[i] ? "True" : "False"));
            }
            else if (operations[i] == "startsWith")
            {
                Console.WriteLine(", Result: " + (results[i] ? "True" : "False"));
            }
        }
    }
}