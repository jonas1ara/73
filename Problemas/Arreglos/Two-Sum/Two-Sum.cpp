#include "../../../Libraries/ArrayPrinter.h"
#include <iostream>
#include <vector>
#include <map>

// Fuerza Bruta O(n²)
// class Solution {
// public:
//     std::vector<int> twoSum(std::vector<int> &nums, int target)
//     {
//         int n = nums.size();
//         for (int i = 0; i < n - 1; i++)
//         {
//             for (int j = i + 1; j < n; j++)
//             {
//                 if (nums[i] + nums[j] == target)
//                 {
//                     return {i, j}; // Devolvemos el índice del elemento actual y el índice del complemento
//                 }
//             }
//         }
//         return {}; // Si no se encuentra ninguna pareja, se devuelve un vector vacío
//     }
// };

// Hash Map O(n)
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

    Solution sol;

    printInput(array, target);
    printOutput(sol.twoSum(array, target));

    return 0;
}