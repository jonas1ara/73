#include <iostream>
#include <vector>
#include <algorithm>

class Solution {
public:
    int rob(std::vector<int>& nums) {
        int rob = 0, skip = 0;
        for (int n : nums) {
            int r = n + skip, s = std::max(rob, skip);
            rob = r, skip = s;
        }
        return std::max(rob, skip);
    }
};

int main()
{
    std::vector<int> nums = { 1, 2, 3, 1 };
    Solution solution;
    std::cout << solution.rob(nums) << std::endl;
    
    return 0;
}
