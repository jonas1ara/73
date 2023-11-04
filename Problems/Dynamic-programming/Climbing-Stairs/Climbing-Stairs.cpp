#include <iostream>

class Solution
{
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
    Solution solution;
    std::cout << solution.climbStairs(2) << std::endl;
    
    return 0;
}