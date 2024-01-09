using System;
using System.Collections.Generic;

// Using depth-first search - Time: O(n)

public class Solution
{
    private List<List<int>> graph;
    private List<int> state; // -1 unvisited, 0 visiting, 1 visited

    private bool dfs(int u, int prev = -1)
    {
        if (state[u] != -1) return state[u] == 1;

        state[u] = 0;
        foreach (int v in graph[u])
        {
            if (prev == v) continue;
            if (!dfs(v, u)) return false;
        }

        state[u] = 1;
        return true;
    }

    public bool ValidTree(int n, int[][] edges)
    {
        graph = new List<List<int>>();
        state = new List<int>();

        for (int i = 0; i < n; i++)
        {
            graph.Add(new List<int>());
            state.Add(-1);
        }

        foreach (var e in edges)
        {
            graph[e[0]].Add(e[1]);
            graph[e[1]].Add(e[0]);
        }

        int cnt = 0;

        for (int i = 0; i < n; i++)
        {
            if (state[i] == 1) 
                continue;
            if (!dfs(i)) 
                return false;
            cnt++;
        }

        return cnt == 1;
    }
}

class Program
{
    static void Main()
    {
        int n = 5;

        int[][] edges = { 
            new int[] { 0, 1 }, 
            new int[] { 0, 2 }, 
            new int[] { 0, 3 }, 
            new int[] { 1, 4 } 
        };

        Console.Write("Input: n = {0}, edges = [", n);
        for (int i = 0; i < edges.Length; i++)
        {
            Console.Write("[{0}, {1}]", edges[i][0], edges[i][1]);
            if (i < edges.Length - 1) 
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");

        Solution sol = new Solution();
        bool result = sol.ValidTree(n, edges);

        Console.WriteLine("Output: {0}", result);
    }
}
