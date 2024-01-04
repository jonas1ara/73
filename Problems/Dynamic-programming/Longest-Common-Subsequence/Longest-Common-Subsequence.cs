using System;

public class Solution
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        int m = text1.Length;
        int n = text2.Length;

        if (m < n)
        {
            (m, n) = (n, m);
            (text1, text2) = (text2, text1);
        }

        int[] dp = new int[n + 1];

        for (int i = 0; i < m; i++)
        {
            int prev = 0;

            for (int j = 0; j < n; j++)
            {

                int cur = dp[j + 1];
                if (text1[i] == text2[j])
                {
                    dp[j + 1] = prev + 1;
                }
                else
                {
                    dp[j + 1] = Math.Max(dp[j], dp[j + 1]);
                }
                prev = cur;
            }
        }

        return dp[n];
    }
}

class Program
{
    static void Main()
    {
        string text1 = "abcde";
        string text2 = "ace";

        Console.WriteLine("Input: text1 = " + text1 + ", text2 = " + text2);

        Solution sol = new Solution();
        int result = sol.LongestCommonSubsequence(text1, text2);

        Console.WriteLine("Output: " + result);
    }
}