using System;

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
