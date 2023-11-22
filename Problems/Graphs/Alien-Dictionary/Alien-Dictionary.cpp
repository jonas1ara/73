#include <iostream>
#include <vector>
#include <unordered_map>
#include <unordered_set>
#include <algorithm>

using namespace std;

class Solution {
    unordered_map<int, unordered_set<int>> G;
    int state[26];
    string ans;
    
    bool dfs(int u) {
        if (state[u] == 0) return false; // Se detectó un ciclo
        if (state[u] == 1) return true;  // Ya se visitó este nodo
        
        state[u] = 0;
        for (int v : G[u]) {
            if (!dfs(v)) return false;
        }
        ans += 'a' + u;
        return state[u] = 1;
    }
    
public:
    Solution() {
        // Inicializa state con -1
        for (int i = 0; i < 26; ++i) {
            state[i] = -1;
        }
    }

    string alienOrder(vector<string>& A) {
        for (auto &s : A) {
            for (char c : s) G[c - 'a'] = {};
        }
        
        for (int i = 1; i < A.size(); ++i) {
            int j = 0;
            for (; j < min(A[i - 1].size(), A[i].size()); ++j) {
                if (A[i - 1][j] == A[i][j]) continue;
                G[A[i - 1][j] - 'a'].insert(A[i][j] - 'a');
                break;
            }
            if (j == A[i].size() && j < A[i - 1].size()) return ""; // Las palabras están mal ordenadas
        }
        
        for (auto &[from, tos] : G) {
            if (!dfs(from)) return ""; // Se detectó un ciclo durante el DFS
        }
        
        reverse(begin(ans), end(ans));
        return ans.size() == G.size() ? ans : ""; // Verifica que todos los nodos fueron visitados
    }
};

int main() {
    Solution sol;
    // vector<string> words = {"wrt", "wrf", "er", "ett", "rftt"};
    
	vector<string> words = {"z" , "x"};
	string result = sol.alienOrder(words);
    
    cout << "Alien Order: " << result << endl;
    
    return 0;
}
