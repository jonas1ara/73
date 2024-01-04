using System;

// Using tabulation - Time: O(n^2)

public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        if (nums.Length == 0) return 0;

        int n = nums.Length;
        int[] dp = new int[n];
        
        for (int i = 0; i < n; i++)
        {
            dp[i] = 1; 
        }
        
        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[j] < nums[i]) dp[i] = Math.Max(dp[i], dp[j] + 1);
            }
        }
        
        return dp.Max();
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] nums = { 31, -41, 59, 26, -53, 58, 97, -93, -23, 84 };

        Console.WriteLine("Input: nums = [" + string.Join(", ", nums) + "]");

        Solution sol = new Solution();
        int result = sol.LengthOfLIS(nums);
    
        Console.WriteLine("Output: " + result);
    }
}
