/*
// Definition for a Node.
class Node {
public:
    int val;
    vector<Node*> neighbors;
    Node() {
        val = 0;
        neighbors = vector<Node*>();
    }
    Node(int _val) {
        val = _val;
        neighbors = vector<Node*>();
    }
    Node(int _val, vector<Node*> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
};
*/

class Solution {
public:
    Node* cloneGraph(Node* node) {
        if (!node) return nullptr;
        queue<Node*> q;
        unordered_map<Node*, Node*> m;
        m[node] = new Node(node->val);
        q.push(node);
        while (q.size()) {
            auto p = q.front();
            q.pop();
            auto copy = m[p];
            for (auto nei : p->neighbors) {
                if (!m.count(nei)) {
                    m[nei] = new Node(nei->val);
                    q.push(nei);
                }
                copy->neighbors.push_back(m[nei]);
            }
        }
        return m[node];
    }
};