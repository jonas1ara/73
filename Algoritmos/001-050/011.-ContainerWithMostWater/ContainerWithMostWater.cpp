#include <iostream>
#include <vector>

int maxArea(std::vector<int> &A)
{
    int ans = 0, L = 0, R = A.size() - 1;
    while (L < R)
    {
        ans = std::max(ans, (R - L) * std::min(A[L], A[R]));
        if (A[L] < A[R])
            ++L; 
        else
            --R;
    }
    return ans;
}

int main()
{
    std::vector<int> A = {1, 8, 6, 2, 5, 4, 8, 3, 7};

    std::cout << "Input: height = [";
    for (int i = 0; i < A.size(); ++i)
        std::cout << A[i] << (i + 1 < A.size() ? ", " : "");
    std::cout << "]" << std::endl;

    int result = maxArea(A);

    std::cout << "Output: " << result << std::endl;

    return 0;
}
