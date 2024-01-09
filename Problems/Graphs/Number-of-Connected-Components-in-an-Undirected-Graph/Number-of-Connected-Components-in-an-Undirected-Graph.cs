using System;
using System.Linq;
using System.Collections.Generic;

// Using Union find algorithm - Time: O(V + E)

public class UnionFind
{
    private int[] id;
    private int cnt;

    public UnionFind(int n)
    {
        cnt = n;
        id = Enumerable.Range(0, n).ToArray();
    }

    public int Find(int a)
    {
        return id[a] == a ? a : (id[a] = Find(id[a]));
    }

    public void Connect(int a, int b)
    {
        int p = Find(a);
        int q = Find(b);

        if (p == q) 
            return;
        id[p] = q;

        cnt--;
    }

    public int GetCount()
    {
        return cnt;
    }
}

public class Solution
{
    public int CountComponents(int n, int[][] edges)
    {
        UnionFind uf = new UnionFind(n);
        foreach (var e in edges)
        {
            uf.Connect(e[0], e[1]);
        }
        
        return uf.GetCount();
    }
}

class Program
{
    static void Main()
    {
        int n = 5;
        int[][] edges = { 
            new int[] { 0, 1 }, 
            new int[] { 1, 2 }, 
            new int[] { 3, 4 } 
        };

        Console.Write("Input: n = {0}, edges = [", n);
        for (int i = 0; i < edges.Length; i++)
        {
            Console.Write("[{0}, {1}]", edges[i][0], edges[i][1]);
            if (i < edges.Length - 1) 
            {
                Console.Write(",");
            }
        }
        Console.WriteLine("]");

        
        // int[][] edges = { 
        //     new int[] { 0, 1 }, 
        //     new int[] { 1, 2 }, 
        //     new int[] { 2, 3 }, 
        //     new int[] { 3, 4 } 
        // };

        Solution sol = new Solution();
        int result = sol.CountComponents(n, edges);

        Console.WriteLine("Output: " + result);
    }
}
