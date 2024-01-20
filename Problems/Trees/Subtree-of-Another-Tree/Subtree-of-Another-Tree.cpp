#include <iostream>
#include <queue>

// Using recursion - Time: O(m * n)

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
    bool isSameTree(TreeNode *root, TreeNode *subRoot)
    {
        return (!root && !subRoot) || (root && subRoot && root->val == subRoot->val && isSameTree(root->left, subRoot->left) && isSameTree(root->right, subRoot->right));
    }

public:
    bool isSubtree(TreeNode *root, TreeNode *subRoot)
    {
        return isSameTree(root, subRoot) || (root && (isSubtree(root->left, subRoot) || isSubtree(root->right, subRoot)));
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
    TreeNode *root = new TreeNode(3,
                                  new TreeNode(4,
                                               new TreeNode(1),
                                               new TreeNode(2)),
                                  new TreeNode(5));

    TreeNode *subRoot = new TreeNode(4,
                                     new TreeNode(1),
                                     new TreeNode(2));

    std::cout << "root = ";
    printTree(root);
    std::cout << ", subRoot = ";
    printTree(subRoot);
    std::cout << std::endl;

    Solution sol;
    bool result = sol.isSubtree(root, subRoot);

    std::cout << "Output: " << (result ? "true" : "false") << std::endl;

    delete root;
    delete subRoot;

    return 0;
}
