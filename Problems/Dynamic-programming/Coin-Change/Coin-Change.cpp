#include <iostream>
#include <vector>
#include <algorithm>
#include <cstring>

// Using bottom-up approach - Time: O(n * amount)

class Solution {
public:
    int coinChange(std::vector<int> &coins, int amount)
    {
        std::sort(begin(coins), end(coins), std::greater<>());
        int n = coins.size();
        int inf = 0x3f3f3f3f; // inf = 1061109567
        int dp[13][10001] = {};
        std::memset(dp, 0x3f, sizeof(dp));

        for (int i = 0; i <= n; i++)
            dp[i][0] = 0;

        for (int t = 1; t <= amount; t++)
        {
            for (int i = 0; i < n; i++)
            {
                dp[i + 1][t] = std::min(dp[i][t], t - coins[i] >= 0 ? 1 + dp[i + 1][t - coins[i]] : inf);
            }
        }
        return dp[n][amount] == inf ? -1 : dp[n][amount];
    }
};

int main()
{
    std::vector<int> coins = {1, 2, 5};
    int target = 11;

    std::cout << "Input: coins = [";
    for (int i = 0; i < coins.size(); i++)
    {
        std::cout << coins[i];
        if (i != coins.size() - 1)
            std::cout << ", ";
    }
    std::cout << "], amount = " << target << std::endl;

    Solution sol;
    int result = sol.coinChange(coins, target);

    std::cout << "Output: " << result << std::endl;

    return 0;
}
