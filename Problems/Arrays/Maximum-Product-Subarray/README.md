# Maximum Product Subarray:

This directory contains implementations of the "Maximum Product Subarray" problem in both C++ and C#. The solution uses the two pointers technique to calculate the maximum product of a subarray in a given array of integers.

## Problem Description

Given an integer array `nums`, find the contiguous subarray (containing at least one number) which has the largest product and return its product.

### Example 1:

Input: `nums = [2, 3, -2, 4]`  
Output: `6`  
Explanation: Subarray `[2, 3]` has the largest product = 6.

### Example 2:

Input: `nums = [-2, 0, -1]`  
Output: `0`  
Explanation: The result is 0 because the product of any subarray of `[0]` is 0.

## Approach:

The solution uses the **two pointers technique** to find the maximum product subarray:

1. **Initialization**:
   - Start by initializing the answer to the first element of the array.
   - Set a pointer `j` to iterate through the array.

2. **Main Loop**:
   - Use a while loop to traverse the array using the pointer `j`.
   - For each subarray, calculate the product by multiplying the elements until a `0` is encountered. If a zero is encountered, it breaks the current subarray and starts a new search.
   - The product is updated dynamically as we move through the array.

3. **Handling Negative Products**:
   - If a negative product is encountered (after the pointer `j` has moved past a `0`), we divide the product by elements from the beginning of the subarray (using pointer `i`) to potentially maximize the product.

4. **Zeroes**:
   - Whenever a zero is encountered, the product is reset, and the algorithm moves to the next subarray.

## C++ Implementation:

```cpp
#include <iostream>
#include <vector>

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
                prod *= nums[j++]; // prod = prod * nums[j]
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

int main()
{
    std::vector<int> nums = {2, 3, -2, 4};

    // Print input
    std::cout << "Input: nums = [";
    for (int i = 0; i < nums.size(); i++)
    {
        std::cout << nums[i] << "";
        if (i < nums.size() - 1)
            std::cout << ", ";
    }
    std::cout << "]" << std::endl;

    Solution sol;
    int result = sol.maxProduct(nums);

    // Print output
    std::cout << "Output: " << result << std::endl;

    return 0;
}
```