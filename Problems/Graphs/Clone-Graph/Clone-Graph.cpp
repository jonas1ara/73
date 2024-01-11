#include <iostream>
#include <vector>
#include <unordered_map>
#include <queue>

// Using depth-first search - Time: O(n)

class Node {
public:
    int val;
    std::vector<Node *> neighbors;

    Node()
    {
        val = 0;
        neighbors = std::vector<Node *>();
    }

    Node(int _val)
    {
        val = _val;
        neighbors = std::vector<Node *>();
    }

    Node(int _val, std::vector<Node *> _neighbors)
    {
        val = _val;
        neighbors = _neighbors;
    }
};

class Solution {
    std::unordered_map<Node *, Node *> m;

public:
    Node *cloneGraph(Node *node)
    {
        if (!node)
            return nullptr;

        if (m.count(node))
            return m[node];

        auto cpy = new Node(node->val);
        m[node] = cpy;

        for (auto &n : node->neighbors)
        {
            cpy->neighbors.push_back(cloneGraph(n));
        }

        return cpy;
    }
};

int main()
{
    // Constructing the original graph
    Node *n1 = new Node(1);
    Node *n2 = new Node(2);
    Node *n3 = new Node(3);
    Node *n4 = new Node(4);

    n1->neighbors = {n2, n4};
    n2->neighbors = {n1, n3};
    n3->neighbors = {n2, n4};
    n4->neighbors = {n1, n3};

    std::cout << "Input: adjList = [";
    for (const auto &node : {n1, n2, n3, n4})
    {
        std::cout << "[";
        for (const auto &neighbor : node->neighbors)
        {
            std::cout << neighbor->val << "";
            if (neighbor != node->neighbors.back())
                std::cout << ", ";
        }
        std::cout << "]";
        if (node != n4)
            std::cout << ", ";
    }
    std::cout << "]" << std::endl;

    Solution sol;
    Node *clone = sol.cloneGraph(n1);

    std::cout << "Output: [";
    for (const auto &cloneNode : {clone, clone->neighbors[0], clone->neighbors[1]->neighbors[1], clone->neighbors[1]})
    {
        std::cout << "[";
        for (const auto &neighbor : cloneNode->neighbors)
        {
            std::cout << neighbor->val << "";
            if (neighbor != cloneNode->neighbors.back())
                std::cout << ", ";
        }
        std::cout << "]";
        if (cloneNode != clone->neighbors[1])
            std::cout << ", ";
    }
    std::cout << "]" << std::endl;

    delete n1;
    delete n2;
    delete n3;
    delete n4;

    return 0;
}
