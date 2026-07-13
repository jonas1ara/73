# Search in Rotated Sorted Array:

This directory contains implementations of the "Search in Rotated Sorted Array" problem in the C++ and C# languages. Each implementation uses binary search twice (find pivot, then search) and maintain a temporal complexity of `O(log n)`.

## Problem description

There is an integer array `nums` sorted in ascending order (with distinct values).

Prior to being passed to your function, `nums` is possibly rotated at an unknown pivot index `k` (`1 <= k < nums.length`) such that the resulting array is `[nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]]` (0-indexed). For example, `[0,1,2,4,5,6,7]` might be rotated at pivot index `3` and become `[4,5,6,7,0,1,2]`.

Given the array `nums` after the possible rotation and an integer `target`, return the index of `target` if it is in `nums`, or `-1` if it is not in `nums`.

You must write an algorithm with `O(log n)` runtime complexity.

- Example 1:

```
Input: nums = [4,5,6,7,0,1,2], target = 0
Output: 4
```

- Example 2:

```
Input: nums = [4,5,6,7,0,1,2], target = 3
Output: -1
```

- Example 3:

```
Input: nums = [1], target = 0
Output: -1
```

## Solution:

Because the array is rotated, a single standard binary search needs care. This solution does it in two binary-search phases:

1. **Find the pivot** (index of the minimum element), same idea as "Find Minimum in Rotated Sorted Array"
2. **Binary search as if the array were unrotated**, mapping virtual mid indices with `(m + pivot) % n`

That keeps both phases logarithmic.

Let's go through `nums = {4, 5, 6, 7, 0, 1, 2}`, `target = 0`:

1. Find pivot:
    - Eventually `left` lands on index `4` where `nums[4] = 0`
    - `pivot = 4`

2. Search with mapped indices:
    - Virtual mid maps to real index `mm = (m + pivot) % n`
    - Eventually finds `nums[4] == 0` and returns `4`

If the target is not present, binary search ends with `-1`.

## Implementations:

### C# :

```csharp
// Using binary search technique - Time: O(log n)

public class Solution
{
    public int Search(int[] nums, int target)
    {
        if (nums.Length == 0)
            return -1;

        int n = nums.Length, left = 0, right = n - 1, pivot;

        while (left < right)
        {
            int m = left + (right - left) / 2;

            if (nums[m] < nums[right])
                right = m;
            else
                left = m + 1;
        }
        pivot = left;
        left = 0;
        right = n - 1;

        while (left <= right)
        {
            int m = left + (right - left) / 2;
            int mm = (m + pivot) % n;

            if (nums[mm] == target)
                return mm;
            if (target > nums[mm])
                left = m + 1;
            else
                right = m - 1;
        }

        return -1;
    }
}
```

1. `public class Solution` : Define a public class called `Solution`.

2. `public int Search(int[] nums, int target)` : Define a public method that returns the index of `target` in a rotated sorted array, or `-1`.

3. `if (nums.Length == 0) return -1;` : Handle the empty array edge case.

4. First `while` loop: binary search for the pivot (minimum element index).

5. `pivot = left;` : Store the rotation point.

6. Second `while` loop: binary search on the logical unrotated order.

7. `int mm = (m + pivot) % n;` : Map the virtual mid index to the real rotated index.

8. Compare `nums[mm]` with `target` and shrink the virtual search range.

9. `return -1;` : Target was not found.

### C++ :

```cpp
// Using binary search technique - Time: O(log n)

class Solution {
public:
    int search(std::vector<int> &nums, int target)
    {
        if (nums.empty())
            return -1;

        int n = nums.size(), left = 0, right = n - 1, pivot;
        
        while (left < right)
        {
            int m = left + (right - left) / 2;
            if (nums[m] < nums[right])
                right = m;
            else
                left = m + 1;
        }
        
        pivot = left;
        left = 0, right = n - 1;

        while (left <= right)
        {
            int m = left + (right - left) / 2; 
            int mm = (m + pivot) % n;
            
            if (nums[mm] == target)
                return mm;

            if (target > nums[mm])
                left = m + 1;
            else
                right = m - 1;
        }

        return -1;
    }
};
```

1. `class Solution {public: ...};` : Define a public class called `Solution`.

2. `int search(std::vector<int> &nums, int target)` : Define a function that returns the index of `target`, or `-1`.

3. Find the pivot with binary search, then search with modular index mapping.

4. `return -1;` if the target is not present.
