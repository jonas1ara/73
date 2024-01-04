#include <iostream>
#include <vector>
#include <algorithm>

// Using bottom-up approach - Time: O(n)

class Solution {
public:
    int rob(std::vector<int>& nums) 
    {
        int rob = 0, skip = 0;
    
        for (int n : nums) 
        {
            int r = n + skip, s = std::max(rob, skip);
            rob = r, skip = s;
        }
        
        return std::max(rob, skip);
    }
};

int main()
{
    std::vector<int> nums = { 1, 2, 3, 1 };
    std::cout << "Input: nums = [";
    for (int i = 0; i < nums.size(); i++)
    {
        std::cout << nums[i];
        if (i != nums.size() - 1)
            std::cout << ", ";
    }
    std::cout << "]" << std::endl;

    Solution sol;
    int result = sol.rob(nums);
    
    std::cout << "Output: "<< result << std::endl;

    return 0;
}
