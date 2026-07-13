# Meeting Rooms:

This directory contains implementations of the "Meeting Rooms" problem in the C++ and C# languages. Each implementation sorts intervals by start time and checks for overlaps with temporal complexity `O(n log n)`.

## Problem description

Given an array of meeting time intervals consisting of start and end times `[[s1,e1],[s2,e2],...]` (si < ei), determine if a person could attend all meetings.

- Example 1:

```
Input: intervals = [(0,30),(5,10),(15,20)]
Output: false
Explanation: (0,30) overlaps with (5,10) and (15,20).
```

- Example 2:

```
Input: intervals = [(5,8),(9,15)]
Output: true
```

## Solution:

A person can attend all meetings if and only if no two intervals overlap.

1. Sort meetings by start time
2. For each consecutive pair, if `start[i] < end[i-1]`, they overlap → return `false`
3. If no pair overlaps → return `true`

Note: touching endpoints like `[1,5]` and `[5,10]` do **not** overlap under the strict `<` check.

Let's go through `[(0,30),(5,10),(15,20)]` sorted by start (already ordered):

1. `(5,10)` starts before `(0,30)` ends → conflict → `false`

## Implementations:

### C# :

```csharp
// Using interval scheduling algorithm - Time: O(nlogn)

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
    public bool CanAttendMeetings(List<Interval> intervals)
    {
        intervals.Sort((a, b) => a.start - b.start);

        for (int i = 1; i < intervals.Count; i++)
        {
            if (intervals[i].start < intervals[i - 1].end)
            {
                return false;
            }
        }

        return true;
    }
}
```

1. `Interval` : Simple start/end structure.

2. `CanAttendMeetings` : Return whether all meetings are non-overlapping.

3. Sort by `start`.

4. If any meeting starts before the previous one ends, return `false`.

5. `return true;` if every consecutive pair is conflict-free.

### C++ :

```cpp
// Using interval scheduling algorithm - Time: O(nlogn)

class Interval {
public:
    int start, end;
    Interval(int start, int end)
    {
        this->start = start;
        this->end = end;
    }
};

class Solution {
public:
    bool canAttendMeetings(std::vector<Interval> &intervals)
    {
        std::sort(intervals.begin(), intervals.end(), [&](Interval &a, Interval &b)
                  { return a.start < b.start; });

        for (int i = 1; i < intervals.size(); i++)
        {
            if (intervals[i].start < intervals[i - 1].end)
                return false;
        }

        return true;
    }
};
```

1. Sort by start time with a lambda comparator.

2. Linear scan for any start that falls inside the previous meeting.

3. `return true;` when no overlaps exist.
