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
private:
    bool isSameTree(TreeNode *s, TreeNode *t)
    {
        return (!s && !t) || (s && t && s->val == t->val && isSameTree(s->left, t->left) && isSameTree(s->right, t->right));
    }

public:
    bool isSubtree(TreeNode *s, TreeNode *t)
    {
        return isSameTree(s, t) || (s && (isSubtree(s->left, t) || isSubtree(s->right, t)));
    }
};

int main()
{
    // Crear dos árboles de ejemplo
    TreeNode *treeS = new TreeNode(3,
                                   new TreeNode(4,
                                                new TreeNode(1),
                                                new TreeNode(2)),
                                   new TreeNode(5));

    TreeNode *treeT = new TreeNode(4,
                                   new TreeNode(1),
                                   new TreeNode(2));

    // Crear un objeto Solution
    Solution solution;

    // Verificar si treeT es un subárbol de treeS
    bool result = solution.isSubtree(treeS, treeT);

    // Mostrar el resultado
    std::cout << (result ? "treeT es subárbol de treeS" : "treeT no es subárbol de treeS") << std::endl;

    // Liberar memoria
    delete treeS;
    delete treeT;

    return 0;
}
