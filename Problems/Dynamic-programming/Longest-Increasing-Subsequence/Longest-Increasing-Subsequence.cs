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
        int[] nums = { 31, -41, 59, 26, -53, 58, 97, -93, -23, 84 };
        Solution solution = new Solution();
        int result = solution.LengthOfLIS(nums);
        Console.WriteLine("Longest Increasing Subsequence: " + result);
    }
}
