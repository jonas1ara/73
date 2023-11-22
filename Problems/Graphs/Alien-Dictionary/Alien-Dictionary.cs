using System;
using System.Collections.Generic;
public class Solution
{
    private Dictionary<int, HashSet<int>> graph;
    private int[] state;
    private string ans;

    private bool DFS(int u)
    {
        if (state[u] == 0) return false; // Cycle detected
        if (state[u] == 1) return true;  // Node visited

        state[u] = 0;
        foreach (int v in graph[u])
        {
            if (!DFS(v)) return false;
        }

        ans += (char)('a' + u);
        state[u] = 1;
        return true;
    }

    public Solution()
    {
        // -1: Not visited, 0: Visiting, 1: Visited
        state = Enumerable.Repeat(-1, 26).ToArray();
        graph = new Dictionary<int, HashSet<int>>();
    }

    public string AlienOrder(string[] words)
    {
        foreach (var s in words)
        {
            foreach (char c in s)
            {
                graph[c - 'a'] = new HashSet<int>();
            }
        }

        for (int i = 1; i < words.Length; i++)
        {
            int j = 0;
            for (; j < Math.Min(words[i - 1].Length, words[i].Length); j++)
            {
                if (words[i - 1][j] == words[i][j]) continue;
                graph[words[i - 1][j] - 'a'].Add(words[i][j] - 'a');
                break;
            }
            if (j == words[i].Length && j < words[i - 1].Length) return ""; 
        }

        foreach (var entry in graph)
        {
            if (!DFS(entry.Key)) return ""; 
        }

        char[] ansArray = ans.ToCharArray();
        Array.Reverse(ansArray);
        return ansArray.Length == graph.Count ? new string(ansArray) : ""; // All nodes visited
    }
}

class Program
{
    static void Main()
    {
        Solution sol = new Solution();
        //string[] words = { "wrt", "wrf", "er", "ett", "rftt" };
        string[] words = { "z", "x" };
        string result = sol.AlienOrder(words);

        Console.WriteLine("Alien Order: " + result);
    }
}
