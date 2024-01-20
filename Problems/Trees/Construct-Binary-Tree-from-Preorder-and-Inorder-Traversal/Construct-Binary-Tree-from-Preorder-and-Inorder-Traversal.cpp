#include <iostream>
#include <vector>
#include <queue>

// Using preorder and inorder traversal - Time: O(n)

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
    TreeNode *buildTree(std::vector<int> &preorder, std::vector<int> &inorder)
    {
        if (preorder.empty() || inorder.empty())
        {
            return nullptr;
        }
        return buildTree(preorder, 0, preorder.size(), inorder, 0, inorder.size());
    }

private:
    TreeNode *buildTree(std::vector<int> &preorder, int preorderStart, int preorderEnd, std::vector<int> &inorder, int inorderStart, int inorderEnd)
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
            root->left = buildTree(preorder, preorderStart + 1, preorderStart + 1 + leftLength, inorder, inorderStart, inorderIndex);
        }
        if (inorderEnd > inorderIndex + 1)
        {
            root->right = buildTree(preorder, preorderStart + 1 + leftLength, preorderEnd, inorder, inorderIndex + 1, inorderEnd);
        }

        return root;
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
    std::vector<int> preorder = {3, 9, 20, 15, 7};
    std::vector<int> inorder = {9, 3, 15, 20, 7};

    std::cout << "Input: preorder = [";
    for (int i = 0; i < preorder.size(); i++)
    {
        std::cout << preorder[i];
        if (i < preorder.size() - 1)
        {
            std::cout << ", ";
        }
    }
    std::cout << "], inorder = [";
    for (int i = 0; i < inorder.size(); i++)
    {
        std::cout << inorder[i];
        if (i < inorder.size() - 1)
        {
            std::cout << ", ";
        }
    }
    std::cout << "]" << std::endl;

    Solution solution;
    TreeNode *root = solution.buildTree(preorder, inorder);

    std::cout << "Output: ";
    printTree(root);
    std::cout << std::endl;

    delete root;

    return 0;
}
