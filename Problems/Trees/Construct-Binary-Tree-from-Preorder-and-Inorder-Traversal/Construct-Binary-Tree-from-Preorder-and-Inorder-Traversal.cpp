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
    TreeNode *buildTree(std::vector<int> &preorder, std::vector<int> &inorder)
    {
        if (preorder.empty() || inorder.empty())
        {
            return nullptr;
        }
        return buildTree(preorder, 0, preorder.size(), inorder, 0, inorder.size());
    }

private:
    TreeNode *buildTree(std::vector<int> &preorder, int preorderStart, int preorderEnd,
                        std::vector<int> &inorder, int inorderStart, int inorderEnd)
    {
        TreeNode *root = new TreeNode(preorder[preorderStart]);

        int inorderIndex = inorderStart;
        for (; inorderIndex < inorderEnd; inorderIndex++)
        {
            if (inorder[inorderIndex] == preorder[preorderStart])
            {
                break;
            }
        }

        int leftLength = inorderIndex - inorderStart;
        if (leftLength > 0)
        {
            root->left = buildTree(preorder, preorderStart + 1, preorderStart + 1 + leftLength,
                                   inorder, inorderStart, inorderIndex);
        }
        if (inorderEnd > inorderIndex + 1)
        {
            root->right = buildTree(preorder, preorderStart + 1 + leftLength, preorderEnd,
                                    inorder, inorderIndex + 1, inorderEnd);
        }

        return root;
    }
};

int main()
{
    // Ejemplo de uso
    std::vector<int> preorder = {3, 9, 20, 15, 7};
    std::vector<int> inorder = {9, 3, 15, 20, 7};

    // Crear una instancia de la solución
    Solution solution;

    // Construir el árbol
    TreeNode *root = solution.buildTree(preorder, inorder);

    // Mostrar el resultado (puedes agregar tu propia lógica de visualización)
    std::cout << "Árbol construido exitosamente." << std::endl;

    // Liberar la memoria
    // Agrega aquí tu propia lógica para liberar la memoria del árbol construido

    return 0;
}
