# Product Except Self:

This directory contains implementations of the "Product Except Self" problem in both C++ and C#. The solution uses a technique involving **prefix and postfix products** to compute the result without using division and in **O(n)** time.

## Problem Description

Given an integer array `nums`, return an array `result` such that `result[i]` is equal to the product of all the elements of `nums` except `nums[i]`.

You must solve it without using division and in **O(n)** time complexity.

### Example 1:

Input: `nums = [1, 2, 3, 4]`  
Output: `[24, 12, 8, 6]`  
Explanation:  
- `result[0] = 2 * 3 * 4 = 24`
- `result[1] = 1 * 3 * 4 = 12`
- `result[2] = 1 * 2 * 4 = 8`
- `result[3] = 1 * 2 * 3 = 6`

### Example 2:

Input: `nums = [-1, 1, 0, -3, 3]`  
Output: `[0, 0, 9, 0, 0]`  
Explanation:  
- `result[0] = 1 * 0 * -3 * 3 = 0`
- `result[1] = -1 * 0 * -3 * 3 = 0`
- `result[2] = -1 * 1 * -3 * 3 = 9`
- `result[3] = -1 * 1 * 0 * 3 = 0`
- `result[4] = -1 * 1 * 0 * -3 = 0`

## Approach:

The solution involves two passes through the input array:

1. **Prefix Product (Left Pass)**:
   - Create a result array and populate it such that `result[i]` is the product of all elements to the left of `i` in the original array.
   
2. **Postfix Product (Right Pass)**:
   - Traverse the array from the right end, and for each element, multiply it with the product of all elements to the right of that element.

This ensures that each element in the result array holds the product of all elements except itself without needing division.

## C++ Implementation:

```cpp
#include <iostream>
#include <vector>

// Using prefix and postfix - Time O(n)

class Solution {
public:
    std::vector<int> productExceptSelf(std::vector<int> &nums)
    {
        int n = nums.size();
        std::vector<int> result(n, 1);
        result[0] = 1;

        for (int i = 1; i < n; i++)
        {
            result[i] = result[i - 1] * nums[i - 1];
        }

        int rightSide = 1;
        for (int i = n - 1; i >= 0; i--)
        {
            result[i] = result[i] * rightSide;
            rightSide *= nums[i]; // rightSide = rightSide * nums[i];
        }

        return result;
    }
};

int main()
{
    std::vector<int> nums = {1, 2, 3, 4};

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
    std::vector<int> result = sol.productExceptSelf(nums);

    // Print output
    std::cout << "Output: [";
    for (const auto &r : result)
    {
        std::cout << r << "";
        if (&r != &result.back())
        {
            std::cout << ", ";
        }
    }
    std::cout << "]" << std::endl;

    return 0;
}
```