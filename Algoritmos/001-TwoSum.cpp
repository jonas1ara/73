#include <iostream>
#include <vector>
#include <map>

std::vector<int> twoSum(std::vector<int>& array, int target);

int main()
{
    std::vector <int> array = { 2, 7, 11, 15 };
    int target = 9;   

    std::cout << "Input: nums = ";

    for (int i = 0; i < array.size(); i++)
        std::cout << "[" << array[i] << "]";

    std::cout << ", target = " << target << std::endl;

     std::vector <int> result = twoSum(array, target);

    std::cout << "Output: ";

    for (int i = 0; i < result.size(); i++)
    {
        std::cout << "[" << result[i] << "]";
    }
    
    std::cout <<"\n";
}

std::vector<int> twoSum(std::vector<int>& array, int target)
{
    std::map<int, int> map;
    for (int i = 0; i < array.size(); ++i)
    {
        int t = target - array[i]; 
        if (map.count(t)) return { map[t], i }; /
        map[array[i]] = i; 
    }
    return {}; 
}



