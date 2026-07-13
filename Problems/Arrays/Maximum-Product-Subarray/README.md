# Maximum Product Subarray:

This directory contains implementations of the "Maximum Product Subarray" problem in the C++ and C# languages. Each implementation uses a linear scan over segments between zeros to find the contiguous subarray with the largest product and maintain a temporal complexity of `O(n)`.

## Problem description

Given an integer array `nums`, find a subarray that has the largest product, and return the product.

The test cases are generated so that the answer will fit in a 32-bit integer.

- Example 1:

```
Input: nums = [2,3,-2,4]
Output: 6
Explanation: [2,3] has the largest product 6.
```

- Example 2:

```
Input: nums = [-2,0,-1]
Output: 0
Explanation: The result cannot be 2, because [-2,-1] is not a subarray.
```

## Solution:

Products behave differently from sums: a negative number can flip the sign of a large product, and zeros reset the product to zero.

This implementation walks the array from left to right and processes non-zero segments:

1. Multiply consecutive non-zero numbers and track the best product seen
2. If a zero is found, consider `0` as a candidate answer
3. If the full segment product is negative, divide out left factors until the remaining product is non-negative (or empty), updating the answer along the way

That way we never keep a trailing negative factor when removing it increases the product.

Let's go through `nums = {2, 3, -2, 4}`:

1. Segment starts at index `0`
2. Running product: `2` → `6` → `-12` → `-48`
3. Best so far becomes `6` (from `2 * 3`)
4. Segment product ends negative (`-48`). Remove left factors:
    - divide by `2` → `-24`
    - divide by `3` → `-8`
    - divide by `-2` → `4` → answer updates to at least `4`
5. Final best is `6`

## Implementations:

### C# :

```csharp
// Using two pointers technique - Time O(n)

public class Solution
{
    public int MaxProduct(int[] nums)
    {
        int ans = nums[0];
        int N = nums.Length;
        int j = 0;

        while (j < N)
        {
            int i = j;
            int prod = 1;

            while (j < N && nums[j] != 0)
            {
                prod *= nums[j++];
                ans = Math.Max(ans, prod);
            }

            if (j < N)
            {
                ans = Math.Max(ans, 0);
            }

            while (i < N && prod < 0)
            {
                prod /= nums[i++];
                if (i != j)
                {
                    ans = Math.Max(ans, prod);
                }
            }

            while (j < N && nums[j] == 0)
            {
                j++;
            }
        }

        return ans;
    }
}
```

1. `public class Solution` : Define a public class called `Solution`.

2. `public int MaxProduct(int[] nums)` : Define a public method that returns the maximum product of a contiguous subarray.

3. `int ans = nums[0]; int j = 0;` : Initialize the answer and a pointer that scans the array.

4. Outer `while (j < N)` : Process the array in segments separated by zeros.

5. Inner multiply loop: multiply non-zero values, advance `j`, and update `ans`.

6. `if (j < N) ans = Math.Max(ans, 0);` : If we stopped on a zero, zero is a valid product candidate.

7. Negative-product cleanup: divide out left factors until `prod` is non-negative, updating `ans` when the remaining product is non-empty.

8. Skip consecutive zeros and continue.

9. `return ans;` : Return the maximum product found.

### C++ :

```cpp
// Using two pointers technique - Time O(n)

class Solution {
public:
    int maxProduct(std::vector<int> &nums)
    {
        int ans = nums[0], n = nums.size(), j = 0;
        while (j < n)
        {
            int i = j, prod = 1;
            while (j < n && nums[j] != 0)
            {
                prod *= nums[j++];
                ans = std::max(ans, prod);
            }
            if (j < n)
                ans = std::max(ans, 0);
            while (i < n && prod < 0)
            {
                prod /= nums[i++];
                if (i != j)
                    ans = std::max(ans, prod);
            }
            while (j < n && nums[j] == 0)
                j++;
        }
        return ans;
    }
};
```

1. `class Solution {public: ...};` : Define a public class called `Solution`.

2. `int maxProduct(std::vector<int> &nums)` : Define a function that returns the maximum product of a contiguous subarray.

3. Scan non-zero segments, track running products, handle zeros, and fix negative full-segment products by removing left factors.

4. `return ans;` : Return the maximum product found.
