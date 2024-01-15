#include <iostream>
#include <queue>

// Using in-order traversal - Time O(n)

struct TreeNode
{
    int val;
    TreeNode *left;
    TreeNode *right;
    TreeNode() : val(0), left(nullptr), right(nullptr) {}
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
    TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
};

class Solution {
    TreeNode *prev = NULL;

public:
    bool isValidBST(TreeNode *root)
    {
        if (!root)
            return true;

        if (!isValidBST(root->left) || (prev && prev->val >= root->val))
            return false;

        prev = root;

        return isValidBST(root->right);
    }
};

    // Función para imprimir el árbol
    void printTree(TreeNode *root)
    {
        if (!root)
            return;

        std::queue<TreeNode *> q;
        q.push(root);

        while (!q.empty())
        {
            int n = q.size();

            for (int i = 0; i < n; i++)
            {
                TreeNode *node = q.front();
                q.pop();

                if (node)
                {
                    std::cout << node->val << " ";

                    q.push(node->left);
                    q.push(node->right);
                }
                else
                {
                    std::cout << "null ";
                }
            }
        }
    }

int main()
{
    Solution solution;

    // Tu código original
    TreeNode *root = new TreeNode(5, new TreeNode(1), new TreeNode(4, new TreeNode(3), new TreeNode(6)));
    bool isValid = solution.isValidBST(root);

    // Imprimir el árbol
    std::cout << "Árbol: ";
    printTree(root);

    // Imprimir si el árbol es válido
    std::cout << "\nEl árbol es válido: " << (isValid ? "true" : "false") << std::endl;

    return 0;
}
