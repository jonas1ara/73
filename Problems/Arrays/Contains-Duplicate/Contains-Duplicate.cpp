#include "../../../Libraries/ArrayPrinter.h"
#include <unordered_set>
#include <algorithm>
#include <iostream>
#include <vector>

class Solution {
public:
    bool containsDuplicate(std::vector<int> &nums)
    {
        std::unordered_set<int> s(begin(nums), end(nums));
        return s.size() != nums.size();
    }
};

int main()
{
    std::vector<int> nums = {7, 1, 5, 3, 6, 4};

    return 0;
}