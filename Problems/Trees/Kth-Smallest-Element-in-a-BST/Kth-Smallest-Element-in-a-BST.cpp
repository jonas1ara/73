#include <iostream>
#include <functional>
#include <queue>

// Using inorder traversal - Time: O(n)

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
    int kthSmallest(TreeNode *root, int k)
    {
        std::function<int(TreeNode *)> inorder = [&](TreeNode *root)
        {
            if (!root)
            {
                return -1;
            }
            
            int val = inorder(root->left);
            
            if (val != -1)
            {
                return val;
            }
            if (--k == 0)
            {
                return root->val;
            }

            return inorder(root->right);
        };

        return inorder(root);
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

    std::cout << "]";
}

int main()
{
    TreeNode *root = new TreeNode(3, new TreeNode(1, nullptr, new TreeNode(2)), new TreeNode(4));
    int k = 1; 

    std::cout << "Input: root = ";
    printTree(root);
    std::cout << ", k = " << k << std::endl;

    Solution sol;
    int ans = sol.kthSmallest(root, k);

    std::cout << "Output: " << ans << std::endl;

    delete root;

    return 0;
}
