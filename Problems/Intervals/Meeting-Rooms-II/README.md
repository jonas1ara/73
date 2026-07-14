# Meeting Rooms II:

This directory contains an implementation of the "Meeting Rooms II" problem in C#. The implementation uses a greedy scan of sorted starts and ends with temporal complexity `O(n log n)`.

## Problem description

Given an array of meeting time intervals consisting of start and end times `[[s1,e1],[s2,e2],...]` (si < ei), find the minimum number of conference rooms required.

- Example 1:

```
Input: intervals = [(0,30),(5,10),(15,20)]
Output: 2
```

- Example 2:

```
Input: intervals = [(2,7)]
Output: 1
```

## Solution:

The number of rooms needed is the maximum number of meetings happening at the same time.

Algorithm:

1. Collect all start times and end times into separate arrays
2. Sort both arrays
3. Sweep with two pointers:
   - If next start is before next end → a new room is needed (`rooms++`)
   - Else a meeting ended → free a room (`endIdx++`)

This is equivalent to a timeline sweep without an explicit priority queue.

Let's go through `[(0,30),(5,10),(15,20)]`:

1. starts = `[0,5,15]`, ends = `[10,20,30]`
2. start `0` < end `10` → rooms = 1
3. start `5` < end `10` → rooms = 2
4. start `15` >= end `10` → free room (endIdx → 1), rooms stay 2
5. Answer: `2`

## Implementations:

### C# :

```csharp
// Using a greedy algorithm - Time: O(nlogn)

public class Interval
{
    public int start, end;
    public Interval(int start, int end)
    {
        this.start = start;
        this.end = end;
    }
}

public class Solution
{
    public int MinMeetingRooms(List<Interval> intervals)
    {
        List<int> starts = new List<int>();
        List<int> ends = new List<int>();

        foreach (Interval interval in intervals)
        {
            starts.Add(interval.start);
            ends.Add(interval.end);
        }

        starts.Sort();
        ends.Sort();

        int rooms = 0;
        int endIdx = 0;

        for (int i = 0; i < intervals.Count; i++)
        {
            if (starts[i] < ends[endIdx])
            {
                rooms++;
            }
            else
            {
                endIdx++;
            }
        }

        return rooms;
    }
}
```

1. Collect and sort start/end times separately.

2. For each start in order, either allocate a new room or reuse a freed one.

3. `return rooms;` is the peak concurrent meetings count.
