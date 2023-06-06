#include <iostream>
#include <vector>
#include <climits>

int maxArea(std::vector<int> &A)
{
    int ans = 0, L = 0, R = A.size() - 1;
    while (L < R)
    {
        ans = std::max(ans, (R - L) * std::min(A[L], A[R]));
        if (A[L] < A[R])
            ++L; // Move the smaller edge
        else
            --R;
    }
    return ans;
}

int main()
{

    std::vector<int> height = {1,8,6,2,5,4,8,3,7}; 
    
    std::cout << "Input: height = [";
    for (const auto& element : height) {
        std::cout << element << ", ";
    }
    std::cout << "]";

    std::cout << "\nOutput: " << maxArea(height) << std::endl;

    return 0;
}