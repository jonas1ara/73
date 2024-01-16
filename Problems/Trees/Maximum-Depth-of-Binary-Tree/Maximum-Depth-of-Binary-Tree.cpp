#include <iostream>
#include <algorithm>

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
    int maxDepth(TreeNode *root)
    {
        return root ? 1 + std::max(maxDepth(root->left), maxDepth(root->right)) : 0;
    }
};

int main()
{
    // Crear un árbol para probar
    TreeNode *root = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));

    // Crear una instancia de la solución
    Solution solution;

    // Probar la función maxDepth
    int result = solution.maxDepth(root);

    // Mostrar el resultado
    std::cout << "La profundidad máxima del árbol es: " << result << std::endl;

    // Liberar la memoria
    delete root;

    return 0;
}
