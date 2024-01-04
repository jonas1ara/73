using System;
using System.Collections.Generic;

// Using bottom-up approach - Time: O(n^2)

public class Solution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        HashSet<string> st = new HashSet<string>(wordDict);
        int n = s.Length, minLen = int.MaxValue, maxLen = 0;

        foreach (string w in wordDict)
        {
            minLen = Math.Min(minLen, w.Length);
            maxLen = Math.Max(maxLen, w.Length);
        }
        
        bool[] dp = new bool[n + 1];
        dp[0] = true;
        
        for (int i = 1; i <= n; i++)
        {
            for (int len = minLen; len <= maxLen && i - len >= 0 && !dp[i]; len++)
            {
                dp[i] = dp[i - len] && st.Contains(s.Substring(i - len, len));
            }
        }

        return dp[n];
    }
}

class Program
{
    static void Main(string[] args)
    {
        string s = "leetcode";
        IList<string> wordDict = new List<string> { "leet", "code" };

        Console.Write("Input: s = " + s + ", wordDict = [");
        foreach (string w in wordDict)
        {
            Console.Write(w + "");
            if (w != wordDict[wordDict.Count - 1])
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");

        
        Solution sol = new Solution();
        bool result = sol.WordBreak(s, wordDict);
        
        Console.WriteLine("Output: " + result);
    }
}
