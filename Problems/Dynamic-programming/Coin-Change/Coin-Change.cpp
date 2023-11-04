#include <iostream>
#include <vector>

class Solution {
public:
    int coinChange(std::vector<int>& A, int T) {
        // ... (código de la función coinChange)
    }
};

int main() {
    Solution solution;
    std::vector<int> coins = {1, 2, 5};
    int target = 11;
    int result = solution.coinChange(coins, target);
    std::cout << "Minimum number of coins to make " << target << " is: " << result << std::endl;
    return 0;
}
