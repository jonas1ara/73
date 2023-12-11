using System;
using System.Collections.Generic;

// Using sliding window technique - Time: O(n)
public class Solution
{
    public string MinWindow(string s, string t)
    {
        int[] cnt = new int[128];
        foreach (char c in t)
        {
            cnt[c]++;
        }

        int n = s.Length;
        int i = 0, j = 0, start = -1, minLen = int.MaxValue, matched = 0;

        while (j < n)
        {
            if (cnt[s[j]] > 0)
            {
                matched++;
            }
            cnt[s[j]]--;
            j++;

            while (matched == t.Length)
            {
                if (j - i < minLen)
                {
                    minLen = j - i;
                    start = i;
                }

                if (cnt[s[i]] == 0)
                {
                    matched--;
                }
                cnt[s[i]]++;
                i++;
            }
        }

        return start == -1 ? "" : s.Substring(start, minLen);
    }
}

class Program
{
    static void Main(string[] args)
    {
        string s = "ADOBECODEBANC";
        string t = "ABC";
        Console.WriteLine("Input: s = " + s + ", t = " + t);

        Solution sol = new Solution();
        string result = sol.MinWindow(s, t);

        Console.WriteLine("Output: " + result);
    }
}
