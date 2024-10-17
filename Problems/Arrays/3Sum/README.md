# 3Sum

This repository contains implementations of the "3Sum" problem in C++ and C#. The solutions utilize the two-pointer technique to find all unique triplets in an array that sum up to zero. The algorithms are designed to handle input arrays with time complexity of `O(n^2)`.

## Problem Description

Given an integer array `nums`, return all the triplets `[nums[i], nums[j], nums[k]]` such that:

- `i`, `j`, and `k` are distinct indices.
- `nums[i] + nums[j] + nums[k] == 0`.

The solution must not contain duplicate triplets.

### Example 1:

```plaintext
Input: nums = [-1,0,1,2,-1,-4]
Output: [[-1,-1,2],[-1,0,1]]
Explanation: 
nums[0] + nums[4] + nums[3] = -1 + (-1) + 2 = 0
nums[0] + nums[1] + nums[2] = -1 + 0 + 1 = 0
```

### Example 2:

```plaintext
Input: nums = [0,1,1]
Output: []
Explanation: No three numbers sum up to zero.
```

### Example 3:

```plaintext
Input: nums = [0,0,0]
Output: [[0,0,0]]
```

## Approach

The solution sorts the array and applies the two-pointer technique. By iterating through the array and setting two pointers, one starting from the next element and the other from the end of the array, the algorithm efficiently identifies triplets that sum to zero while avoiding duplicates.

### Steps:
1. Sort the array.
2. Iterate through the array with the first pointer (`i`).
3. Use two pointers (`j` and `k`) to find pairs that sum with `nums[i]` to zero.
4. Skip duplicate values to ensure unique triplets.
5. Collect and return the results.

---

## Implementations

### C++ Implementation

```cpp
#include <algorithm>
#include <iostream>
#include <vector>
#include <map>

class Solution {
public:
    std::vector<std::vector<int>> threeSum(std::vector<int> &nums)
    {
        std::vector<std::vector<int>> result;
        int n = nums.size();
        
        if (n < 3){ return result; }

        sort(nums.begin(), nums.end());

        for (int i = 0; i < n - 2; i++)
        {
            if (nums[i] > 0) break;
            if (i > 0 && nums[i - 1] == nums[i]) continue;

            int j = i + 1;
            int k = n - 1;

            while (j < k)
            {
                int sum = nums[i] + nums[j] + nums[k];

                if (sum < 0) j++;
                else if (sum > 0) k--;
                else {
                    result.push_back({nums[i], nums[j], nums[k]});

                    while (j < k && nums[j] == nums[j + 1]) j++;
                    j++;

                    while (j < k && nums[k - 1] == nums[k]) k--;
                    k--;
                }
            }
        }
        
        return result;
    }
};

int main()
{
    std::vector<int> nums = {-1, 0, 1, 2, -1, -4};

    std::cout << "Input: nums = [";
    for (const auto &num : nums)
    {
        std::cout << num << (num == nums.back() ? "" : ", ");
    }
    std::cout << "]\n";

    Solution sol;
    std::vector<std::vector<int>> result = sol.threeSum(nums);

    std::cout << "Output: [";
    for (const auto &vec : result)
    {
        std::cout << "[";
        for (size_t i = 0; i < vec.size(); i++)
        {
            std::cout << vec[i] << (i < vec.size() - 1 ? ", " : "");
        }
        std::cout << "]" << (vec == result.back() ? "" : ", ");
    }
    std::cout << "]\n";

    return 0;
}
```

### C# Implementation

```csharp
using System;
using System.Collections.Generic;

public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        List<IList<int>> result = new List<IList<int>>();
        int n = nums.Length;

        if (n < 3)
        {
            return result;
        }

        Array.Sort(nums);

        for (int i = 0; i < n - 2; i++)
        {
            if (nums[i] > 0) break;
            if (i > 0 && nums[i - 1] == nums[i]) continue;

            int j = i + 1;
            int k = n - 1;

            while (j < k)
            {
                int sum = nums[i] + nums[j] + nums[k];

                if (sum < 0) j++;
                else if (sum > 0) k--;
                else {
                    result.Add(new List<int> { nums[i], nums[j], nums[k] });

                    while (j < k && nums[j] == nums[j + 1]) j++;
                    j++;

                    while (j < k && nums[k - 1] == nums[k]) k--;
                    k--;
                }
            }
        }

        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] nums = { -1, 0, 1, 2, -1, -4 };

        Console.Write("Input: nums = [");
        for (int i = 0; i < nums.Length; i++)
        {
            Console.Write(nums[i]);
            if (i < nums.Length - 1) Console.Write(", ");
        }
        Console.WriteLine("]");

        IList<IList<int>> result = new Solution().ThreeSum(nums);

        Console.Write("Output: [");
        foreach (var triplet in result)
        {
            Console.Write("[" + string.Join(", ", triplet) + "]");
            if (triplet != result[^1]) Console.Write(", ");
        }
        Console.WriteLine("]");
    }
}
```