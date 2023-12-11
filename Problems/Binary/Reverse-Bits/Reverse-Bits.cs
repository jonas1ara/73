using System;
using System.Collections.Generic;

// Using bit manipulation - Time: O(1)
public class Solution
{
    public uint reverseBits(uint n)
    {
        uint ans = 0;
        for (int i = 0; i < 32; i++)
        {
            ans = (ans << 1) | (n & 1);
            n >>= 1;
        }

        return ans;
    }
}

class Program
{
    static void Main()
    {
        uint n = 43261596; // 00000010100101000001111010011100
        Console.WriteLine("Input: n = " + n);

        Solution sol = new Solution();
        uint reversed = sol.reverseBits(n); // 964176192 (00111001011110000010100101000000)
        
        Console.WriteLine("Output: " + reversed);
    }
}