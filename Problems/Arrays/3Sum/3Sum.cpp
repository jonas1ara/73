#include <algorithm>
#include <iostream>
#include <vector>
#include <map>

// Using two pointers technique - Time: O(n^2)

class Solution {
public:
    std::vector<std::vector<int>> threeSum(std::vector<int> &nums)
    {
        std::vector<std::vector<int>> result;
        int n = nums.size();
        
        if (n < 3){ return result; }

        sort(nums.begin(), nums.end());

        for (int i = 0; i < n - 2; i++)
        {
            if (nums[i] > 0)
            {
                break;
            }
            if (i > 0 && nums[i - 1] == nums[i])
            {
                continue;
            }

            int j = i + 1;
            int k = n - 1;

            while (j < k)
            {
                int sum = nums[i] + nums[j] + nums[k];

                if (sum < 0)
                {
                    j++;
                }
                else if (sum > 0)
                {
                    k--;
                }
                else
                {
                    result.push_back({nums[i], nums[j], nums[k]});

                    while (j < k && nums[j] == nums[j + 1])
                    {
                        j++;
                    }
                    j++;

                    while (j < k && nums[k - 1] == nums[k])
                    {
                        k--;
                    }
                    k--;
                }
            }
        }
        
        return result;
    }
};

int main()
{
    std::vector<int> nums = {-1, 0, 1, 2, -1, -4};

    // Print input
    std::cout << "Input: nums = [";

    for (const auto &num : nums)
    {
        std::cout << num << ", ";
        if (num == nums.back())
        {
            std::cout << "\b\b";
        }
    }
    std::cout << "]" << std::endl;

    Solution sol;

    std::vector<std::vector<int>> result = sol.threeSum(nums);

    // Print output
    std::cout << "Output: " ;
    for (const auto &vec : result)
    {
        if (vec == result.front())
            std::cout << "[[";
        else
            std::cout << "[";

        for (const auto &num : vec)
        {
            std::cout << num << ", ";
            if (num == vec.back())
            {
                std::cout << "\b\b";
            }
        }
        if (vec == result.back()) 
                std::cout << "]] \n" ;
        else
                std::cout << "], " ;
    }

    return 0;
}
