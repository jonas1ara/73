using System;
using System.Collections.Generic;

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
        int N = s.Length;
        int M = t.Length;
        List<int> r = new List<int>(new int[M]);
        r[1] = 1;
        int j = 1;
        int ans = 0;

        for (int i = 2; i <= 2 * N; ++i)
        {
            int cur = j + r[j] > i ? Math.Min(r[2 * j - i], j + r[j] - i) : 1;

            while (t[i - cur] == t[i + cur])
            {
                ++cur;
            }

            if (i + cur > j + r[j])
            {
                j = i;
            }

            r[i] = cur;
            ans += r[i] / 2;
        }

        return ans;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        string input = "abc";
        int result = solution.CountSubstrings(input);
        Console.WriteLine("Número de subcadenas palindrómicas: " + result);
    }
}
