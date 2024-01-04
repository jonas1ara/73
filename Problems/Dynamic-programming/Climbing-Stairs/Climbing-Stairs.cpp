#include <iostream>

// Using bottom-up approach - Time: O(n)

class Solution {
public:
    int climbStairs(int n)
    {
        int ans = 1, prev = 1;
        while (--n)
        {
            ans += prev;
            prev = ans - prev;
        }

        return ans;
    }
};

int main()
{
    int n = 5;
    std::cout << "Input: " << n << std::endl;

    Solution sol;
    int result = sol.climbStairs(n);

    std::cout << "Output: " << result << std::endl;

    return 0;
}