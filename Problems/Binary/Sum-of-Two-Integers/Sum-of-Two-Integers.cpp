#include <iostream>

// Using bit manipulation - Time: O(1)

class Solution {
public:
    int getSum(int a, int b)
    {
        int carry = 0, ans = 0;

        for (int i = 0; i < 32; i++)
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

int main()
{
    int a = 1, b = 2;
    std::cout << "Input: a = " << a << ", b = " << b << std::endl;

    Solution sol;
    int result = sol.getSum(a, b);

    std::cout << "Output: " << result << std::endl;

    return 0;
}