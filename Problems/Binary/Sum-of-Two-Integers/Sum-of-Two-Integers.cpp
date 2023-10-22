#include <iostream>

class Solution
{
public:
    int getSum(int a, int b)
    {
        int carry = 0, ans = 0;
        for (int i = 0; i < 32; ++i)
        {
            int x = (a >> i & 1), y = (b >> i & 1);
            if (carry)
            {
                if (x == y)
                {
                    ans |= 1 << i;
                    if (!x & !y)
                        carry = 0;
                }
            }
            else
            {
                if (x != y)
                    ans |= 1 << i;
                if (x & y)
                    carry = 1;
            }
        }
        return ans;
    }
};