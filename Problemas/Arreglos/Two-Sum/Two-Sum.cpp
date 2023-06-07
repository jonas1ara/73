#include "../../../Libraries/ArrayPrinter.h"
#include <iostream>
#include <vector>
#include <map>

class Solution {
public:
    std::vector<int> twoSum(std::vector<int> &nums, int target)
    {
        std::map<int, int> map;
        for (int i = 0; i < nums.size(); ++i)
        {
            int t = target - nums[i]; // t(7) = 9 - 2, t(2) = 9 - 7
            if (map.count(t))
                return {map[t], i}; // map[t] = 0(donde se encontro el 2) e i = 1(donde se encuentra actualmente)
            map[nums[i]] = i;       // Recorremos una posición la tabla 0 --> 1
        }
        return {}; // En caso de que no se encuentre
    }
};

int main()
{
    std::vector<int> array = {-1, 0, 1, 2, -1, -4};
    int target = 0;

    Solution solution;

    printInput(array, target);
    printOutput(solution.twoSum(array, target));

    return 0;
}