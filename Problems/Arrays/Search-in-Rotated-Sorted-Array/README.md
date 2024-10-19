# Search in Rotated Sorted Array

## Problem Statement

You are given an integer array `nums` sorted in ascending order (with distinct values), which has been rotated at an unknown pivot. You are also given an integer `target`. Your task is to search for `target` in `nums`, and return its index. If `target` is not found, return `-1`.

### Constraints:
- \(1 \leq nums.length \leq 5000\)
- \(-10^4 \leq nums[i], target \leq 10^4\)
- All values of `nums` are unique.

### Example Input and Output:

#### Example 1:
Input: `nums = [4,5,6,7,0,1,2], target = 0`

Output: `4`

#### Example 2:
Input: `nums = [4,5,6,7,0,1,2], target = 3`

Output: `-1`

#### Example 3:
Input: `nums = [1], target = 0`

Output: `-1`

---

## Solution Explanation

The problem can be solved efficiently using a binary search algorithm, which operates in \(O(\log n)\) time. The solution involves identifying the pivot point where the array was rotated, and then performing a modified binary search.

### Key Steps:
1. Find the pivot point in the rotated array using binary search.
2. Adjust the indices to account for the rotation.
3. Perform binary search to locate the `target`.

---

## Implementation

### C++ Implementation
```cpp
#include <iostream>
#include <vector>

// Using binary search technique - Time: O(log n)

class Solution {
public:
    int search(std::vector<int> &nums, int target)
    {
        if (nums.empty())
            return -1;

        int n = nums.size(), left = 0, right = n - 1, pivot;
        
        while (left < right)
        {
            int m = left + (right - left) / 2; // m is the index of the middle element
            if (nums[m] < nums[right])
                right = m;
            else
                left = m + 1;
        }
        
        pivot = left;
        left = 0, right = n - 1;

        while (left <= right)
        {
            int m = left + (right - left) / 2; 
            int mm = (m + pivot) % n; // mm is the index of the middle element in the rotated array
            
            if (nums[mm] == target)
                return mm;

            if (target > nums[mm])
                left = m + 1;
            else
                right = m - 1;
        }

        return -1;
    }
};

int main()
{
    std::vector<int> nums = {4, 5, 6, 7, 0, 1, 2};
    int target = 3;

    // Print input
    std::cout << "Input: nums = [";
    for (const auto &num : nums)
    {
        std::cout << num << "";
        if (&num != &nums.back())
            std::cout << ", ";
    }
    std::cout << "]" << std::endl;

    Solution sol;
    int result = sol.search(nums, target);

    // Print output
    std::cout << "Output: " << result << std::endl;

    return 0;
}
```

### C# Implementation
```csharp
using System;

// Using binary search technique - Time: O(log n)

public class Solution
{
    public int Search(int[] nums, int target)
    {
        if (nums.Length == 0)
            return -1;

        int n = nums.Length, left = 0, right = n - 1, pivot;

        while (left < right)
        {
            int m = left + (right - left) / 2; // m is the index of the middle element

            if (nums[m] < nums[right])
                right = m;
            else
                left = m + 1;
        }
        pivot = left;
        left = 0;
        right = n - 1;

        while (left <= right)
        {
            int m = left + (right - left) / 2;
            int mm = (m + pivot) % n; // mm is the index of the middle element in the rotated array

            if (nums[mm] == target)
                return mm;
            if (target > nums[mm])
                left = m + 1;
            else
                right = m - 1;
        }

        return -1;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] nums = { 1, 4, 5, 6, 7, 0, 1, 2 };
        int target = 0;

        // Print input
        Console.Write("Input: nums = [");
        foreach (int num in nums)
        {
            Console.Write(num + "");
            if (num != nums[nums.Length - 1])
                Console.Write(", ");
        }
        Console.WriteLine("]");

        Solution sol = new Solution();
        int result = sol.Search(nums, target);

        // Print output
        Console.WriteLine("Output: " + result);
    }
}
```

---

## Complexity Analysis

### Time Complexity:
- Finding the pivot requires \(O(\log n)\).
- Binary search on the rotated array requires \(O(\log n)\).
- Overall: **\(O(\log n)\)**

### Space Complexity:
- Only constant extra space is used: **\(O(1)\)**.

---

## Usage
Compile and run the respective C++ or C# code snippets to test the solution with various inputs. Both implementations follow the same logical steps and are optimized for efficiency.
