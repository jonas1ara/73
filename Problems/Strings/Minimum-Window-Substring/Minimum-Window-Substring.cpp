#include <iostream>
#include <string>
#include <climits>

class Solution {
public:
    std::string minWindow(std::string s, std::string t) {
        int cnt[128] = {};
        for (char c : t)
            cnt[c]++;
        int N = s.size(), i = 0, j = 0, start = -1, minLen = INT_MAX, matched = 0;
        while (j < N) {
            matched += --cnt[s[j++]] >= 0;
            while (matched == t.size()) {
                if (j - i < minLen)
                    minLen = j - i, start = i;
                matched -= ++cnt[s[i++]] > 0;
            }
        }
        return start == -1 ? "" : s.substr(start, minLen);
    }
};

int main() {
    Solution solution;
    std::string s = "ADOBECODEBANC";
    std::string t = "ABC";

    std::string result = solution.minWindow(s, t);

    std::cout << "Ventana mínima: " << result << std::endl;

    return 0;
}
