using System;

public class Solution
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        int M = text1.Length;
        int N = text2.Length;
        if (M < N)
        {
            (M, N) = (N, M);
            (text1, text2) = (text2, text1);
        }

        int[] dp = new int[N + 1];

        for (int i = 0; i < M; i++)
        {
            int prev = 0;
            for (int j = 0; j < N; j++)
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

        return dp[N];
    }

    public static void Main()
    {
        Solution solution = new Solution();
        string text1 = "abcde";
        string text2 = "ace";
        int result = solution.LongestCommonSubsequence(text1, text2);
        Console.WriteLine("Longest Common Subsequence: " + result);
    }
}