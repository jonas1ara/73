#include <iostream>
#include <vector>

std::string longestCommonPrefix(std::vector<std::string> &A)
{
    int len = 0, N = A.size();
    for (; len <= A[0].size(); ++len)
    {
        int i = 1;
        for (; i < N && A[i].size() >= len && A[i][len] == A[0][len]; ++i)
            ;
        if (i < N)
            break;
    }
    return A[0].substr(0, len);
}

int main()
{
    std::vector<std::string> A = {"flower", "flow", "flight"};

    std::cout << "Input: [";
    for (int i = 0; i < A.size(); i++)
        std::cout << (i == 0 ? "" : ", ") << A[i];  // Ternary operator (?:) is used as a shortcut for the if-else statement.
    std::cout << "]" << std::endl;

    std::cout << "Output: " << longestCommonPrefix(A) << std::endl;

    return 0;
}