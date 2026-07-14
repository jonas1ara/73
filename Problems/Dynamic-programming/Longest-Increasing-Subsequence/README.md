# Longest Increasing Subsequence:

This directory contains an implementation of the "Longest Increasing Subsequence" problem in C#. The implementation uses classic DP tabulation with temporal complexity `O(n^2)`.

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

### F# :

```fsharp
open System

type Solution() =
    member this.LengthOfLIS(nums: int[]) =
        if nums.Length = 0 then 0
        else
            let n = nums.Length
            let dp = Array.create n 1

            for i in 1..n-1 do
                for j in 0..i-1 do
                    if nums.[j] < nums.[i] then
                        dp.[i] <- Math.Max(dp.[i], dp.[j] + 1)
            
            Array.max dp
```

1. `type Solution() =` : Define a class-like type called `Solution`.

2. `if nums.Length = 0 then 0 else ...` : F#'s `if` is an expression, so the empty-array case and the general case both produce the method's return value.

3. `let dp = Array.create n 1` : Initialize every LIS ending length to `1` in one call, equivalent to the C# initialization loop.

4. `for i in 1..n-1 do` / `for j in 0..i-1 do` : Nested ranges extend the LIS when a smaller predecessor is found.

5. `dp.[i] <- Math.Max(dp.[i], dp.[j] + 1)` : Mutate the array in place through `<-`.

6. `Array.max dp` : Last expression of the `else` branch, returned implicitly as the overall LIS length.

## Suggested practice 🎯

Same subsequence DP pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Russian Doll Envelopes](https://leetcode.com/problems/russian-doll-envelopes/)
- [Number of Longest Increasing Subsequence](https://leetcode.com/problems/number-of-longest-increasing-subsequence/)
- [Maximum Length of Pair Chain](https://leetcode.com/problems/maximum-length-of-pair-chain/)
