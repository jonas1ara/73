#include <iostream>
#include <vector>

// DP
class Solution
{
public:
    int uniquePaths(int m, int n)
    {
        std::vector<int> dp(n + 1, 0);
        dp[n - 1] = 1;
        for (int i = m - 1; i >= 0; --i)
        {
            for (int j = n - 1; j >= 0; --j)
                dp[j] += dp[j + 1];
        }
        return dp[0];
    }
};

// Math

// class Solution {
// public:
//     int uniquePaths(int m, int n) {
//         long ans = 1;
//         for (int i = 1; i <= n - 1; ++i) ans = ans * (m - 1 + i) / i;
//         return ans;
//     }
// };


int main()
{
    Solution sol;

    int result = sol.uniquePaths(3, 3); // Llamando a la función uniquePaths definida anteriormente
    std::cout << "El número de rutas únicas es: " << result << std::endl;
    return 0;
}