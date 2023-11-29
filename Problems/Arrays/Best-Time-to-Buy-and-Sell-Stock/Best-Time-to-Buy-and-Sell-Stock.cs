using System;

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

class Program
{
    static void Main(string[] args)
    {
        int[] prices = { 7, 1, 5, 3, 6, 4 };

        // Print input
        Console.Write("Input: prices = [");
        foreach (int price in prices)
        {
            Console.Write(price + "");
            if (price != prices[prices.Length - 1])
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");

        Solution solution = new Solution();
        int maxProfit = solution.MaxProfit(prices);

        // Print output
        Console.WriteLine("Output: " + maxProfit);
    }
}