using System;
using System.Collections.Generic;

public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        if (nums.Length == 0) return 0;
        int N = nums.Length;
        int[] dp = new int[N];
        for (int i = 0; i < N; i++)
        {
            dp[i] = 1;
        }
        for (int i = 1; i < N; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[j] < nums[i]) dp[i] = Math.Max(dp[i], dp[j] + 1);
            }
        }
        return dp.Max();
    }

    public static void Main(string[] args)
    {
        int[] nums = { 10, 9, 2, 5, 3, 7, 101, 18 };
        Solution solution = new Solution();
        int result = solution.LengthOfLIS(nums);
        Console.WriteLine("Longitud de la subsecuencia creciente más larga: " + result);
    }
}
