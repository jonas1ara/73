# Longest Consecutive Sequence:

This directory contains an implementation of the "Longest Consecutive Sequence" problem in C#. The implementation uses Union-Find to merge neighboring values with temporal complexity `O(n)`.

## Problem description

Given an unsorted array of integers `nums`, return the length of the longest consecutive elements sequence.

You must write an algorithm that runs in `O(n)` time.

- Example 1:

```
Input: nums = [100,4,200,1,3,2]
Output: 4
Explanation: The longest consecutive sequence is [1, 2, 3, 4]. Therefore its length is 4.
```

- Example 2:

```
Input: nums = [0,3,7,2,5,8,4,6,0,1]
Output: 9
```

## Solution:

Treat each unique value as a node. When `n - 1` or `n + 1` is already present, union them into the same component. Component size is the length of that consecutive run.

1. Map each value → index (skip duplicates)
2. For each new value `n`, if `n+1` or `n-1` exists in the map, connect those indices in the Union-Find
3. Track sizes on each root; answer is the maximum size

For `nums = [100,4,200,1,3,2]`:

1. Insert `100`, `4`, `200`
2. Insert `1` → later connect with `2`
3. Insert `3` → connect with `4` and `2`
4. Component `{1,2,3,4}` has size `4`

## Implementations:

### C# :

```csharp
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
```

1. Value→index map enables neighbor lookups in average `O(1)`.

2. Union-by-size accumulates sequence lengths on roots.

## Suggested practice 🎯

Same hash-set range expansion pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Binary Tree Longest Consecutive Sequence](https://leetcode.com/problems/binary-tree-longest-consecutive-sequence/)
- [Binary Tree Longest Consecutive Sequence II](https://leetcode.com/problems/binary-tree-longest-consecutive-sequence-ii/)
- [First Missing Positive](https://leetcode.com/problems/first-missing-positive/)
