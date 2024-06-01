#include <iostream>
#include <vector>
#include <map>

// Using hash table - Time: O(n)

class Solution {
public:
    std::vector<int> twoSum(std::vector<int> &nums, int target)
    {
        std::map<int, int> map;
        
		for (int i = 0; i < nums.size(); i++)
        {
            int t = target - nums[i];

            // If the map contains the key t, return the index of t and the current index i

            if (map.count(t))
                return {map[t], i}; 

            map[nums[i]] = i;       
        }

        return {}; 
    }
};

int main()
{
    std::vector<int> nums = {-1, 0, 1, 2, -1, -4};
    int target = 0;

    std::cout << "Input: nums = [";
    for (const auto &num : nums)
    {
        std::cout << num << "";
        if (&num != &nums.back())
        {
            std::cout << ", ";
        }
    }
    std::cout << "], target = " << target << std::endl;

    Solution sol;
    std::vector<int> result = sol.twoSum(nums, target);

    std::cout << "Output: [";
    for (const auto &r : result)
    {
        std::cout << r << "";
        if (&r != &result.back())
        {
            std::cout << ", ";
        }
    }
    std::cout << "]" << std::endl;

    return 0;
}