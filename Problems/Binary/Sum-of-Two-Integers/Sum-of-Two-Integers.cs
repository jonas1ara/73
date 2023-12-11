using System;

// Using bit manipulation - Time: O(1)
public class Solution
{
    public int GetSum(int a, int b)
    {
        int carry = 0, ans = 0;

        for (int i = 0; i < 32; ++i)
        {
            int x = (a >> i & 1), y = (b >> i & 1);

            if (carry != 0)
            {
                if (x == y)
                {
                    ans |= 1 << i;
                    if (x == 0 && y == 0) carry = 0;
                }
            }
            else
            {
                if (x != y) ans |= 1 << i;
                if (x == 1 && y == 1) carry = 1;
            }
        }

        return ans;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int a = 1, b = 2;
        Console.WriteLine("Input: a = " + a + ", b = " + b);

        Solution sol = new Solution();
        int ans = sol.GetSum(a, b);

        Console.WriteLine("Output: " + ans);
    }
}
