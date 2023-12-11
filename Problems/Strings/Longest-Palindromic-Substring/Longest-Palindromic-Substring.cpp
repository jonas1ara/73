#include <iostream>
#include <string>
#include <vector>
#include <algorithm>

// Using Manacher's algorithm - Time: O(n)

class Solution {
public:
    std::string longestPalindrome(std::string s)
    {
        if (s.empty() || s.length() == 1)
            return s;

        int n2 = s.length() * 2 + 1;
        std::vector<char> s2(n2);

        for (int i = 0; i < s.length(); i++)
        {
            s2[i * 2] = '#';
            s2[i * 2 + 1] = s[i];
        }
        s2[n2 - 1] = '#';

        std::vector<int> p(n2, 0);
        int rangeMax = 0, center = 0;
        int longestCenter = 0;

        for (int i = 1; i < n2 - 1; i++)
        {
            if (rangeMax > i)
                p[i] = std::min(p[2 * center - i], rangeMax - i);

            while (i - 1 - p[i] >= 0 && i + 1 + p[i] < n2 && s2[i - 1 - p[i]] == s2[i + 1 + p[i]])
                p[i]++;

            if (i + p[i] > rangeMax)
            {
                center = i;
                rangeMax = i + p[i];
            }

            if (p[i] > p[longestCenter])
                longestCenter = i;
        }

        int range = p[longestCenter];
        return s.substr((longestCenter - range) / 2, range);
    }
};

int main()
{
    std::string input = "babad"; 
    std::cout << "Input: s = " << input << std::endl;

    Solution sol;
    std::string result = sol.longestPalindrome(input);

    std::cout << "Output: " << result << std::endl;

    return 0;
}