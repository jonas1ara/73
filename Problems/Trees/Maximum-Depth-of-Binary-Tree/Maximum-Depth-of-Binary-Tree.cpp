#include <iostream>
#include <algorithm>
#include <vector>
#include <queue>

// Using depth-first search - Time: O(n)

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
    int maxDepth(TreeNode *root)
    {
        return root ? 1 + std::max(maxDepth(root->left), maxDepth(root->right)) : 0;
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
    int ans = sol.maxDepth(root);

    std::cout << "Output: " << ans << std::endl;

    delete root;

    return 0;
}
