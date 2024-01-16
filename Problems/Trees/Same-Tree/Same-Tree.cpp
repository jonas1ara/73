#include <iostream>

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
    bool isSameTree(TreeNode *p, TreeNode *q)
    {
        return (!p && !q) || (p && q && p->val == q->val && isSameTree(p->left, q->left) && isSameTree(p->right, q->right));
    }
};

int main()
{
    // Crear dos nodos para probar
    TreeNode *tree1 = new TreeNode(1, new TreeNode(2), new TreeNode(3));
    TreeNode *tree2 = new TreeNode(1, new TreeNode(2), new TreeNode(3));

    // Crear una instancia de la solución
    Solution solution;

    // Probar la función isSameTree
    bool result = solution.isSameTree(tree1, tree2);

    // Mostrar el resultado
    std::cout << "Los dos árboles son iguales: " << (result ? "true" : "false") << std::endl;

    // Liberar la memoria
    delete tree1;
    delete tree2;

    return 0;
}
