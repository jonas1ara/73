using System;
using System.Collections.Generic;

public class Solution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        HashSet<string> st = new HashSet<string>(wordDict);
        int N = s.Length, minLen = int.MaxValue, maxLen = 0;
        foreach (string w in wordDict)
        {
            minLen = Math.Min(minLen, w.Length);
            maxLen = Math.Max(maxLen, w.Length);
        }
        bool[] dp = new bool[N + 1];
        dp[0] = true;
        for (int i = 1; i <= N; i++)
        {
            for (int len = minLen; len <= maxLen && i - len >= 0 && !dp[i]; len++)
            {
                dp[i] = dp[i - len] && st.Contains(s.Substring(i - len, len));
            }
        }
        return dp[N];
    }

    static void Main(string[] args)
    {
        Solution solution = new Solution();
        string s = "leetcode";
        IList<string> wordDict = new List<string> { "leet", "code" };
        bool result = solution.WordBreak(s, wordDict);
        Console.WriteLine("Result: " + result);
    }
}
