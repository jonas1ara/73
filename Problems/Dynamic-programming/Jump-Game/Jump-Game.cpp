#include <iostream>
#include <vector>

// DP
class Solution
{
public:
    bool canJump(std::vector<int> &A)
    {
        int n = A.size();
        std::vector<bool> dp(n, false);

        dp[0] = true;

        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (dp[j] && j + A[j] >= i)
                {
                    dp[i] = true;
                    break;
                }
            }
        }

        return dp[n - 1];
    }
};

// Greedy
// class Solution
// {
// public:
//     bool canJump(vector<int> &A)
//     {
//         for (int i = 0, last = 0; i <= last; ++i)
//         {
//             last = max(last, i + A[i]);
//             if (last >= A.size() - 1)
//                 return true;
//         }
//         return false;
//     }
// };

int main()
{
    Solution solution;
    std::vector<int> nums = {2, 3, 1, 1, 4};
    bool result = solution.canJump(nums);

    if (result)
    {
        std::cout << "Can jump to the end." << std::endl;
    }
    else
    {
        std::cout << "Cannot jump to the end." << std::endl;
    }

    return 0;
}
