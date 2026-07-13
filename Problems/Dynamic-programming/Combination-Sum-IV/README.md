# Combination Sum IV:

This directory contains implementations of the "Combination Sum IV" problem in the C++ and C# languages. Each implementation uses top-down memoized recursion (order matters) with temporal complexity `O(n · target)`.

## Problem description

Given an array of distinct integers `nums` and a target integer `target`, return the number of possible combinations that add up to `target`.

The test cases are generated so that the answer can fit in a 32-bit integer.

Note that different sequences are counted as different combinations (order matters).

- Example 1:

```
Input: nums = [1,2,3], target = 4
Output: 7
Explanation:
(1,1,1,1), (1,1,2), (1,2,1), (1,3), (2,1,1), (2,2), (3,1)
```

- Example 2:

```
Input: nums = [9], target = 3
Output: 0
```

## Solution:

Let `dp(t)` be the number of ordered ways to sum to `t`.

`dp(0) = 1` (one empty combination)

`dp(t) = sum over num in nums, num <= t of dp(t - num)`

Memoize results in a dictionary/map so each target is solved once.

Sorting `nums` allows early break when a candidate exceeds `t`.

For `nums = [1,2,3]`, `target = 4`:

1. `dp(0)=1`
2. Build up: `dp(1)=1`, `dp(2)=2`, `dp(3)=4`, `dp(4)=7`

## Implementations:

### C# :

```csharp
// Using top-down approach - Time: O(n * amount)

public class Solution
{
    private Dictionary<int, int> m = new Dictionary<int, int> { { 0, 1 } };

    private int Dp(int[] nums, int target)
    {
        if (m.ContainsKey(target)) return m[target];

        int cnt = 0;

        foreach (int n in nums)
        {
            if (n > target) break;
            cnt += Dp(nums, target - n);
        }
        m[target] = cnt;

        return cnt;
    }

    public int CombinationSum4(int[] nums, int target)
    {
        Array.Sort(nums);
        return Dp(nums, target);
    }
}
```

1. Memo map starts with `{0: 1}`.

2. `Dp` tries every number ≤ target and sums recursive ways.

3. Sort enables early stop when `n > target`.

4. `return Dp(nums, target);`

### C++ :

```cpp
// Using top-down approach - Time: O(n * amount)

class Solution {
    std::unordered_map<int, int> m{{0, 1}};

    int dp(std::vector<int> &nums, int target)
    {
        if (m.count(target))
            return m[target];

        int cnt = 0;

        for (int n : nums)
        {
            if (n > target)
                break;
            cnt += dp(nums, target - n);
        }

        return m[target] = cnt;
    }

public:
    int combinationSum4(std::vector<int> &nums, int target)
    {
        std::sort(nums.begin(), nums.end());
        return dp(nums, target);
    }
};
```

1. Same memoized recurrence as C#.

2. Order matters because each recursive branch picks the next number independently (permutations counted separately).
