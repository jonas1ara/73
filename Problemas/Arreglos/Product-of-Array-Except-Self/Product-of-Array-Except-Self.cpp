#include "../../../Libraries/ArrayPrinter.h"
#include <iostream>
#include <vector>

class Solution {
public:
    std::vector<int> productExceptSelf(std::vector<int> &A)
    {
        int N = A.size(), left = 1, right = 1;
        std::vector<int> ans(N, 1);
        for (int i = 0, j = N - 1; i < N; ++i, --j)
        {
            ans[i] *= left;
            left *= A[i];
            ans[j] *= right;
            right *= A[j];
        }
        return ans;
    }
};

int main()
{
    std::vector<int> array = {1, 2, 3, 4};

    return 0;
}