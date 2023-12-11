#include <iostream>
#include <string>
#include <vector>
#include <algorithm>

// Using Manacher's algorithm - Time: O(n)

class Solution {
public:
    int countSubstrings(std::string s)
    {
        std::string t = "^*";
        for (char c : s)
        {
            t += c;
            t += '*';
        }
        t += '$';

        int n = s.size(); 
        int m = t.size();
        std::vector<int> r(m);
        r[1] = 1;
        int j = 1; 
        int ans = 0;

        for (int i = 2; i <= 2 * n; i++)
        {
            int cur = j + r[j] > i ? std::min(r[2 * j - i], j + r[j] - i) : 1;

            while (t[i - cur] == t[i + cur])
                cur++;

            if (i + cur > j + r[j])
                j = i;

            r[i] = cur;
            ans += r[i] / 2;
        }

        return ans;
    }
};

int main()
{
    std::string s = "abc";
    std::cout << "Input: s = " << s << std::endl;

    Solution sol;
    int result = sol.countSubstrings(s);

    std::cout << "Output: " << result << std::endl;
}