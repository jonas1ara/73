#include "../../../Libraries/ArrayPrinter.h"
#include <unordered_set>
#include <algorithm>
#include <iostream>
#include <vector>

class Solution1 {
public:
    bool containsDuplicate(std::vector<int> &A)
    {
        std::unordered_set<int> s(begin(A), end(A));
        return s.size() != A.size();
    }
};

class Solution2
{
public:
    bool containsDuplicate(std::vector<int> &A)
    {
        sort(begin(A), end(A));
        for (int i = 1; i < A.size(); ++i)
        {
            if (A[i] == A[i - 1])
                return true;
        }
        return false;
    }
};

int main()
{
    std::vector<int> array = {7, 1, 5, 3, 6, 4};

    return 0;
}