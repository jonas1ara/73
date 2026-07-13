# Merge Intervals:

This directory contains implementations of the "Merge Intervals" problem in the C, C++, and C# languages. Each implementation sorts intervals and merges overlaps with temporal complexity `O(n log n)`.

## Problem description

Given an array of `intervals` where `intervals[i] = [starti, endi]`, merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input.

- Example 1:

```
Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
Output: [[1,6],[8,10],[15,18]]
Explanation: Since intervals [1,3] and [2,6] overlap, merge them into [1,6].
```

- Example 2:

```
Input: intervals = [[1,4],[4,5]]
Output: [[1,5]]
Explanation: Intervals [1,4] and [4,5] are considered overlapping.
```

## Solution:

1. Sort intervals by start time
2. Keep a list `merged`; start with the first interval
3. For each next interval:
   - If it starts after the last merged end → push as a new interval
   - Else extend the last merged end to `max(ends)`

Sorting is the bottleneck (`O(n log n)`); the merge pass is linear.

Let's go through `[[1,3],[2,6],[8,10],[15,18]]`:

1. Sorted (already)
2. `[1,3]` then `[2,6]` overlaps → merge to `[1,6]`
3. `[8,10]` no overlap → append
4. `[15,18]` no overlap → append
5. Result: `[[1,6],[8,10],[15,18]]`

## Implementations:

### C# :

```csharp
// Using merge and quick sort - Time: O(nlogn)

public class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        if (intervals.Length == 0)
        {
            return new int[0][];
        }

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        List<int[]> merged = new List<int[]>();
        merged.Add(intervals[0]);

        for (int i = 1; i < intervals.Length; i++)
        {
            if (merged.Last()[1] < intervals[i][0])
            {
                merged.Add(intervals[i]);
            }
            else
            {
                merged.Last()[1] = Math.Max(merged.Last()[1], intervals[i][1]);
            }
        }

        return merged.ToArray();
    }
}
```

1. Sort by start time.

2. Seed `merged` with the first interval.

3. Non-overlap → append; overlap → extend last end.

4. Return the merged array.

### C++ :

```cpp
// Using merge and quick sort - Time: O(nlogn)

class Solution {
public:
    std::vector<std::vector<int>> merge(std::vector<std::vector<int>> &intervals)
    {
        if (intervals.empty())
        {
            return {};
        }

        sort(intervals.begin(), intervals.end());

        std::vector<std::vector<int>> merged;
        merged.push_back(intervals[0]);

        for (int i = 1; i < intervals.size(); i++)
        {
            if (merged.back()[1] < intervals[i][0])
            {
                merged.push_back(intervals[i]);
            }
            else
            {
                merged.back()[1] = std::max(merged.back()[1], intervals[i][1]);
            }
        }

        return merged;
    }
};
```

1. Empty input → empty output.

2. Sort and merge consecutive overlaps as above.

### C:

```c
// Using merge and quick sort - Time: O(nlogn)

int compare(const void *a, const void *b)
{
    int *intervalA = *(int **)a;
    int *intervalB = *(int **)b;
    return intervalA[0] - intervalB[0];
}

int **merge(int **intervals, int intervalsSize, int *intervalsColSize, int *returnSize, int **returnColumnSizes)
{
    if (intervalsSize == 0)
    {
        *returnSize = 0;
        return NULL;
    }

    qsort(intervals, intervalsSize, sizeof(int *), compare);

    int **merged = malloc(intervalsSize * sizeof(int *));
    *returnColumnSizes = malloc(intervalsSize * sizeof(int));
    merged[0] = intervals[0];
    (*returnColumnSizes)[0] = 2;
    *returnSize = 1;

    for (int i = 1; i < intervalsSize; i++)
    {
        if (merged[*returnSize - 1][1] < intervals[i][0])
        {
            merged[*returnSize] = intervals[i];
            (*returnColumnSizes)[*returnSize] = 2;
            ++(*returnSize);
        }
        else
        {
            if (intervals[i][1] > merged[*returnSize - 1][1])
                merged[*returnSize - 1][1] = intervals[i][1];
        }
    }

    return merged;
}
```

1. `qsort` by start via `compare`.

2. Grow `merged` the same way as C++/C#.

3. Set `returnSize` and column sizes for the LeetCode C interface.
