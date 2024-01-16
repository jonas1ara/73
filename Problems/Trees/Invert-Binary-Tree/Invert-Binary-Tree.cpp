#include <iostream>
#include <vector>

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
    TreeNode *invertTree(TreeNode *root)
    {
        if (!root)
            return NULL;
        std::swap(root->left, root->right);
        invertTree(root->left);
        invertTree(root->right);
        return root;
    }
};

void printTree(TreeNode *root)
{
    if (!root)
        return;

    printTree(root->left);
    std::cout << root->val << " ";
    printTree(root->right);
}

int main()
{
    // Crear un árbol de ejemplo
    TreeNode *root = new TreeNode(1,
                                   new TreeNode(2, new TreeNode(4), new TreeNode(5)),
                                   new TreeNode(3, new TreeNode(6), new TreeNode(7)));

    // Mostrar el árbol original
    std::cout << "Árbol original: ";
    printTree(root);
    std::cout << std::endl;

    // Invertir el árbol
    Solution solution;
    TreeNode *invertedRoot = solution.invertTree(root);

    // Mostrar el árbol invertido
    std::cout << "Árbol invertido: ";
    printTree(invertedRoot);
    std::cout << std::endl;

    // Liberar la memoria
    // ¡No olvides liberar la memoria después de usar new para evitar fugas de memoria!
    // En una aplicación real, podría considerar el uso de punteros inteligentes para gestionar la memoria automáticamente.
    delete invertedRoot;

    return 0;
}
