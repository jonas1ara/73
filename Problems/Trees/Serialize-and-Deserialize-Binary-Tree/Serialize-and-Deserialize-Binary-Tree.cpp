#include <iostream>
#include <sstream>
#include <queue>

// Using preorder traversal - Time: O(n)

struct TreeNode
{
    int val;
    TreeNode *left;
    TreeNode *right;

    // TreeNode(int x) : val(x), left(NULL), right(NULL) {}

    TreeNode() : val(0), left(nullptr), right(nullptr) {}
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
    TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
};

class Codec
{
public:
    // Encodes a tree to a single string.
    std::string serialize(TreeNode *root)
    {
        if (root == nullptr)
        {
            return "null";
        }

        std::stringstream ss;
        serializeHelper(root, ss);

        return ss.str();
    }

    // Decodes your encoded data to tree.
    TreeNode *deserialize(std::string data)
    {
        std::queue<std::string> nodes = split(data, ',');

        return deserializeHelper(nodes);
    }

private:
    void serializeHelper(TreeNode *node, std::stringstream &ss)
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

    TreeNode *deserializeHelper(std::queue<std::string> &nodes)
    {
        std::string val = nodes.front();
        nodes.pop();

        if (val == "null")
        {
            return nullptr;
        }

        TreeNode *node = new TreeNode(std::stoi(val));
        node->left = deserializeHelper(nodes);
        node->right = deserializeHelper(nodes);

        return node;
    }

    std::queue<std::string> split(const std::string &s, char delimiter)
    {
        std::queue<std::string> tokens;
        std::stringstream ss(s);
        std::string token;
        while (getline(ss, token, delimiter))
        {
            tokens.push(token);
        }
        return tokens;
    }
};

void printTree(TreeNode *root)
{
    if (!root)
    {
        std::cout << "[]" << std::endl;
        return;
    }

    std::queue<TreeNode *> queue;
    queue.push(root);

    std::cout << "[";

    while (!queue.empty())
    {
        int n = queue.size();

        for (int i = 0; i < n; i++)
        {
            TreeNode *node = queue.front();
            queue.pop();

            if (node)
            {
                std::cout << node->val << ", ";

                queue.push(node->left);
                queue.push(node->right);
            }
            else
            {
                if (!queue.empty())
                    std::cout << "null, ";
                else
                    std::cout << "null";
            }
        }
    }

    std::cout << "]";
}

int main()
{
    // TreeNode *root = new TreeNode(1);
    // root->left = new TreeNode(2);
    // root->right = new TreeNode(3);
    // root->left->left = new TreeNode(4);
    // root->left->right = new TreeNode(5);

    TreeNode *root = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3));

    std::cout << "Input: root = ";
    printTree(root);
    std::cout << std::endl;

    Codec codec;
    std::string serialized = codec.serialize(root);

    std::cout << "Output: ";
    printTree(codec.deserialize(serialized));
    std::cout << std::endl;

    // delete root->left->left;
    // delete root->left->right;
    // delete root->left;
    // delete root->right;
    // delete root;

    delete root;

    return 0;
}
