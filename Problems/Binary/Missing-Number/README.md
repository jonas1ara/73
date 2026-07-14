# Missing Number:

This directory contains an implementation of the "Missing Number" problem in C#. The implementation uses XOR to find the missing value in `O(n)` time and `O(1)` extra space.

## Problem description

Given an array `nums` containing `n` distinct numbers in the range `[0, n]`, return the only number in the range that is missing from the array.

- Example 1:

```
Input: nums = [3,0,1]
Output: 2
Explanation: n = 3 since there are 3 numbers, so all numbers are in the range [0,3]. 2 is the missing number.
```

- Example 2:

```
Input: nums = [0,1]
Output: 2
```

- Example 3:

```
Input: nums = [9,6,4,2,3,5,7,0,1]
Output: 8
```

## Solution:

XOR properties:

- `a ^ a = 0`
- `a ^ 0 = a`
- XOR is commutative and associative

If you XOR every index offset with every array value, all present numbers cancel out and only the missing one remains:

`xorVal = nums[0]^1 ^ nums[1]^2 ^ ... ^ nums[n-1]^n`

(which is equivalent to XOR of all values in `nums` with all numbers in `1..n`, leaving the missing value relative to `0..n`).

Alternative: Gauss formula `n(n+1)/2 - sum(nums)`.

Let's go through `nums = [3,0,1]`:

1. i=0: `0 ^ 3 ^ 1 = 2`
2. i=1: `2 ^ 0 ^ 2 = 0`
3. i=2: `0 ^ 1 ^ 3 = 2`
4. Missing number: `2`

## Implementations:

### C# :

```csharp
// Using XOR operation - Time: O(n)

public class Solution
{
    public int MissingNumber(int[] nums)
    {
        int n = nums.Length;
        int xorVal = 0;
        for (int i = 0; i < n; i++)
            xorVal ^= nums[i] ^ (i + 1);

        return xorVal;
    }
}
```

1. `public class Solution` : Define a public class called `Solution`.

2. `public int MissingNumber(int[] nums)` : Return the missing value in `[0, n]`.

3. Accumulate `nums[i] ^ (i + 1)` into `xorVal`.

4. `return xorVal;` is the missing number.

## Suggested practice 🎯

Same XOR/sum trick pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Single Number](https://leetcode.com/problems/single-number/)
- [Find the Duplicate Number](https://leetcode.com/problems/find-the-duplicate-number/)
- [Find All Numbers Disappeared in an Array](https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/)
