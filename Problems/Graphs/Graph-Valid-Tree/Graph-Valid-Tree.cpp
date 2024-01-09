#include <iostream>
#include <vector>

// Using depth-first search - Time: O(n)

class Solution {
    std::vector<std::vector<int>> graph;
    std::vector<int> state; // -1 unvisited, 0 visiting, 1 visited

    bool dfs(int u, int prev = -1)
    {
        if (state[u] != -1)
            return state[u];
        state[u] = 0;
        for (int v : graph[u])
        {
            if (prev == v)
                continue;
            if (!dfs(v, u))
                return false;
        }
        return state[u] = 1;
    }

public:
    bool validTree(int n, std::vector<std::vector<int>> &E)
    {
        graph.assign(n, {});
        state.assign(n, -1);
        for (auto &e : E)
        {
            graph[e[0]].push_back(e[1]);
            graph[e[1]].push_back(e[0]);
        }

        int cnt = 0;

        for (int i = 0; i < n; i++)
        {
            if (state[i] == 1)
                continue;
            if (!dfs(i))
                return false;
            cnt++;
        }

        return cnt == 1;
    }
};

int main()
{
    int n = 5;
    std::vector<std::vector<int>> edges = {
        {0, 1}, 
        {1, 2}, 
        {2, 3}, 
        {1, 3}
    };

    std::cout << "Input: n = " << n << ", edges = [";
    for (int i = 0; i < edges.size(); i++)
    {
        std::cout << "[" << edges[i][0] << ", " << edges[i][1] << "]";
        if (i != edges.size() - 1)
        {
            std::cout << ", ";
        }
    }
    std::cout << "]" << std::endl;

    Solution sol;
    bool result = sol.validTree(n, edges);

    std::cout << "Output: " << (result ? "True" : "False") << std::endl;

    return 0;
}
