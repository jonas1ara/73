# Non-overlapping Intervals:

This directory contains an implementation of the "Non-overlapping Intervals" problem in C#. The implementation uses a greedy sort-by-end strategy with temporal complexity `O(n log n)`.

## Problem description

Given an array of intervals `intervals` where `intervals[i] = [starti, endi]`, return the minimum number of intervals you need to remove to make the rest of the intervals non-overlapping.

- Example 1:

```
Input: intervals = [[1,2],[2,3],[3,4],[1,3]]
Output: 1
Explanation: Remove [1,3] and the rest are non-overlapping.
```

- Example 2:

```
Input: intervals = [[1,2],[1,2],[1,2]]
Output: 2
Explanation: You need to remove two [1,2] to make the rest non-overlapping.
```

- Example 3:

```
Input: intervals = [[1,2],[2,3]]
Output: 0
```

## Solution:

This is the classic interval scheduling greedy idea inverted:

1. Sort intervals by **end time** ascending
2. Keep a running `end` of the last kept interval
3. If the next interval starts at or after `end`, keep it and update `end`
4. Otherwise it overlaps → count one removal (`ans++`)

Sorting by end maximizes how many intervals you can keep, so removals are minimized.

Let's go through `[[1,2],[2,3],[3,4],[1,3]]` sorted by end: `[[1,2],[1,3],[2,3],[3,4]]` wait — by end: `[1,2],[2,3],[1,3],[3,4]` depending on ties:

1. Keep `[1,2]`, end = 2
2. `[2,3]` starts at 2 ≥ end → keep, end = 3
3. `[1,3]` starts at 1 < 3 → remove
4. `[3,4]` starts at 3 ≥ end → keep
5. Removals: `1`

## Implementations:

### C# :

```csharp
// Using a greedy algorithm - Time: O(nlogn)

public class Solution
{
    public int EraseOverlapIntervals(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));

        int ans = 0;
        int end = int.MinValue;

        foreach (var i in intervals)
        {
            if (i[0] >= end)
                end = i[1];
            else
                ans++;
        }

        return ans;
    }
}
```

1. Sort by end time.

2. `end` tracks the finish of the last kept interval.

3. Keep if `i[0] >= end`, else increment removal count.

4. `return ans;` minimum removals.

### F# :

```fsharp
open System

type Solution() =
    member this.EraseOverlapIntervals(intervals: int[][]) =
        Array.Sort(intervals, fun a b -> compare a.[1] b.[1])

        let mutable ans = 0
        let mutable endVar = Int32.MinValue

        for i in intervals do
            if i.[0] >= endVar then
                endVar <- i.[1]
            else
                ans <- ans + 1

        ans
```

1. `type Solution() =` : Define a class-like type called `Solution`.

2. `Array.Sort(intervals, fun a b -> compare a.[1] b.[1])` : Sort in place with an inline comparator lambda instead of a `Comparison<T>` delegate.

3. `endVar` is named to avoid shadowing the `end` keyword reserved by F#'s offside/verbose syntax.

4. `for i in intervals do` : Iterate the sorted intervals directly (no index needed).

5. `endVar <- i.[1]` / `ans <- ans + 1` : Both bindings are `mutable`, updated with `<-` as the greedy scan keeps or drops each interval.

6. `ans` : Last expression of the member, returned implicitly as the minimum number of removals.
