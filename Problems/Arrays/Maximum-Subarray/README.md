# Maximum Subarray:

This directory contains an implementation of the "Maximum Subarray" problem in C#. The implementation uses Kadane's algorithm to find the contiguous subarray with the largest sum and maintain a temporal complexity of `O(n)`.

## Problem description

Given an integer array `nums`, find the subarray with the largest sum, and return its sum.

- Example 1:

```
Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
Output: 6
Explanation: The subarray [4,-1,2,1] has the largest sum 6.
```

- Example 2:

```
Input: nums = [1]
Output: 1
```

- Example 3:

```
Input: nums = [5,4,-1,7,8]
Output: 23
```

## Solution:

The naive approach checks every possible subarray, which is `O(n^2)` or `O(n^3)`.

Kadane's algorithm makes a local decision at each index:

- Either extend the previous best ending sum with the current element
- Or start a new subarray at the current element (if the previous sum was negative)

In this code, that idea is written as:

`nums[i] += max(nums[i - 1], 0)`

So each position becomes the best sum ending at that index, and we track the global maximum.

Let's go through `nums = {-2, 1, -3, 4, -1, 2, 1, -5, 4}`:

1. Start: `ans = -2`

2. i = 1 (`1`): previous is `-2 < 0`, so keep `1`. `ans = 1`

3. i = 2 (`-3`): previous is `1 > 0`, so `-3 + 1 = -2`. `ans = 1`

4. i = 3 (`4`): previous is `-2 < 0`, so keep `4`. `ans = 4`

5. i = 4 (`-1`): `-1 + 4 = 3`. `ans = 4`

6. i = 5 (`2`): `2 + 3 = 5`. `ans = 5`

7. i = 6 (`1`): `1 + 5 = 6`. `ans = 6`

8. Later values do not beat `6`

9. Result: `6` from subarray `[4, -1, 2, 1]`

## Implementations:

### C# :

```csharp
// Using Kadan's algorithm - Time: O(n)

public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        int ans = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            nums[i] = nums[i] + Math.Max(nums[i - 1], 0);
            ans = Math.Max(ans, nums[i]);
        }

        return ans;
    }
}
```

1. `public class Solution` : Define a public class called `Solution`.

2. `public int MaxSubArray(int[] nums)` : Define a public method that returns the largest subarray sum.

3. `int ans = nums[0];` : Initialize the answer with the first element.

4. `for (int i = 1; i < nums.Length; i++)` : Iterate from the second element to the end.

5. `nums[i] = nums[i] + Math.Max(nums[i - 1], 0);` : If the previous best ending sum is positive, extend it; otherwise start fresh at `nums[i]`. **After this, `nums[i]` is the best sum ending at index `i`.**

6. `ans = Math.Max(ans, nums[i]);` : Keep the global maximum.

7. `return ans;` : Return the largest sum found.
