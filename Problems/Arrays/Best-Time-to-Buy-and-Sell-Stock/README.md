# Best Time to Buy and Sell Stock:

This directory contains implementations of the "Best Time to Buy and Sell Stock" problem in both C++ and C#. Each implementation uses dynamic programming to find the maximum profit that can be achieved by buying and selling stocks, given an array of stock prices.

## Problem Description

You are given an array `prices` where `prices[i]` is the price of a given stock on the `i`-th day.

You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock. Return the maximum profit you can achieve from this transaction. If no profit is possible, return `0`.

### Example 1:

Input: `prices = [7, 1, 5, 3, 6, 4]`  
Output: `5`  
Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6 - 1 = 5.

### Example 2:

Input: `prices = [7, 6, 4, 3, 1]`  
Output: `0`  
Explanation: No transactions are done and the max profit = 0.

## Solution:

The solution utilizes a dynamic programming technique to track the maximum profit achievable at each point in time. Instead of brute-force checking all pairs of days (which would take O(n^2) time), we can solve this problem in O(n) time by iterating through the array and maintaining two variables:

1. `buy`: This variable represents the best possible price to buy the stock up to the current day (maximized to ensure we buy at the lowest price).
2. `sell`: This variable represents the best possible profit we can achieve by selling the stock at the current price (maximized by considering the current price and the best possible `buy` price).

The idea is to:
- Update the `buy` variable to the lowest possible value as we iterate through the prices.
- Calculate the potential profit for each day by subtracting the current `buy` price from the current price and updating the `sell` value to reflect the maximum profit so far.

At the end of the loop, `sell` will hold the maximum profit achievable.

## C++ Implementation:

```cpp
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
```