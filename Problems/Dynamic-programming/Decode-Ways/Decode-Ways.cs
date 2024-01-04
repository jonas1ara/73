using System;

// Using bottom-up approach - Time: O(n)

public class Solution
{
    public int NumDecodings(string s)
    {
        int pre2 = 0, pre1 = 1;

        for (int i = 0; i < s.Length && pre1 != 0; i++)
        {
            int cur = 0;

            if (s[i] != '0')
            {
                cur += pre1;
            }

            if (i != 0 && s[i - 1] != '0' && (s[i - 1] - '0') * 10 + s[i] - '0' <= 26)
            {
                cur += pre2;
            }
            
            pre2 = pre1;
            pre1 = cur;
        }

        return pre1;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string s = "12"; 
        Console.WriteLine("Input: s = " + s);

        Solution sol = new Solution();
        int result = sol.NumDecodings(s);

        Console.WriteLine("Output: " + result);
    }
}