# Find Minimum in Rotated Sorted Array:

This directory contains implementations of the "Find Minimum in Rotated Sorted Array" problem in both C++ and C#. The solution uses the **binary search technique** to efficiently find the minimum element in a rotated sorted array.

## Problem Description

Given a rotated sorted array `nums` of **distinct** integers, find the minimum element in the array. 

You must solve it in **O(log n)** time complexity.

### Example 1:

Input: `nums = [3, 4, 5, 1, 2]`  
Output: `1`  
Explanation: The original array was `[1, 2, 3, 4, 5]`, and it was rotated 3 times.

### Example 2:

Input: `nums = [4, 5, 6, 7, 0, 1, 2]`  
Output: `0`  
Explanation: The original array was `[0, 1, 2, 4, 5, 6, 7]`, and it was rotated 4 times.

### Example 3:

Input: `nums = [11, 13, 15, 17]`  
Output: `11`  
Explanation: The original array was `[11, 13, 15, 17]`, and it was not rotated.

## Approach:

The solution uses the **binary search technique** to find the minimum element in the rotated sorted array:

1. **Initialization**:
   - Start with two pointers `left` and `right` pointing to the first and last elements of the array respectively.
   
2. **Main Loop**:
   - Use a `while` loop that continues as long as `left` is less than `right`.
   - Calculate the middle index `m` as `(left + right) / 2`.
   - If the middle element `nums[m]` is greater than `nums[right]`, this means the minimum element must be in the right half of the array, so we move the `left` pointer to `m + 1`.
   - If `nums[m]` is less than or equal to `nums[right]`, this means the minimum element is in the left half of the array (or possibly at `m` itself), so we move the `right` pointer to `m`.
   
3. **Return the Result**:
   - When `left` equals `right`, the minimum element is found at the index `left`, so we return `nums[left]`.

## C++ Implementation:

```cpp
#include <iostream>
#include <vector>

// Using binary search technique - Time O(log n)

class Solution {
public:
    int findMin(std::vector<int> &nums)
    {
        int left = 0, right = nums.size() - 1;

        while (left < right)
        {
            int m = (left + right) / 2; // middle index

            if (nums[m] > nums[right])
                left = m + 1;
            else
                right = m;
        }

        return nums[left];
    }
};

int main()
{
    std::vector<int> nums = {3, 4, 5, 1, 2};

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
    int result = sol.findMin(nums);

    // Print output
    std::cout << "Output: " << result << std::endl;

    return 0;
}
```