#include <iostream>
#include <sstream>
#include <queue>

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

int main()
{
    // Crear un árbol de ejemplo
    TreeNode *root = new TreeNode(1);
    root->left = new TreeNode(2);
    root->right = new TreeNode(3);
    root->left->left = new TreeNode(4);
    root->left->right = new TreeNode(5);

    // Crear un objeto Codec
    Codec codec;

    // Serializar el árbol
    std::string serialized = codec.serialize(root);
    std::cout << "Árbol serializado: " << serialized << std::endl;

    // Deserializar el árbol
    TreeNode *deserialized = codec.deserialize(serialized);

    // Mostrar el resultado
    std::cout << "Árbol deserializado: " << codec.serialize(deserialized) << std::endl;

    // Liberar la memoria del árbol
    delete root->left->left;
    delete root->left->right;
    delete root->left;
    delete root->right;
    delete root;

    return 0;
}
