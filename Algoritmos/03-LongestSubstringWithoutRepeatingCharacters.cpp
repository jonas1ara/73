#include <iostream>
#include <string>
#include <map>

int lengthOfLongestSubstring(std::string s)
{
    int ans = 0, start = -1;
    std::map<int, int> map;
    for (int i = 0; i < s.size(); ++i)
    {
        start = std::max(start, map[s[i]]);
        map[s[i]] = i;
        ans = std::max(ans, i - start);
    }
    return ans;
}

int main()
{
    std::string s = "bbbb";
    std::cout << "Input: '" << s << "'" << std::endl ;

    std::cout << "Output: " << lengthOfLongestSubstring(s) << std::endl;

    std::cin.get();
} 


