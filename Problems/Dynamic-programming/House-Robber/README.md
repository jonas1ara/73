# House Robber:

This directory contains an implementation of the "House Robber" problem in C#. The implementation uses bottom-up DP with two rolling states and temporal complexity `O(n)`.

## Problem description

You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security systems connected and it will automatically contact the police if two adjacent houses were broken into on the same night.

Given an integer array `nums` representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.

- Example 1:

```
Input: nums = [1,2,3,1]
Output: 4
Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3). Total = 4.
```

- Example 2:

```
Input: nums = [2,7,9,3,1]
Output: 12
Explanation: Rob house 1 (2), house 3 (9), house 5 (1) → 12.
```

## Solution:

For each house, keep two values:

- `rob` = best total if we rob the current house (must skip previous)
- `skip` = best total if we skip the current house

Transitions when visiting value `n`:

- new_rob = `n + skip`
- new_skip = `max(rob, skip)`

Answer is `max(rob, skip)` after the last house.

For `nums = [1,2,3,1]`:

1. House 1: rob=1, skip=0
2. House 2: rob=2, skip=1
3. House 3: rob=4, skip=2
4. House 4: rob=3, skip=4
5. Answer: `4`

## Implementations:

### C# :

```csharp
// Using bottom-up approach - Time: O(n)

class Solution
{
    public int Rob(int[] nums)
    {
        int rob = 0, skip = 0;

        foreach (int n in nums)
        {
            int r = n + skip;
            int s = Math.Max(rob, skip);
            rob = r;
            skip = s;
        }

        return Math.Max(rob, skip);
    }
}
```

1. Track best with/without robbing the current house.

2. Update both states each step without overwriting prematurely (use temps `r`, `s`).

3. `return Math.Max(rob, skip);`

## Suggested practice 🎯

Same adjacent-choice DP pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [House Robber III](https://leetcode.com/problems/house-robber-iii/)
- [Delete and Earn](https://leetcode.com/problems/delete-and-earn/)
- [Paint House](https://leetcode.com/problems/paint-house/)
