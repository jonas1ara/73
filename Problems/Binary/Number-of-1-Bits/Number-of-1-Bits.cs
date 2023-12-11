using System;

// Using Brian Kernighan's Algorithm - Time: O(1)

public class Solution
{
    public int HammingWeight(uint n)
    {
        int ans = 0;
        long ln = n;

        while (ln != 0)
        {
            ln -= (ln & -ln);
            ans++;
        }

        return ans;
    }
}

class Program
{
    static void Main(string[] args)
    {
        uint n = 0b00000000000000000000000000001011; // 11 decimal
        Console.WriteLine("Input: n = " + n);

        Solution sol = new Solution();
        int ans = sol.HammingWeight(n);

        // Print number of 1
        Console.WriteLine("Output: " + ans);
    }
}
