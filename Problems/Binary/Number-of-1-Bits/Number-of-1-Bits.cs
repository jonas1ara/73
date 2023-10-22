using System;

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

    public static void Main(string[] args)
    {
        uint n = 00000000000000000000000000001011;
        Console.WriteLine(new Solution().HammingWeight(n));
    }
}
