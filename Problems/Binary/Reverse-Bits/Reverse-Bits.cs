using System;
using System.Collections.Generic;

public class Solution
{
    public uint reverseBits(uint n)
    {
        uint ans = 0;
        for (int i = 0; i < 32; ++i)
        {
            ans = (ans << 1) | (n & 1);
            n >>= 1;
        }
        return ans;
    }

    public static void Main(string[] args)
    {
        Solution sol = new Solution();

        uint n = 43261596;
        Console.WriteLine(sol.reverseBits(n));
    }
}