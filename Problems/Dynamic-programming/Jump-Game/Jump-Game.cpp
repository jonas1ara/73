#include <iostream>
#include <vector>

// Using tabulation - Time: O(n^2)

class Solution
{
public:
    bool canJump(std::vector<int> &nums)
    {
        int n = nums.size();
        std::vector<bool> dp(n, false);

        dp[0] = true;

        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (dp[j] && j + nums[j] >= i)
                {
                    dp[i] = true;
                    break;
                }
            }
        }

        return dp[n - 1];
    }
};

// Using greedy algorithm - Time: O(n)
//
// class Solution
// {
// public:
//     bool canJump(vector<int> &nums)
//     {
//         for (int i = 0, last = 0; i <= last; ++i)
//         {
//             last = max(last, i + nums[i]);
//             if (last >= nums.size() - 1)
//                 return true;
//         }
//         return false;
//     }
// };

int main()
{
    std::vector<int> nums = {2, 3, 1, 1, 4};

    std::cout << "Input: [";
    for (int i = 0; i < nums.size(); i++)
    {
        std::cout << nums[i];
        if (i < nums.size() - 1)
            std::cout << ", ";
    }
    std::cout << "]" << std::endl;
    
    Solution sol;    
    bool result = sol.canJump(nums);

    std::cout << "Output: "<< std::boolalpha << result << std::endl; 

    return 0;
}
