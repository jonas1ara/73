#include <iostream>
#include <vector>
#include <queue>

// Using breadth-first search - Time: O(n)

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
public:
    std::vector<std::vector<int>> levelOrder(TreeNode *root)
    {
        if (!root)
            return {};

        std::vector<std::vector<int>> ans;
        std::queue<TreeNode *> queue;
        queue.push(root);

        while (!queue.empty())
        {
            int levelSize = queue.size();
            ans.emplace_back();

            for (int i = 0; i < levelSize; i++)
            {
                auto node = queue.front();
                queue.pop();
                ans.back().push_back(node->val);

                if (node->left)
                    queue.push(node->left);

                if (node->right)
                    queue.push(node->right);
            }
        }

        return ans;
    }
};

void printTree(TreeNode *root)
{
    if (!root)
    {
        std::cout << "[]" << std::endl;
        return;
    }

    std::queue<TreeNode *> queue;
    queue.push(root);

    std::cout << "[";

    while (!queue.empty())
    {
        int n = queue.size();

        for (int i = 0; i < n; i++)
        {
            TreeNode *node = queue.front();
            queue.pop();

            if (node)
            {
                std::cout << node->val << ", ";

                queue.push(node->left);
                queue.push(node->right);
            }
            else
            {
                if (!queue.empty())
                    std::cout << "null, ";
                else
                    std::cout << "null";
            }
        }
    }

    std::cout << "]";
}

int main()
{
    TreeNode *root = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));

    std::cout << "Input: root = ";
    printTree(root);
    std::cout << std::endl;

    Solution sol;
    std::vector<std::vector<int>> ans = sol.levelOrder(root);

    std::cout << "Output: [";
    for (const auto &level : ans)
    {
        std::cout << "[";
        for (const auto &value : level)
        {
            std::cout << value << "";
            if (&value != &level.back())
                std::cout << ", ";
        }
        if (&level == &ans.back())
            std::cout << "]";
        else
            std::cout << "], ";
    }
    std::cout << "]" << std::endl;

    delete root;

    return 0;
}
