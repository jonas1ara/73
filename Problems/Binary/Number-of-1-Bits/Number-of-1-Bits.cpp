#include <iostream>
#include <algorithm>

class Solution
{
public:
    int hammingWeight(uint32_t n)
    {
        int ans = 0;
        for (; n; n -= (n & -n))
            ++ans;
        return ans;
    }
};