#include <iostream>
#include <vector>
#include <climits>

// Using dynamic programming technique - Time: O(n)

class Solution {
public:
    int maxProfit(std::vector<int> &prices)
    {
        int buy = INT_MIN, sell = 0;
        
        for (int price : prices)
        {
            buy = std::max(buy, -price);
            sell = std::max(sell, buy + price);
        }

        return sell;
    }
};

int main()
{
    std::vector<int> prices = {7, 1, 5, 3, 6, 4};

    // Print input
    std::cout << "Input: prices = [";
    for (const auto &price : prices)
    {
        std::cout << price << "";
        if (&price != &prices.back())
        {
            std::cout << ", ";
        }
    }
    std::cout << "]" << std::endl;

    Solution sol;
    int maxProfit = sol.maxProfit(prices);

    // Print output
    std::cout << "Output: " << maxProfit << std::endl;

    return 0;
}
