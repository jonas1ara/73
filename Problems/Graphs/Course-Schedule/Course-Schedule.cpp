class Solution {
public:
    bool canFinish(int n, vector<vector<int>>& E) {
        vector<vector<int>> G(n);
        vector<int> indegree(n);
        for (auto &e : E) {
            G[e[1]].push_back(e[0]);
            ++indegree[e[0]];
        }
        queue<int> q;
        for (int i = 0; i < n; ++i) {
            if (indegree[i] == 0) q.push(i);
        }
        while (q.size()) {
            int u = q.front();
            q.pop();
            --n;
            for (int v : G[u]) {
                if (--indegree[v] == 0) q.push(v);
            }
        }
        return n == 0;
    }
};