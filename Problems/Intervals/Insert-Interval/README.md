# Insert Interval:

This directory contains an implementation of the "Insert Interval" problem in C#. The implementation merges a new interval into a sorted non-overlapping list with temporal complexity `O(n)`.

## Problem description

You are given an array of non-overlapping intervals `intervals` where `intervals[i] = [starti, endi]` represent the start and the end of the `i`-th interval and `intervals` is sorted in ascending order by `starti`. You are also given an interval `newInterval = [start, end]` that represents the start and end of another interval.

Insert `newInterval` into `intervals` such that `intervals` is still sorted in ascending order by `starti` and `intervals` still does not have any overlapping intervals (merge overlapping intervals if necessary).

Return `intervals` after the insertion.

- Example 1:

```
Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
Output: [[1,5],[6,9]]
```

- Example 2:

```
Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
Output: [[1,2],[3,10],[12,16]]
```

## Solution:

Walk the existing intervals once and classify each relative to `newInterval = [start, end]`:

1. Completely to the left → keep as-is
2. Completely to the right → first emit the (possibly merged) new interval, then keep
3. Overlaps → expand `start`/`end` to cover both
4. After the scan, if the new interval was never emitted, append it

Because the input is already sorted and non-overlapping, one linear pass is enough.

Let's go through `[[1,3],[6,9]]`, new `[2,5]`:

1. `[1,3]` overlaps `[2,5]` → merge to `[1,5]`
2. `[6,9]` is fully to the right → emit `[1,5]`, then `[6,9]`
3. Result: `[[1,5],[6,9]]`

## Implementations:

### C# :

```csharp
// Using linear search technique - Time: O(n)

public class Solution
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        List<int[]> ans = new List<int[]>();
        int start = newInterval[0];
        int end = newInterval[1];

        foreach (int[] interval in intervals)
        {
            if (start > end)
            {
                ans.Add(interval);
            }
            else if (interval[1] < start)
            {
                ans.Add(interval);
            }
            else if (interval[0] > end)
            {
                ans.Add(new int[] { start, end });
                start = end + 1;
                ans.Add(interval);
            }
            else
            {
                start = Math.Min(start, interval[0]);
                end = Math.Max(end, interval[1]);
            }
        }

        if (start <= end)
        {
            ans.Add(new int[] { start, end });
        }

        return ans.ToArray();
    }
}
```

1. `public class Solution` : Define a public class called `Solution`.

2. `public int[][] Insert(...)` : Insert and merge `newInterval` into sorted intervals.

3. `start`/`end` track the interval still being merged.

4. Cases: already inserted (`start > end`), left of new, right of new, or overlapping merge.

5. Append remaining merged interval if needed and return the array.
