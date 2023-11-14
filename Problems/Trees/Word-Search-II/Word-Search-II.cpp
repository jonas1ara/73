struct TrieNode {
    TrieNode *next[26] = {};
    int cnt = 0;
    bool end = false;
};
class Solution {
    TrieNode root;
    void addWord(TrieNode *node, string &s) {
        for (char c : s) {
            if (!node->next[c - 'a']) node->next[c - 'a'] = new TrieNode();
            node = node->next[c - 'a'];
            node->cnt++;
        }
        node->end = true;
    }
public:
    vector<string> findWords(vector<vector<char>>& A, vector<string>& words) {
        for (auto &s : words) addWord(&root, s);
        int M = A.size(), N = A[0].size(), dirs[4][2] = {{0,1},{0,-1},{1,0},{-1,0}};
        vector<string> ans;
        string tmp;
        function<int(int, int, TrieNode*)> dfs = [&](int x, int y, TrieNode *node) {
            int c = A[x][y] - 'a', cnt = 0;
            if (!node->next[c] || !node->next[c]->cnt) return 0;
            node = node->next[c];
            tmp.push_back(A[x][y]);
            if (node->end) {
                ans.push_back(tmp);
                ++cnt;
                node->end = false;
            }
            A[x][y] = 0;
            for (auto &[dx, dy] : dirs) {
                int a = x + dx, b = y + dy;
                if (a < 0 || a >= M || b < 0 || b >= N || A[a][b] == 0) continue;
                cnt += dfs(a, b, node);
            }
            A[x][y] = 'a' + c;
            tmp.pop_back();
            node->cnt -= cnt;
            return cnt;
        };
        for (int i = 0; i < M; ++i) {
            for (int j = 0; j < N; ++j) {
                dfs(i, j, &root);
            }
        }
        return ans;
    }
};