# Find Minimum in Rotated Sorted Array:

This directory contains an implementation of the "Find Minimum in Rotated Sorted Array" problem in C#. The implementation uses binary search to find the minimum element and maintain a temporal complexity of `O(log n)`.

## Problem description

Suppose an array of length `n` sorted in ascending order is rotated between `1` and `n` times. For example, the array `nums = [0,1,2,4,5,6,7]` might become:

- `[4,5,6,7,0,1,2]` if it was rotated `4` times
- `[0,1,2,4,5,6,7]` if it was rotated `7` times

Notice that rotating an array `[a[0], a[1], a[2], ..., a[n-1]]` 1 time results in the array `[a[n-1], a[0], a[1], a[2], ..., a[n-2]]`.

Given the sorted rotated array `nums` of unique elements, return the minimum element of this array.

You must write an algorithm that runs in `O(log n)` time.

- Example 1:

```
Input: nums = [3,4,5,1,2]
Output: 1
Explanation: The original array was [1,2,3,4,5] rotated 3 times.
```

- Example 2:

```
Input: nums = [4,5,6,7,0,1,2]
Output: 0
```

- Example 3:

```
Input: nums = [11,13,15,17]
Output: 11
Explanation: The original array was [11,13,15,17] and it was rotated 4 times.
```

## Solution:

A linear scan finds the minimum in `O(n)`, but the array is sorted then rotated, so binary search still works.

Key observation: compare the middle element with the rightmost element.

- If `nums[m] > nums[right]`, the rotation pivot is to the right of `m`, so move `left = m + 1`
- Otherwise the minimum is at `m` or to its left, so move `right = m`

When `left == right`, that index holds the minimum.

Let's go through `nums = {3, 4, 5, 1, 2}`:

1. `left = 0`, `right = 4`
2. `m = 2`, `nums[2] = 5`, `nums[4] = 2` → `5 > 2` → `left = 3`
3. `m = 3`, `nums[3] = 1`, `nums[4] = 2` → `1 < 2` → `right = 3`
4. `left == right == 3` → minimum is `nums[3] = 1`

## Implementations:

### C# :

```csharp
// Using binary search technique - Time O(log n)

public class Solution
{
    public int FindMin(int[] nums)
    {
        int left = 0, right = nums.Length - 1;

        while (left < right)
        {
            int m = (left + right) / 2;

            if (nums[m] > nums[right])
            {
                left = m + 1;
            }
            else
            {
                right = m;
            }
        }

        return nums[left];
    }
}
```

1. `public class Solution` : Define a public class called `Solution`.

2. `public int FindMin(int[] nums)` : Define a public method that returns the minimum value in a rotated sorted array.

3. `int left = 0, right = nums.Length - 1;` : Initialize the binary search bounds.

4. `while (left < right)` : Continue while the search range has more than one element.

5. `int m = (left + right) / 2;` : Compute the middle index.

6. `if (nums[m] > nums[right]) left = m + 1;` : The minimum is strictly to the right of `m`.

7. `else right = m;` : The minimum is at `m` or to its left.

8. `return nums[left];` : When the range collapses, return the minimum.

## Suggested practice 🎯

Same binary search on rotated arrays pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Find Minimum in Rotated Sorted Array II](https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii/)
- [Search in Rotated Sorted Array II](https://leetcode.com/problems/search-in-rotated-sorted-array-ii/)
- [Find Peak Element](https://leetcode.com/problems/find-peak-element/)
