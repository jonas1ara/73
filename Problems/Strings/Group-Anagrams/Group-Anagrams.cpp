#include <iostream>
#include <vector>
#include <string>
#include <unordered_map>
#include <algorithm>

// Using hash map - Time complexity: O(NKlogK), where N is the length of strs, and K is the maximum length of a string in strs.

class Solution {
public:
    std::vector<std::vector<std::string>> groupAnagrams(std::vector<std::string> &strs)
    {
        std::unordered_map<std::string, int> m;
        std::vector<std::vector<std::string>> ans;

        for (auto &s : strs)
        {
            auto key = s;
            sort(begin(key), end(key));
            if (!m.count(key))
            {
                m[key] = ans.size();
                ans.emplace_back();
            }
            ans[m[key]].push_back(s);
        }

        std::reverse(ans.begin(), ans.end());
        return ans;
    }
};

int main()
{
    std::vector<std::string> input = {"eat", "tea", "tan", "ate", "nat", "bat"};
    std::cout << "Input: [";
    for (const std::string &word : input)
    {
        std::cout << word << "";
        if (word != input.back())
        {
            std::cout << ", ";
        }
    }
    std::cout << "]" << std::endl;


    Solution sol;
    std::vector<std::vector<std::string>> result = sol.groupAnagrams(input);

    std::cout << "Output: [";

    for (const std::vector<std::string> &group : result)
    {
        std::cout << "[";
        for (const std::string &word : group)
        {
            std::cout << word << "";
            if (word != group.back())
            {
                std::cout << ", ";
            }
        }
        std::cout << "]";
        if (group != result.back())
        {
            std::cout << ", ";
        }
    }
    std::cout << "]" << std::endl;

    return 0;
}