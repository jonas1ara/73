#include "../../../Libraries/ArrayPrinter.h"
#include <iostream>
#include <vector>
#include <climits>

// Fuerza Bruta O(n²)
// class Solution {
// public:
//     int maxArea(std::vector<int> &A)
//     {
//         int N = A.size(), ans = 0;
//         for (int i = 0; i < N; ++i)
//         {
//             if (!A[i])
//                 continue;
//             for (int j = i + 1 + ans / A[i]; j < N; ++j)
//             {
//                 ans = std::max(ans, std::min(A[i], A[j]) * (j - i));
//             }
//         }
//         return ans;
//     }
// };

// Dos Punteros O(n)
class Solution {
public:
    int maxArea(std::vector<int> &A)
    {
        int ans = 0, L = 0, R = A.size() - 1;
        while (L < R)
        {
            ans = std::max(ans, (R - L) * std::min(A[L], A[R]));
            if (A[L] < A[R])
                ++L; // Mover el borde más pequeño
            else
                --R;
        }
        return ans;
    }
};

int main()
{
    std::vector<int> height = {1, 8, 6, 2, 5, 4, 8, 3, 7};

    Solution sol;

    printArray(height);
    std::cout << "Output: " << sol.maxArea(height) << std::endl;

    return 0;
}