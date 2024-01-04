#include <iostream>
#include <vector>

// Using tabulation - Time: O(m*n)

class Solution {
public:
    int uniquePaths(int m, int n)
    {
        std::vector<int> dp(n + 1, 0);
        dp[n - 1] = 1;

        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
                dp[j] += dp[j + 1];
        }

        return dp[0];
    }
};

// Using math - Time: O(n)
// 
// class Solution {
// public:
//     int uniquePaths(int m, int n) 
//     {
//         long ans = 1;

//         for (int i = 1; i <= n - 1; i++) 
//         {
//              ans = ans * (m - 1 + i) / i;
//         }
//
//         return ans;
//     }
// };

int main()
{
    int m = 3, n = 7;
    std::cout << "Input: m = " << m << ", n = " << n << std::endl;

    Solution sol;
    int result = sol.uniquePaths(m, n);

    std::cout << "Output: " << result << std::endl;

    return 0;
}