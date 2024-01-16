#include <iostream>
#include <climits>

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
    int ans = INT_MIN;

    int dfs(TreeNode *root)
    {
        if (!root)
            return 0;

        int left = dfs(root->left);
        int right = dfs(root->right);

        ans = std::max(ans, root->val + left + right);

        return std::max(0, root->val + std::max(left, right));
    }

public:
    int maxPathSum(TreeNode *root)
    {
        dfs(root);
        return ans;
    }
};

int main()
{
    // Ejemplo de uso
    TreeNode *root = new TreeNode(-10,
                                   new TreeNode(9),
                                   new TreeNode(20,
                                                new TreeNode(15),
                                                new TreeNode(7)));

    // Crear una instancia de la solución
    Solution solution;

    // Calcular la suma máxima de rutas en el árbol
    int result = solution.maxPathSum(root);

    // Mostrar el resultado
    std::cout << "La suma máxima de rutas en el árbol es: " << result << std::endl;

    // Liberar la memoria
    // Agrega aquí tu propia lógica para liberar la memoria del árbol construido

    return 0;
}
