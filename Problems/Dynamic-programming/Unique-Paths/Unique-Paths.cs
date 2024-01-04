using System;

// Using tabulation - Time: O(m*n)
public class Solution
{
    public int UniquePaths(int m, int n)
    {
        int[] dp = new int[n + 1];
        dp[n - 1] = 1;

        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                dp[j] += dp[j + 1];
            }
        }

        return dp[0];
    }
}

// Using math - Time: O(n)
//
// public class Solution 
// {
//     public int UniquePaths(int m, int n) 
//     {
//         long ans = 1;
//         for (int i = 1; i <= n - 1; i++) 
//         {
//             ans = ans * (m - 1 + i) / i;
//         }
//
//         return (int)ans; // Casting from long to int
//     }
// }

class Program
{
    static void Main(string[] args)
    {
        int m = 3, n = 7;
        Console.WriteLine("Input: m = " + m + ", n = " + n);

        Solution sol = new Solution();
        int result = sol.UniquePaths(m, n); 

        Console.WriteLine("Output: " + result);
    }
}