# Maximum Subarray Problem

This document explains the solution to the Maximum Subarray problem using Kadane's algorithm. The problem is to find the contiguous subarray within a one-dimensional array of numbers (containing at least one number) which has the largest sum.

---

## Problem Description

Given an integer array `nums`, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.

### Example 1:

```
Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
Output: 6
Explanation: [4,-1,2,1] has the largest sum = 6.
```

### Example 2:

```
Input: nums = [1]
Output: 1
Explanation: The subarray [1] is the only one with sum 1.
```

### Constraints:

- `1 <= nums.length <= 10^5`
- `-10^4 <= nums[i] <= 10^4`

---

## Algorithm Explanation

We use Kadane's algorithm to solve this problem. The algorithm maintains the maximum sum of subarrays ending at each position. 

**Steps:**
1. Initialize a variable `ans` to store the maximum sum encountered so far.
2. Traverse the array, and for each element:
   - Update the current element with the maximum sum ending at that element (`nums[i] += max(nums[i-1], 0)`).
   - Update `ans` if the current element's value is greater than the stored maximum.
3. Return the value of `ans`.

The time complexity is O(n), and the space complexity is O(1).

---

## Code Implementations

### C++ Implementation

```cpp
#include <iostream>
#include <vector>

// Using Kadan's algorithm - Time: O(n)

class Solution {
public:
    int maxSubArray(std::vector<int> &nums)
    {
        int ans = nums[0];

        for (int i = 1; i < nums.size(); i++)
        {
            nums[i] += std::max(nums[i - 1], 0);
            ans = std::max(ans, nums[i]);
        }

        return ans;
    }
};

int main()
{
    std::vector<int> nums = {-2, 1, -3, 4, -1, 2, 1, -5, 4};

    // Print input
    std::cout << "Input: nums = [";
    for (const auto &num : nums)
    {
        std::cout << num << "";
        if (&num != &nums.back())
        {
            std::cout << ", ";
        }
    }
    std::cout << "]" << std::endl;

    Solution sol;
    int result = sol.maxSubArray(nums);

    // Print output
    std::cout << "Output: " << result << std::endl;

    return 0;
}
```

### C# Implementation

```csharp
using System;

// Using Kadan's algorithm - Time: O(n)

public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        int ans = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            nums[i] = nums[i] +  Math.Max(nums[i - 1], 0);
            ans = Math.Max(ans, nums[i]);
        }

        return ans;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

        // Print input
        Console.Write("Input: nums = [");
        foreach (int num in nums)
        {
            Console.Write(num + "");
            if (num != nums[nums.Length - 1])
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");

        Solution sol = new Solution();
        int result = sol.MaxSubArray(nums);

        // Print output
        Console.WriteLine("Output: " + result);
    }
}
```

---

## Complexity Analysis

**Time Complexity:**
- O(n): Each element is visited once.

**Space Complexity:**
- O(1): In-place computation without additional data structures.

---

Feel free to adapt or extend the code to suit your needs.
