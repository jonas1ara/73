#include <iostream>
#include <map>
#include <vector>

std::vector<int> twoSum(std::vector<int> &nums, int target)
{
    std::map<int, int> map;
    for (int i = 0; i < nums.size(); ++i)
    {
        int t = target - nums[i]; // t(7) = 9 - 2, t(2) = 9 - 7
        if (map.count(t))
            return {map[t], i}; // map[t] = 0(donde se encontro el 2) e i = 1(donde se encuentra actualmente)
        map[nums[i]] = i;      // Recorremos una posición la tabla 0 --> 1
    }
    return {}; // En caso de que no se encuentre
}

int main()
{
    std::vector<int> nums = {2, 7, 11, 15};
    int target = 9;

    std::vector<int> result = twoSum(nums, target);

    std::cout << "Input: nums = ";

    for (int i = 0; i < nums.size(); i++)
        std::cout << "[" << nums[i] << "]";

    std::cout << ", target = " << target << std::endl;

    std::cout << "Output: ";

    for (int i = 0; i < result.size(); i++)
    {
        std::cout << "[" << result[i] << "]";
    }

    std::cout << "\n";

    // std::cin.get();
}
