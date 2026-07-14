# Number of Connected Components in an Undirected Graph:

This directory contains an implementation of the "Number of Connected Components in an Undirected Graph" problem in C#. The implementation uses Union-Find (Disjoint Set Union) with temporal complexity nearly `O(V + E)` with path compression.

> Premium problem (LeetCode 323). Description included for offline study.

## Problem description

You have a graph of `n` nodes. You are given an integer `n` and an array `edges` where `edges[i] = [ai, bi]` indicates that there is an edge between `ai` and `bi` in the graph.

Return the number of connected components in the graph.

- Example 1:

```
Input: n = 5, edges = [[0,1],[1,2],[3,4]]
Output: 2
```

- Example 2:

```
Input: n = 5, edges = [[0,1],[1,2],[2,3],[3,4]]
Output: 1
```

## Solution:

Start with `n` components (each node alone). For every edge, union the two endpoints; each successful union merges two components and decrements the count by one.

```
count = n
for each edge (a, b):
    if Find(a) != Find(b):
        union them
        count--
return count
```

Path compression in `Find` keeps the structure flat for near-constant-time operations.

For `n = 5`, edges `[[0,1],[1,2],[3,4]]`:

1. Union `0-1` → 4 components
2. Union `1-2` → 3 components
3. Union `3-4` → 2 components
4. Answer: `2`

## Implementations:

### C# :

```csharp
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
```

1. `Find` uses path compression (`id[a] = Find(id[a])`).

2. Only distinct roots trigger a component decrement.

## Suggested practice 🎯

Same union-find pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Number of Provinces](https://leetcode.com/problems/number-of-provinces/)
- [Redundant Connection](https://leetcode.com/problems/redundant-connection/)
- [Accounts Merge](https://leetcode.com/problems/accounts-merge/)
