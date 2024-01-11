#include <iostream>
#include <vector>
#include <queue>

// Using topological sort (bfs) - Time: O(n + m) where n = numCourses and m = prerequisites.Length

class Solution {
public:
    bool canFinish(int numCourses, std::vector<std::vector<int>> &prerequisites)
    {
        std::vector<std::vector<int>> graph(numCourses);
        std::vector<int> indegree(numCourses);

        for (auto &p : prerequisites)
        {
            graph[p[1]].push_back(p[0]);
            indegree[p[0]]++;
        }

        std::queue<int> q; // queue of nodes with indegree 0

        for (int i = 0; i < numCourses; i++)
        {
            if (indegree[i] == 0)
                q.push(i);
        }

        while (q.size())
        {
            int u = q.front();
            q.pop();
            numCourses--;

            for (int v : graph[u])
            {
                if (indegree[v]-- == 0)
                    q.push(v);
            }
        }

        return numCourses == 0;
    }
};

int main()
{
    int numCourses = 2;

    std::vector<std::vector<int>> prerequisites = {
        {1, 0},
        {0, 1}    
    };

    std::cout << "Input: numCourses = " << numCourses << ", prerequisites = [";
    for (auto &p : prerequisites)
    {
        std::cout << "[" << p[0] << ", " << p[1] << "], ";
        if (&p == &prerequisites.back())
            std::cout << "\b\b";
    }
    std::cout << "]" << std::endl;

    Solution sol;
    bool result = sol.canFinish(numCourses, prerequisites);

    std::cout << "Output: "<< std::boolalpha<< result << std::endl;

    return 0;
}