using System;
public class Solution
{
    public int MaxProfit(int[] A)
    {
        int buy = int.MinValue;
        int sell = 0;

        foreach (int n in A)
        {
            buy = Math.Max(buy, -n);
            sell = Math.Max(sell, buy + n);
        }

        return sell;
    }

    public static void Main(string[] args)
    {
        int[] nums = new int[] { 7, 1, 5, 3, 6, 4 };
        Console.WriteLine(new Solution().MaxProfit(nums));
    }
}
