class Solution {
public:
    bool exist(vector<vector<char>>& A, string s) {
        int M = A.size(), N = A[0].size(), dirs[4][2] = {{0,1},{0,-1},{1,0},{-1,0}};
        function<bool(int, int, int)> dfs = [&](int x, int y, int i) {
            if (x < 0 || x >= M || y < 0 || y >= N || A[x][y] != s[i]) return false;
            if (i + 1 == s.size()) return true;
            char c = A[x][y];
            A[x][y] = 0;
            for (auto &[dx, dy] : dirs) {
                if (dfs(x + dx, y + dy, i + 1)) return true;
            }
            A[x][y] = c;
            return false;
        };
        for (int i = 0; i < M; ++i) {
            for (int j = 0; j < N; ++j) {
                if (dfs(i, j, 0)) return true;
            }
        }
        return false;
    }
};