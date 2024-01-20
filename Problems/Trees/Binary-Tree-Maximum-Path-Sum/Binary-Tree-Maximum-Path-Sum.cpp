#include <iostream>
#include <climits>
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
private:
    int ans = INT_MIN;

    int dfs(TreeNode *root)
    {
        if (!root)
        {
            return 0;
        }

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
    TreeNode *root = new TreeNode(-10, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));

    std::cout << "Input: ";
    printTree(root);
    std::cout << std::endl;

    Solution solution;
    int result = solution.maxPathSum(root);

    std::cout << "Output: " << result << std::endl;

    delete root;

    return 0;
}
