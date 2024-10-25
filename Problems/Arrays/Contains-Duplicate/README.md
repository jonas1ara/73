# Contains Duplicate:

This directory contains implementations of the "Contains Duplicate" problem in both C++ and C#. The solution uses a **hash table** (unordered set in C++ and HashSet in C#) to efficiently check if a given array contains any duplicate elements.

## Problem Description

Given an integer array `nums`, return `true` if any value appears at least twice in the array, and return `false` if every element is distinct.

### Example 1:

Input: `nums = [1, 2, 3, 1]`  
Output: `true`  
Explanation: The number `1` appears twice in the array.

### Example 2:

Input: `nums = [1, 2, 3, 4]`  
Output: `false`  
Explanation: All numbers are distinct.

### Example 3:

Input: `nums = [1, 1, 1, 3, 3, 4, 3, 2, 4, 2]`  
Output: `true`  
Explanation: The number `1` appears three times, and `3` appears three times.

## Approach:

The solution uses a **hash table** (unordered set in C++ and HashSet in C#) to check for duplicates:

1. **Create a HashSet**:
   - Convert the input array to a hash set, as hash sets only store unique elements.
   
2. **Compare the size**:
   - If the size of the hash set is equal to the size of the input array, it means there are no duplicates, so return `false`.
   - Otherwise, return `true`, indicating that there are duplicates.

## C++ Implementation:

```cpp
#include <unordered_set>
#include <algorithm>
#include <iostream>
#include <vector>

// Using hash table - Time O(n)

class Solution {
public:
    bool containsDuplicate(std::vector<int> &nums)
    {
        std::unordered_set<int> s(begin(nums), end(nums));
        return s.size() != nums.size();
    }
};

int main()
{
    std::vector<int> nums = {1, 2, 3, 1};

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
    bool result = sol.containsDuplicate(nums);

    // Print output
    std::cout << "Output: " << std::boolalpha << result << std::endl;

    return 0;
}
```