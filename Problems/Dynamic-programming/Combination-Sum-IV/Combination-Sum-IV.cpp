#include <iostream>
#include <vector>
#include <unordered_map>
#include <algorithm>

// Using top-down approach - Time: O(n * amount)

class Solution {
    std::unordered_map<int, int> m{{0, 1}};

    int dp(std::vector<int> &nums, int target)
    {
        if (m.count(target))
            return m[target];

        int cnt = 0;

        for (int n : nums)
        {
            if (n > target)
                break;
            cnt += dp(nums, target - n);
        }
        
        return m[target] = cnt;
    }

public:
    int combinationSum4(std::vector<int> &nums, int target)
    {
        std::sort(nums.begin(), nums.end());
        return dp(nums, target);
    }
};

int main()
{
    std::vector<int> nums = {1, 2, 3};
    int target = 4;

    std::cout << "Input: nums = [";
    for (int i = 0; i < nums.size(); i++)
    {
        std::cout << nums[i];
        if (i != nums.size() - 1)
            std::cout << ", ";
    }
    std::cout << "], target = " << target << std::endl;

    Solution sol;
    int result = sol.combinationSum4(nums, target);

    std::cout << "Output: " << result << std::endl;

    return 0;
}
