#include "../../../Libraries/ArrayPrinter.h"
#include <iostream>
#include <vector>

class Solution {
public:
    int maxProduct(std::vector<int> &A)
    {
        int ans = A[0], N = A.size(), j = 0;
        while (j < N)
        {
            int i = j, prod = 1;
            while (j < N && A[j] != 0)
            {
                prod *= A[j++];
                ans = std::max(ans, prod);
            }
            if (j < N)
                ans = std::max(ans, 0);
            while (i < N && prod < 0)
            {
                prod /= A[i++];
                if (i != j)
                    ans = std::max(ans, prod);
            }
            while (j < N && A[j] == 0)
                ++j;
        }
        return ans;
    }
};

int main()
{
    std::vector <int> array = {2,3,-2,4};

    return 0;
}