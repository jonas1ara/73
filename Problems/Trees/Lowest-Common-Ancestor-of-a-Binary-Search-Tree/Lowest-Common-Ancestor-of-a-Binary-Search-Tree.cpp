#include <iostream>

struct TreeNode
{
    int val;
    TreeNode *left;
    TreeNode *right;
    TreeNode(int x) : val(x), left(NULL), right(NULL) {}
};

class Solution
{
public:
    TreeNode *lowestCommonAncestor(TreeNode *root, TreeNode *p, TreeNode *q)
    {
        if (root->val > p->val && root->val > q->val)
            return lowestCommonAncestor(root->left, p, q);
        if (root->val < p->val && root->val < q->val)
            return lowestCommonAncestor(root->right, p, q);
        return root;
    }
};

int main()
{
    // Crear un árbol de ejemplo
    TreeNode *root = new TreeNode(6);
    root->left = new TreeNode(2);
    root->left->left = new TreeNode(0);
    root->left->right = new TreeNode(4);
    root->left->right->left = new TreeNode(3);
    root->left->right->right = new TreeNode(5);

    root->right = new TreeNode(8);
    root->right->left = new TreeNode(7);
    root->right->right = new TreeNode(9);

    Solution solution;

    // Encontrar el ancestro común más bajo de 3 y 5
    TreeNode *p = new TreeNode(3);
    TreeNode *q = new TreeNode(5);
    TreeNode *result = solution.lowestCommonAncestor(root, p, q);

    // Mostrar el resultado
    std::cout << "El ancestro común más bajo de " << p->val << " y " << q->val << " es: " << result->val << std::endl;

    // Liberar la memoria
    delete root;
    delete p;
    delete q;

    return 0;
}
