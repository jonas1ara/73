# Find Median from Data Stream:

This directory contains an implementation of the "Find Median from Data Stream" problem in C#. Two heaps (lower half / upper half) support `AddNum` in `O(log n)` and `FindMedian` in `O(1)`.

## Problem description

The median is the middle value in an ordered integer list. If the size of the list is even, there is no middle value, and the median is the mean of the two middle values.

Implement the `MedianFinder` class:

- `MedianFinder()` initializes the `MedianFinder` object
- `void addNum(int num)` adds the integer `num` from the data stream to the data structure
- `double findMedian()` returns the median of all elements so far

- Example 1:

```
Input
["MedianFinder", "addNum", "addNum", "findMedian", "addNum", "findMedian"]
[[], [1], [2], [], [3], []]
Output
[null, null, null, 1.5, null, 2.0]

Explanation
MedianFinder medianFinder = new MedianFinder();
medianFinder.addNum(1);    // arr = [1]
medianFinder.addNum(2);    // arr = [1, 2]
medianFinder.findMedian(); // return 1.5 (i.e., (1 + 2) / 2)
medianFinder.addNum(3);    // arr = [1, 2, 3]
medianFinder.findMedian(); // return 2.0
```

## Solution:

Maintain two ordered multisets / heaps:

- **`sm`** (smaller half): max side holds values ≤ median; size is `gt.Count` or `gt.Count + 1`
- **`gt`** (greater half): min side holds values ≥ median

**AddNum:**

1. If `num` belongs in the upper half (`num > gt.min`), insert into `gt`; if `gt` grows larger than `sm`, move `gt.min` into `sm`
2. Otherwise insert into `sm`; if `sm` has more than one extra element, move `sm.max` into `gt`

**FindMedian:**

- Odd count (`sm` larger): median is `sm.max`
- Even count: average of `sm.max` and `gt.min`

Walk for `1`, then `2`, then `3`:

1. After `1`: `sm = {1}` → median `1`
2. After `2`: `sm = {1}`, `gt = {2}` → median `1.5`
3. After `3`: `sm = {1,2}`, `gt = {3}` → median `2`

## Implementations:

### C# :

```csharp
// Using two heaps - Time: O(log(n))

public class MedianFinder
{
    private SortedSet<(int num, int index)> sm = new SortedSet<(int num, int index)>();
    private SortedSet<(int num, int index)> gt = new SortedSet<(int num, int index)>();
    private int index = 0;

    public void AddNum(int num)
    {
        if (gt.Count > 0 && num > gt.Min.num)
        {
            gt.Add((num, index++));
            if (gt.Count > sm.Count)
            {
                sm.Add(gt.Min);
                gt.Remove(gt.Min);
            }
        }
        else
        {
            sm.Add((num, index++));
            if (sm.Count > gt.Count + 1)
            {
                gt.Add(sm.Max);
                sm.Remove(sm.Max);
            }
        }
    }

    public double FindMedian()
    {
        return sm.Count > gt.Count ? sm.Max.num : (sm.Max.num + gt.Min.num) / 2.0;
    }
}
```

1. Unique `index` allows equal numbers in `SortedSet`.

2. Rebalancing keeps the two halves size-balanced.

## Suggested practice 🎯

Same two-heap balancing pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Sliding Window Median](https://leetcode.com/problems/sliding-window-median/)
- [IPO](https://leetcode.com/problems/ipo/)
- [Kth Largest Element in a Stream](https://leetcode.com/problems/kth-largest-element-in-a-stream/)
