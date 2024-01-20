#include <iostream>
#include <queue>

// Using in-order traversal - Time O(n)

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
    TreeNode *prev = NULL;

public:
    bool isValidBST(TreeNode *root)
    {
        if (!root)
            return true;

        if (!isValidBST(root->left) || (prev && prev->val >= root->val))
            return false;

        prev = root;

        return isValidBST(root->right);
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
    TreeNode *root = new TreeNode(5, new TreeNode(1), new TreeNode(4, new TreeNode(3), new TreeNode(6)));

    Solution sol;
    bool ans = sol.isValidBST(root);

    std::cout << "Input: root = ";
    printTree(root);
    std::cout << std::endl;

    std::cout << "Output: " << (ans ? "true" : "false") << std::endl;

    return 0;
}
