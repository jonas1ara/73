#include "../../../Libraries/ArrayPrinter.h"
#include <iostream>
#include <vector>

class Solution {
public:
    int findMin(std::vector<int> &A)
    {
        int L = 0, R = A.size() - 1;
        while (L < R)
        {
            int M = (L + R) / 2;
            if (A[M] > A[R])
                L = M + 1;
            else
                R = M;
        }
        return A[L];
    }
};

int main()
{
    std::vector<int> array = {3, 4, 5, 1, 2};

    return 0;
}