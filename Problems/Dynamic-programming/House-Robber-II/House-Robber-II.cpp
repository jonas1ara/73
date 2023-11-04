﻿#include <iostream>
#include <vector>
#include <algorithm>

class Solution {
    int rob(std::vector<int>& nums, int start, int end) {
        if (start == end) return 0;
        if (start + 1 == end) return nums[start];
        int prev2 = 0, prev = 0;
        for (int i = start; i < end; ++i) {
            int cur = std::max(prev, nums[i] + prev2);
            prev2 = prev;
            prev = cur;
        }
        return prev;
    }
public:
    int rob(std::vector<int>& nums) {
        if (nums.size() == 1) return nums[0];
        return std::max(rob(nums, 1, nums.size()), rob(nums, 0, nums.size() - 1));
    }
};

int main()
{
    std::vector <int> nums = {2, 3, 2};

    // int start = 0, end = nums.size() - 1;
    Solution sol;
    std::cout << sol.rob(nums) << std::endl;

    return 0;
}