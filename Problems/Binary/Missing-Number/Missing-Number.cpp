#include <iostream>
#include <vector>

// Using XOR operation - Time: O(n)

class Solution {
public:
    int missingNumber(std::vector<int> &nums)
    {
        int n = nums.size(); 
        int xorVal = 0;
        
        for (int i = 0; i < n; ++i)
            xorVal ^= nums[i] ^ (i + 1);

        return xorVal;
    }
};

int main()
{
    std::vector<int> nums = {3, 0, 1}; 
    
    Solution sol;
    int ans = sol.missingNumber(nums);

    std::cout << "Input: nums = [";
    for (int num : nums) 
    {
        std::cout << num << "";
        if (num != nums.back())
            std::cout << ", ";
    }
    std::cout << "]\n";

    std::cout << "Output: " << ans << std::endl;

    return 0;
}