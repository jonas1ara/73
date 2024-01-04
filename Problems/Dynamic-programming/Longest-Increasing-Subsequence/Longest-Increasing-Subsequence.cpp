#include <iostream>
#include <vector>
#include <algorithm>

// Using tabulation - Time: O(n^2)

class Solution {
public:
    int lengthOfLIS(std::vector<int> &nums)
    {
        if (nums.empty())
            return 0;

        int n = nums.size();
        std::vector<int> dp(n, 1);
        
        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[j] < nums[i])
                    dp[i] = std::max(dp[i], dp[j] + 1);
            }
        }

        return *std::max_element(dp.begin(), dp.end());
    }
};

int main()
{
    std::vector<int> nums = {10, 9, 2, 5, 3, 7, 101, 18};

    std::cout << "Input: nums = [";
    for (int i = 0; i < nums.size(); i++)
    {
        std::cout << nums[i];
        if (i < nums.size() - 1)
            std::cout << ", ";
    }
    std::cout << "]" << std::endl;  
    
    Solution sol;
    int result = sol.lengthOfLIS(nums);
    
    std::cout << "Output: " << result << std::endl;
    
    return 0;
}
