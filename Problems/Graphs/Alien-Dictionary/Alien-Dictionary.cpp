#include <iostream>
#include <vector>
#include <unordered_map>
#include <unordered_set>
#include <algorithm>

// Using topological sort - Time: O(V + E)

class Solution {
    std::unordered_map<int, std::unordered_set<int>> graph;
    int state[26];
    std::string ans;
    
    bool dfs(int u) 
    {
        if (state[u] == 0) return false; // Has a cycle
        if (state[u] == 1) return true;  // Node already visited
        
        state[u] = 0;

        for (int v : graph[u]) 
        {
            if (!dfs(v)) return false;
        }
        ans += 'a' + u;

        return state[u] = 1;
    }
    
public:
    Solution() 
    {
        for (int i = 0; i < 26; i++)
        {
            state[i] = -1;
        }
    }

    std::string alienOrder(std::vector<std::string>& words) 
    {
        for (auto &s : words) 
        {
            for (char c : s) graph[c - 'a'] = {};
        }
        
        for (int i = 1; i < words.size(); ++i) 
        {
            int j = 0;

            for (; j < std::min(words[i - 1].size(), words[i].size()); ++j) 
            {
                if (words[i - 1][j] == words[i][j]) continue;
                graph[words[i - 1][j] - 'a'].insert(words[i][j] - 'a');
                break;
            }

            if (j == words[i].size() && j < words[i - 1].size()) return ""; // Words don't match
        }
        
        for (auto &[from, tos] : graph) 
        {
            if (!dfs(from)) return ""; // Detected a cycle
        }
        
        reverse(begin(ans), end(ans));

        return ans.size() == graph.size() ? ans : ""; // All nodes visited
    }
};

int main() 
{
    // std::vector<std::string> words = {"wrt", "wrf", "er", "ett", "rftt"};
	std::vector<std::string> words = {"z" , "x"};

    std::cout << "Input: words = [";
    for (int i = 0; i < words.size(); i++)
    {
        std::cout << "\"" << words[i] << "\"";
        if (i < words.size() - 1)
        {
            std::cout << ", ";
        }
    }
    std::cout << "]" << std::endl;

    Solution sol;
	std::string result = sol.alienOrder(words);
    
    std::cout << "Output: " << result << std::endl;
    
    return 0;
}
