#include <iostream>
#include <string>
#include <vector>

std::string longestPalindrome(std::string s)
{
    int N = s.size(), start = 0, len = 0;
    bool dp[1001][1001] = {};
    for (int i = N - 1; i >= 0; --i)
    {
        for (int j = i; j < N; ++j)
        {
            if (i == j)
                dp[i][j] = true;
            else
                dp[i][j] = s[i] == s[j] && (i + 1 > j - 1 || dp[i + 1][j - 1]);
            if (dp[i][j] && j - i + 1 > len)
            {
                start = i;
                len = j - i + 1;
            }
        }
    }
    return s.substr(start, len);
}

int main()
{
    std::string s = "babad";

    std::cout << "Input: s = " << s << std::endl;

    std::string result = longestPalindrome(s);

    std::cout << "Output: " << result << std::endl;
    
    return 0;
}