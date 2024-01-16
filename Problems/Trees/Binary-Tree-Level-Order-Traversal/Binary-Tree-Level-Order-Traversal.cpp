#include <iostream>
#include <vector>
#include <queue>

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
    std::vector<std::vector<int>> levelOrder(TreeNode *root)
    {
        if (!root)
            return {};

        std::vector<std::vector<int>> ans;
        std::queue<TreeNode *> q;
        q.push(root);

        while (!q.empty())
        {
            int levelSize = q.size();
            ans.emplace_back();

            for (int i = 0; i < levelSize; ++i)
            {
                auto node = q.front();
                q.pop();
                ans.back().push_back(node->val);

                if (node->left)
                    q.push(node->left);

                if (node->right)
                    q.push(node->right);
            }
        }

        return ans;
    }
};

int main()
{
    // Crear un nodo para probar
    TreeNode *root = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));

    // Crear una instancia de la solución
    Solution solution;

    // Probar la función levelOrder
    std::vector<std::vector<int>> result = solution.levelOrder(root);

    // Mostrar el resultado
    std::cout << "Recorrido por niveles del árbol:" << std::endl;
    for (const auto &level : result)
    {
        for (const auto &value : level)
        {
            std::cout << value << " ";
        }
        std::cout << std::endl;
    }

    // Liberar la memoria
    delete root;

    return 0;
}
