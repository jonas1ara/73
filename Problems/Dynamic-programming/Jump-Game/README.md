# Jump Game:

This directory contains an implementation of the "Jump Game" problem in C#. The primary solution uses DP tabulation (`O(n^2)`); a commented greedy `O(n)` alternative is also included in the source files.

## Problem description

You are given an integer array `nums`. You are initially positioned at the array's first index, and each element in the array represents your maximum jump length at that position.

Return `true` if you can reach the last index, or `false` otherwise.

- Example 1:

```
Input: nums = [2,3,1,1,4]
Output: true
Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.
```

- Example 2:

```
Input: nums = [3,2,1,0,4]
Output: false
Explanation: You will always arrive at index 3, which cannot jump further.
```

## Solution:

**DP tabulation (implemented):**

- `dp[i] = true` if index `i` is reachable
- `dp[0] = true`
- For each `i`, check if any earlier reachable `j` satisfies `j + nums[j] >= i`

**Greedy (commented in source):**

- Track the farthest index reachable so far
- If you ever pass that farthest index, fail; if farthest reaches the end, succeed

For `nums = [2,3,1,1,4]`:

1. Index 0 reachable, can reach up to 2
2. Index 1 reachable, can reach up to 4
3. Last index reachable → `true`

## Implementations:

### C# :

```csharp
// Using tabulation - Time: O(n^2)

public class Solution
{
    public bool CanJump(int[] nums)
    {
        int n = nums.Length;
        bool[] dp = new bool[n];

        dp[0] = true;

        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (dp[j] && j + nums[j] >= i)
                {
                    dp[i] = true;
                    break;
                }
            }
        }

        return dp[n - 1];
    }
}
```

1. Mark reachability of each index from earlier reachable indices.

2. Early `break` once a valid predecessor is found.

3. `return dp[n - 1];`
