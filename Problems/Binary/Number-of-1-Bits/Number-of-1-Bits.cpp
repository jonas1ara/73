#include <iostream>
#include <algorithm>

// Using Brian Kernighan's Algorithm - Time: O(1)

class Solution {
public:
    int hammingWeight(uint32_t n)
    {
        int ans = 0;

        for (; n; n -= (n & -n))
            ans++;

        return ans;
    }
};

int main()
{
    uint32_t n = 0b00000000000000000000000000001011; // 11 decimal

    Solution sol;
    int ans = sol.hammingWeight(n);

    printf("Input: n = %u\n", n);
    printf("Output: %d\n", ans);

    return 0;
}