#include <iostream>
#include <vector>
#include <string>

// Using tabulation - Time: O(m*n)

class Solution {
public:
    int longestCommonSubsequence(std::string text1, std::string text2)
    {
        int m = text1.size(), n = text2.size();

        if (m < n)
            std::swap(m, n), swap(text1, text2);

        std::vector<int> dp(n + 1);

        for (int i = 0; i < m; i++)
        {
            int prev = 0;

            for (int j = 0; j < n; j++)
            {
                int cur = dp[j + 1];
                if (text1[i] == text2[j])
                {
                    dp[j + 1] = prev + 1;
                }
                else
                {
                    dp[j + 1] = std::max(dp[j], dp[j + 1]);
                }
                prev = cur;
            }
        }

        return dp[n];
    }
};

int main()
{
    std::string text1 = "abcde";
    std::string text2 = "ace";

    std::cout << "Input: text1 = " << text1 << ", text2 = " << text2 << std::endl;

    Solution sol;
    int result = sol.longestCommonSubsequence(text1, text2);

    std::cout << "Output: " << result << std::endl;
    
    return 0;
}
