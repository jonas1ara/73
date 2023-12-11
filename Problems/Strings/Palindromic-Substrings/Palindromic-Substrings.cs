using System;
using System.Collections.Generic;

// Using Manacher's algorithm - Time: O(n)
public class Solution
{
    public int CountSubstrings(string s)
    {
        string t = "^*";
        foreach (char c in s)
        {
            t += c;
            t += '*';
        }
        t += '$';

        int n = s.Length;
        int m = t.Length;
        List<int> r = new List<int>(new int[m]);
        r[1] = 1;
        int j = 1;
        int ans = 0;

        for (int i = 2; i <= 2 * n; i++)
        {
            int cur = j + r[j] > i ? Math.Min(r[2 * j - i], j + r[j] - i) : 1;

            while (t[i - cur] == t[i + cur])
                cur++;

            if (i + cur > j + r[j])
                j = i;

            r[i] = cur;
            ans += r[i] / 2;
        }

        return ans;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string s = "abc";
        Console.WriteLine("Input: s = " + s);

        Solution sol = new Solution();
        int result = sol.CountSubstrings(s);
        Console.WriteLine("Output: " + result);
    }
}
