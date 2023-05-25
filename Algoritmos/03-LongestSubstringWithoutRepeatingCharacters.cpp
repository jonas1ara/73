#include <iostream>
#include <string>
#include <vector>
#include <algorithm>

int lengthOfLongestSubstring(std::string s)
{
    int ans = 0, start = -1;
    std::vector<int> m(128, -1);
    for (int i = 0; i < s.size(); ++i)
    {
        start = std::max(start, m[s[i]]);

        ans = std::max(ans, i - start);

        m[s[i]] = i;
    }
    return ans;
}

int main()
{
    std::string s = " ";
    std::cout << "Input: '" << s << "'" << std::endl;

    std::cout << "Output: " << lengthOfLongestSubstring(s) << std::endl;

    std::cin.get();
}
