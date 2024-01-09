#include <iostream>
#include <vector>
#include <numeric>

// Using union find algorithm - Time: O(V + E)

class unionFind
{
    std::vector<int> id;
    int cnt;

public:
    unionFind(int n) : cnt(n), id(n)
    {
        iota(begin(id), end(id), 0);
    }

    int find(int a)
    {
        return id[a] == a ? a : (id[a] = find(id[a]));
    }

    void connect(int a, int b)
    {
        int p = find(a); 
        int q = find(b);
        
        if (p == q)
            return;
        id[p] = q;

        cnt--;
    }

    int getCount()
    {
        return cnt;
    }
};

class Solution
{
public:
    int countComponents(int n, std::vector<std::vector<int>> &edges)
    {
        unionFind uf(n);
        
        for (auto &e : edges)
        {
            uf.connect(e[0], e[1]);
        }

        return uf.getCount();
    }
};

int main()
{
    int n = 5;
    // std::vector<std::vector<int>> edges = {{0, 1}, {1, 2}, {3,4}};
    std::vector<std::vector<int>> edges = {
        {0, 1},
        {1, 2},
        {2, 3},
        {3, 4}
    };

    std::cout << "Input: n = " << n << ", edges = [";
    for (int i = 0; i < edges.size(); i++)
    {
        std::cout << "[" << edges[i][0] << ", " << edges[i][1] << "]";
        if (i != edges.size() - 1)
            std::cout << ", ";
    }
    std::cout << "]" << std::endl;

    Solution sol;
    int result = sol.countComponents(n, edges);

    std::cout << "Output: " << result << std::endl;

    return 0;
}
