# Top K Frequent Elements:

This directory contains an implementation of the "Top K Frequent Elements" problem in C#. The implementation counts frequencies and keeps a size-`k` min-heap with temporal complexity `O(n log k)`.

## Problem description

Given an integer array `nums` and an integer `k`, return the `k` most frequent elements. You may return the answer in any order.

- Example 1:

```
Input: nums = [1,1,1,2,2,3], k = 2
Output: [1,2]
```

- Example 2:

```
Input: nums = [1], k = 1
Output: [1]
```

## Solution:

1. Count how many times each value appears (`Dictionary` / `unordered_map`)
2. Fast paths: if `nums.Length == k` or there are exactly `k` distinct values, return those values
3. Maintain a min-heap of size at most `k` ordered by frequency
4. For each distinct number, push it; if size exceeds `k`, pop the least frequent
5. The heap then holds the top `k`; extract and reverse for descending frequency order

For `nums = [1,1,1,2,2,3]`, `k = 2`:

1. Counts: `1→3`, `2→2`, `3→1`
2. Heap keeps `1` and `2` (frequencies 3 and 2); `3` is popped
3. Output: `[1,2]`

## Implementations:

### C# :

```csharp
// Using a heap - Time complexity: O(n log k)

public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        if (nums.Length == k) return nums;
        var cnt = new Dictionary<int, int>();

        foreach (int n in nums)
        {
            if (cnt.ContainsKey(n)) cnt[n]++;
            else cnt.Add(n, 1);
        }

        List<int> ans = new List<int>();

        if (cnt.Count == k)
        {
            foreach (var item in cnt) ans.Add(item.Key);
            return ans.ToArray();
        }

        var cmp = Comparer<int>.Create((a, b) =>
            cnt[a] != cnt[b] ? cnt[a].CompareTo(cnt[b]) : a.CompareTo(b));
        var ss = new SortedSet<int>(cmp);

        foreach (var item in cnt)
        {
            ss.Add(item.Key);
            if (ss.Count > k) ss.Remove(ss.Min);
        }
        while (ss.Count > 0)
        {
            ans.Add(ss.Min);
            ss.Remove(ss.Min);
        }

        ans.Reverse();
        return ans.ToArray();
    }
}
```

1. `SortedSet` acts as a min-heap ordered by frequency.

2. Removing `Min` when size `> k` drops the least frequent key.

## Suggested practice 🎯

Same heap/bucket selection pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Kth Largest Element in an Array](https://leetcode.com/problems/kth-largest-element-in-an-array/)
- [Top K Frequent Words](https://leetcode.com/problems/top-k-frequent-words/)
- [Sort Characters By Frequency](https://leetcode.com/problems/sort-characters-by-frequency/)
