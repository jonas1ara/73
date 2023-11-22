using System;
using System.Collections.Generic;
using System.Linq;

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
        if (p == q) return;
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
        // Ejemplo de uso
        Solution solution = new Solution();
        int n = 5;
        int[][] edges = { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 3, 4 } };
        //int[][] edges = { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 3, 4 } };
        int result = solution.CountComponents(n, edges);

        Console.WriteLine("Number of Connected Components: " + result);
    }
}
