# Longest Increasing Subsequence:

This directory contains implementations of the "Longest Increasing Subsequence" problem in the C++ and C# languages. Each implementation uses classic DP tabulation with temporal complexity `O(n^2)`.

## Problem description

Given an integer array `nums`, return the length of the longest strictly increasing subsequence.

- Example 1:

```
Input: nums = [10,9,2,5,3,7,101,18]
Output: 4
Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4.
```

- Example 2:

```
Input: nums = [0,1,0,3,2,3]
Output: 4
```

- Example 3:

```
Input: nums = [7,7,7,7,7,7,7]
Output: 1
```

## Solution:

Define `dp[i]` = length of the LIS ending at index `i`.

Base: every `dp[i] = 1` (the element alone).

Transition:

For all `j < i`, if `nums[j] < nums[i]`, then `dp[i] = max(dp[i], dp[j] + 1)`.

Answer is the maximum value in `dp`.

There is also an `O(n log n)` patience-sorting approach, but this repository implements the clear `O(n^2)` DP.

For `nums = [10,9,2,5,3,7,101,18]`:

1. Build up lengths ending at each index
2. Best ends at `101` with length 4 (`2,3,7,101` or `2,5,7,101`)

## Implementations:

### C# :

```csharp
// Using tabulation - Time: O(n^2)

public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        if (nums.Length == 0) return 0;

        int n = nums.Length;
        int[] dp = new int[n];

        for (int i = 0; i < n; i++)
        {
            dp[i] = 1;
        }

        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[j] < nums[i]) dp[i] = Math.Max(dp[i], dp[j] + 1);
            }
        }

        return dp.Max();
    }
}
```

1. Initialize every LIS ending length to 1.

2. Double loop extends LIS when a smaller predecessor is found.

3. `return dp.Max();` overall LIS length.

### C++ :

```cpp
// Using tabulation - Time: O(n^2)

class Solution {
public:
    int lengthOfLIS(std::vector<int> &nums)
    {
        if (nums.empty())
            return 0;

        int n = nums.size();
        std::vector<int> dp(n, 1);

        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[j] < nums[i])
                    dp[i] = std::max(dp[i], dp[j] + 1);
            }
        }

        return *std::max_element(dp.begin(), dp.end());
    }
};
```

1. Same DP as C#.

2. `max_element` picks the longest increasing subsequence length.
