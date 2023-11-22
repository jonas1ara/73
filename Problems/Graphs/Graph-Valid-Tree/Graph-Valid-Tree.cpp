#include <iostream>
#include <vector>

using namespace std;

class Solution {
    vector<vector<int>> G;
    vector<int> state; // -1 unvisited, 0 visiting, 1 visited

    bool dfs(int u, int prev = -1) {
        if (state[u] != -1) return state[u];
        state[u] = 0;
        for (int v : G[u]) {
            if (prev == v) continue;
            if (!dfs(v, u)) return false;
        }
        return state[u] = 1;
    }

public:
    bool validTree(int n, vector<vector<int>>& E) {
        G.assign(n, {});
        state.assign(n, -1);
        for (auto &e : E) {
            G[e[0]].push_back(e[1]);
            G[e[1]].push_back(e[0]);
        }
        int cnt = 0;
        for (int i = 0; i < n; ++i) {
            if (state[i] == 1) continue;
            if (!dfs(i)) return false;
            ++cnt;
        }
        return cnt == 1;
    }
};

int main() {
    Solution sol;
    
    // Example usage
    int n = 5;
    vector<vector<int>> edges = {{0, 1}, {1, 2}, {2, 3}, {1, 3}};
    
    if (sol.validTree(n, edges)) {
        cout << "The given edges form a valid tree." << endl;
    } else {
        cout << "The given edges do not form a valid tree." << endl;
    }

    return 0;
}
