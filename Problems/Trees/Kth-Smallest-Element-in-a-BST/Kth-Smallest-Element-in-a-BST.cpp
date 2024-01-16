#include <iostream>
#include <functional>

struct TreeNode
{
    int val;
    TreeNode *left;
    TreeNode *right;
    TreeNode() : val(0), left(nullptr), right(nullptr) {}
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
    TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
};

class Solution
{
public:
    int kthSmallest(TreeNode *root, int k)
    {
        std::function<int(TreeNode *)> inorder = [&](TreeNode *root)
        {
            if (!root)
                return -1;
            int val = inorder(root->left);
            if (val != -1)
                return val;
            if (--k == 0)
                return root->val;
            return inorder(root->right);
        };
        return inorder(root);
    }
};

int main()
{
    // Crear un árbol de ejemplo
    TreeNode *root = new TreeNode(3,
                                   new TreeNode(1, nullptr, new TreeNode(2)),
                                   new TreeNode(4));

    Solution solution;

    // Encontrar el k-ésimo elemento más pequeño
    int k = 1; // Puedes cambiar este valor según tus necesidades
    int result = solution.kthSmallest(root, k);

    // Mostrar el resultado
    std::cout << "El " << k << "-ésimo elemento más pequeño es: " << result << std::endl;

    // Liberar la memoria
    delete root;

    return 0;
}
