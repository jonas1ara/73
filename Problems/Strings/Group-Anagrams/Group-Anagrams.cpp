#include <iostream>
#include <vector>
#include <string>
#include <unordered_map>
#include <algorithm>

class Solution {
public:
    std::vector<std::vector<std::string>> groupAnagrams(std::vector<std::string>& A) {
        std::unordered_map<std::string, int> m;
        std::vector<std::vector<std::string>> ans;
        for (auto &s : A) {
            auto key = s;
            sort(begin(key), end(key));
            if (!m.count(key)) {
                m[key] = ans.size();
                ans.emplace_back();
            }
            ans[m[key]].push_back(s);
        }
        return ans;
    }
};

int main() {
    Solution solution;
    std::vector<std::string> input = { "eat", "tea", "tan", "ate", "nat", "bat" }; // Cambia las cadenas de entrada según tus necesidades

    std::vector<std::vector<std::string>> result = solution.groupAnagrams(input);

    std::cout << "Grupos de anagramas:" << std::endl;

    for (const std::vector<std::string>& group : result) {
        std::cout << "[ ";
        for (const std::string& word : group) {
            std::cout << word << " ";
        }
        std::cout << "]" << std::endl;
    }

    return 0;
}