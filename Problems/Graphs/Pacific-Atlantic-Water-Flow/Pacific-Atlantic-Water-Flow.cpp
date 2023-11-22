#include <iostream>
#include <vector>

using namespace std;

class Solution {
    private:
        vector<vector<int>> dirs = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};
        int M, N;

        void dfs(vector<vector<int>> &A, int x, int y, vector<vector<int>> &m) {
            if (m[x][y] == 1) return;
            m[x][y] = 1;
            for (auto &dir : dirs) {
                int a = x + dir[0], b = y + dir[1];
                if (a < 0 || a >= M || b < 0 || b >= N || A[a][b] < A[x][y]) continue;
                dfs(A, a, b, m);
            }
        }

    public:
        vector<vector<int>> pacificAtlantic(vector<vector<int>> &A) {
            vector<vector<int>> ans;
            if (A.empty() || A[0].empty()) return ans;
            M = A.size(), N = A[0].size();
            vector<vector<int>> pacific(M, vector<int>(N)), atlantic(M, vector<int>(N)); 
            for (int i = 0; i < M; ++i) {
                dfs(A, i, 0, pacific);
                dfs(A, i, N - 1, atlantic);
            }
            for (int j = 0; j < N; ++j) {
                dfs(A, 0, j, pacific);
                dfs(A, M - 1, j, atlantic);
            }
            for (int i = 0; i < M; ++i) {
                for (int j = 0; j < N; ++j) {
                    if (pacific[i][j] == 1 && atlantic[i][j] == 1) {
                        ans.push_back({i, j});
                    }
                }
            }
            return ans;
        }
};

int main() {
    // Ejemplo de uso
    Solution sol;
    vector<vector<int>> input = {{1,2,2,3,5},
                                {3,2,3,4,4},
                                {2,4,5,3,1},
                                {6,7,1,4,5},
                                {5,1,1,2,4}};
    vector<vector<int>> result = sol.pacificAtlantic(input);

    // Imprimir el resultado
    for (auto &point : result) {
        cout << "(" << point[0] << ", " << point[1] << ") ";
    }
    cout << endl;

    return 0;
}
