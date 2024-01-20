#include <iostream>
#include <vector>
#include <queue>
#include <string>

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
    bool isSameTree(TreeNode *p, TreeNode *q)
    {
        return (p == nullptr && q == nullptr) ||
               (p != nullptr && q != nullptr &&
                p->val == q->val &&
                isSameTree(p->left, q->left) &&
                isSameTree(p->right, q->right));
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
    // Input: p = [1,2,3], q = [1,2,3]
    TreeNode *tree1 = new TreeNode(1, new TreeNode(2), new TreeNode(3));
    TreeNode *tree2 = new TreeNode(1, new TreeNode(2), new TreeNode(3));

    // Input: p = [1,2], q = [1,null,2]
    // TreeNode* tree1 = new TreeNode(1, new TreeNode(2));
    // TreeNode* tree2 = new TreeNode(1, nullptr, new TreeNode(2));

    std::cout << "Input: p = ";
    printTree(tree1);
    std::cout << ", q = ";
    printTree(tree2);
    std::cout << std::endl;

    Solution sol;
    bool ans = sol.isSameTree(tree1, tree2);

    std::cout << "Output: " << (ans ? "true" : "false") << std::endl;

    delete tree1;
    delete tree2;

    return 0;
}
