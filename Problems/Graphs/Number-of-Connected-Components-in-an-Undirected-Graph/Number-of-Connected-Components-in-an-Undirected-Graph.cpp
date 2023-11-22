#include <iostream>
#include <vector>
#include <numeric>

using namespace std;

class UnionFind {
    vector<int> id;
    int cnt;

public:
    UnionFind(int n) : cnt(n), id(n) {
        iota(begin(id), end(id), 0);
    }

    int find(int a) {
        return id[a] == a ? a : (id[a] = find(id[a]));
    }

    void connect(int a, int b) {
        int p = find(a), q = find(b);
        if (p == q)
            return;
        id[p] = q;
        --cnt;
    }

    int getCount() {
        return cnt;
    }
};

class Solution {
public:
    int countComponents(int n, vector<vector<int>>& edges) {
        UnionFind uf(n);
        for (auto& e : edges) {
            uf.connect(e[0], e[1]);
        }
        return uf.getCount();
    }
};

int main() {
    // Ejemplo de uso
    Solution solution;
    int n = 5;
    //vector<vector<int>> edges = {{0, 1}, {1, 2}, {3,4}};
    vector<vector<int>> edges = {{0, 1}, {1, 2}, {2, 3},{3,4}};
    int result = solution.countComponents(n, edges);

    cout << "Number of Connected Components: " << result << endl;

    return 0;
}
