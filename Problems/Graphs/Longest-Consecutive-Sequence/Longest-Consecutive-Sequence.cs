﻿using System;
using System.Collections.Generic;
using System.Linq;

// Using union find algorithm - Time: O(n)

public class UnionFind
{
    private int[] id;
    private int[] size;

    public UnionFind(int n)
    {
        id = new int[n];
        size = new int[n];

        for (int i = 0; i < n; i++)
        {
            id[i] = i;
            size[i] = 1;
        }
    }

    public void Connect(int a, int b)
    {
        int x = Find(a);
        int y = Find(b);
        if (x == y) return;
        id[x] = y;
        size[y] += size[x];
    }

    public int Find(int a)
    {
        return id[a] == a ? a : (id[a] = Find(id[a]));
    }

    public int[] GetSizes()
    {
        return size;
    }
}

public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        if (nums.Length == 0) return 0;

        UnionFind uf = new UnionFind(nums.Length);
        Dictionary<int, int> m = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int n = nums[i];
            if (m.ContainsKey(n)) continue;
            m[n] = i;
            if (m.ContainsKey(n + 1)) uf.Connect(m[n], m[n + 1]);
            if (m.ContainsKey(n - 1)) uf.Connect(m[n], m[n - 1]);
        }

        return uf.GetSizes().Max();
    }
}

class Program
{
    static void Main()
    {
        int[] nums = { 0,3,7,2,5,8,4,6,0,1 };
        Console.WriteLine("Input: [" + string.Join(",", nums) + "]");

        Solution sol = new Solution();
        int result = sol.LongestConsecutive(nums);

        Console.WriteLine("Output: " + result);
    }
}