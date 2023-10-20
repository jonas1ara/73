#include <iostream>
#include <string>
#include <vector>
#include <algorithm>

class Solution {
public:
    int countSubstrings(std::string s) {
        std::string t = "^*";
        for (char c : s) {
            t += c;
            t += '*';
        }
        t += '$';
        int N = s.size(), M = t.size();
        std::vector<int> r(M);
        r[1] = 1;
        int j = 1, ans = 0;
        for (int i = 2; i <= 2 * N; ++i) {
            int cur = j + r[j] > i ? std::min(r[2 * j - i], j + r[j] - i) : 1;
            while (t[i - cur] == t[i + cur]) ++cur;
            if (i + cur > j + r[j]) j = i;
            r[i] = cur;
            ans += r[i] / 2;
        }
        return ans;
    }
};

int main()
{
    
}