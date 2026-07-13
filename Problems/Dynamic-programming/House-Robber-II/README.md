# House Robber II:

This directory contains implementations of the "House Robber II" problem in the C++ and C# languages. Each implementation reduces the circular street to two linear House Robber subproblems with temporal complexity `O(n)`.

## Problem description

You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed. All houses at this place are arranged in a circle. That means the first house is the neighbor of the last one. Meanwhile, adjacent houses have a security system connected, and it will automatically contact the police if two adjacent houses were broken into on the same night.

Given an integer array `nums` representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.

- Example 1:

```
Input: nums = [2,3,2]
Output: 3
Explanation: You cannot rob house 1 (money = 2) and then rob house 3 (money = 2), because they are adjacent houses.
```

- Example 2:

```
Input: nums = [1,2,3,1]
Output: 4
Explanation: Rob house 1 (1) and then rob house 3 (3).
```

- Example 3:

```
Input: nums = [1,2,3]
Output: 3
```

## Solution:

Because houses form a circle, house `0` and house `n-1` cannot both be robbed.

Solve two linear ranges and take the max:

1. Rob houses `[1 .. n-1]` (exclude first)
2. Rob houses `[0 .. n-2]` (exclude last)

Each linear range uses the classic House Robber DP (`prev2`/`prev`).

Edge case: a single house → return `nums[0]`.

For `nums = [2,3,2]`:

1. Range exclude first: only `[3,2]` → best 3
2. Range exclude last: only `[2,3]` → best 3
3. Answer: `3`

## Implementations:

### C# :

```csharp
// Using memoization approach - Time: O(n)

class Solution
{
    private int Rob(int[] nums, int start, int end)
    {
        if (start == end) return 0;
        if (start + 1 == end) return nums[start];

        int prev2 = 0, prev = 0;

        for (int i = start; i < end; i++)
        {
            int cur = Math.Max(prev, nums[i] + prev2);
            prev2 = prev;
            prev = cur;
        }

        return prev;
    }

    public int Rob(int[] nums)
    {
        if (nums.Length == 1) return nums[0];
        return Math.Max(Rob(nums, 1, nums.Length), Rob(nums, 0, nums.Length - 1));
    }
}
```

1. Helper `Rob(nums, start, end)` solves linear House Robber on a half-open range.

2. Public method takes max of the two circular-safe ranges.

### C++ :

```cpp
// Using memoization - Time: O(n)

class Solution {
    int rob(std::vector<int>& nums, int start, int end)
    {
        if (start == end) return 0;
        if (start + 1 == end) return nums[start];

        int prev2 = 0, prev = 0;

        for (int i = start; i < end; i++)
        {
            int cur = std::max(prev, nums[i] + prev2);
            prev2 = prev;
            prev = cur;
        }

        return prev;
    }

public:
    int rob(std::vector<int>& nums)
    {
        if (nums.size() == 1) return nums[0];
        return std::max(rob(nums, 1, nums.size()), rob(nums, 0, nums.size() - 1));
    }
};
```

1. Same dual linear DP as C#.

2. `return max(...)` is the best circular-safe robbery plan.
