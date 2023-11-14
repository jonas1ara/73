#include <iostream>
#include <sstream>
#include <queue>

using namespace std;

// Definition for a binary tree node.
struct TreeNode
{
    int val;
    TreeNode *left;
    TreeNode *right;
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
};

class Codec
{
public:
    // Encodes a tree to a single string.
    string serialize(TreeNode *root)
    {
        if (root == nullptr)
        {
            return "null";
        }

        stringstream ss;
        serializeHelper(root, ss);
        return ss.str();
    }

    // Decodes your encoded data to tree.
    TreeNode *deserialize(string data)
    {
        queue<string> nodes = split(data, ',');

        return deserializeHelper(nodes);
    }

private:
    void serializeHelper(TreeNode *node, stringstream &ss)
    {
        if (node == nullptr)
        {
            ss << "null,";
        }
        else
        {
            ss << node->val << ",";
            serializeHelper(node->left, ss);
            serializeHelper(node->right, ss);
        }
    }

    TreeNode *deserializeHelper(queue<string> &nodes)
    {
        string val = nodes.front();
        nodes.pop();
        if (val == "null")
        {
            return nullptr;
        }

        TreeNode *node = new TreeNode(stoi(val));
        node->left = deserializeHelper(nodes);
        node->right = deserializeHelper(nodes);

        return node;
    }

    queue<string> split(const string &s, char delimiter)
    {
        queue<string> tokens;
        stringstream ss(s);
        string token;
        while (getline(ss, token, delimiter))
        {
            tokens.push(token);
        }
        return tokens;
    }
};

// Tu objeto Codec se instanciará y se llamará de la siguiente manera:
// Codec ser;
// Codec deser;
// TreeNode* ans = deser.deserialize(ser.serialize(root));
