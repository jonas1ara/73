# Best Time to Buy and Sell Stock:

This directory contains implementations of the "Best Time to Buy and Sell Stock" problem in the C++ and C# languages. Each implementation uses a one-pass dynamic programming idea to find the maximum profit and maintain a temporal complexity of `O(n)`.

## Problem description

You are given an array `prices` where `prices[i]` is the price of a given stock on the `i`-th day.

You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.

Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return `0`.

- Example 1:

```
Input: prices = [7,1,5,3,6,4]
Output: 5
Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6 - 1 = 5.
```

- Example 2:

```
Input: prices = [7,6,4,3,1]
Output: 0
Explanation: No transactions are done and the max profit = 0.
```

## Solution:

The easy way is to check every pair of buy and sell days with two nested loops, which costs `O(n^2)`.

The optimal idea is to track, in one pass:

- The best (lowest) buy price seen so far, stored as a negative value for convenience
- The best profit if we sell today using that best buy

For each price we update:

1. `buy = max(buy, -price)` → remember the cheapest buy so far
2. `sell = max(sell, buy + price)` → best profit if we sell today

Let's go through `prices = {7, 1, 5, 3, 6, 4}`:

1. Start: `buy = -∞`, `sell = 0`

2. Day 0, price `7`:
    - `buy = max(-∞, -7) = -7`
    - `sell = max(0, -7 + 7) = 0`

3. Day 1, price `1`:
    - `buy = max(-7, -1) = -1` (cheaper buy)
    - `sell = max(0, -1 + 1) = 0`

4. Day 2, price `5`:
    - `buy = max(-1, -5) = -1`
    - `sell = max(0, -1 + 5) = 4`

5. Day 4, price `6`:
    - `buy` stays `-1`
    - `sell = max(4, -1 + 6) = 5`

6. Result: maximum profit is `5`

## Implementations:

### C# :

```csharp
// Using dynamic programming technique - Time: O(n)

public class Solution
{
    public int MaxProfit(int[] prices)
    {
        int buy = int.MinValue, sell = 0;

        foreach (int price in prices)
        {
            buy = Math.Max(buy, -price);
            sell = Math.Max(sell, buy + price);
        }

        return sell;
    }
}
```

1. `public class Solution` : Define a public class called `Solution`.

2. `public int MaxProfit(int[] prices)` : Define a public method that returns the maximum profit for one buy and one sell.

3. `int buy = int.MinValue, sell = 0;` : Initialize the best buy cost (as a very low value) and the best profit to `0`.

4. `foreach (int price in prices)` : Iterate through every daily price once.

5. `buy = Math.Max(buy, -price);` : Keep the cheapest buy seen so far (stored as a negative price).

6. `sell = Math.Max(sell, buy + price);` : Update the best profit if selling at the current price with the best buy.

7. `return sell;` : Return the maximum profit found.

### C++ :

```cpp
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
```

1. `class Solution {public: ...};` : Define a public class called `Solution`.

2. `int maxProfit(std::vector<int> &prices)` : Define a function that returns the maximum profit for one buy and one sell.

3. `int buy = INT_MIN, sell = 0;` : Initialize the best buy and the best profit.

4. `for (int price : prices)` : Iterate through every daily price once.

5. `buy = std::max(buy, -price);` : Keep the cheapest buy seen so far.

6. `sell = std::max(sell, buy + price);` : Update the best profit if selling today.

7. `return sell;` : Return the maximum profit found.
