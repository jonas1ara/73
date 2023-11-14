#include <vector>

using namespace std;

// Definición de la clase TreeNode
class TreeNode {
public:
    int val;
    TreeNode* left;
    TreeNode* right;
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
};

class Solution {
public:
    TreeNode* buildTree(vector<int>& preorder, vector<int>& inorder) {
        if (preorder.empty() || inorder.empty()) {
            return nullptr;
        }
        return buildTree(preorder, 0, preorder.size(), inorder, 0, inorder.size());
    }

private:
    TreeNode* buildTree(vector<int>& preorder, int preorderStart, int preorderEnd, 
                        vector<int>& inorder, int inorderStart, int inorderEnd) {
        TreeNode* root = new TreeNode(preorder[preorderStart]);

        int inorderIndex = inorderStart;
        for (; inorderIndex < inorderEnd; inorderIndex++) {
            if (inorder[inorderIndex] == preorder[preorderStart]) {
                break;
            }
        }

        int leftLength = inorderIndex - inorderStart;
        if (leftLength > 0) {
            root->left = buildTree(preorder, preorderStart + 1, preorderStart + 1 + leftLength, 
                                   inorder, inorderStart, inorderIndex);
        }
        if (inorderEnd > inorderIndex + 1) {
            root->right = buildTree(preorder, preorderStart + 1 + leftLength, preorderEnd, 
                                    inorder, inorderIndex + 1, inorderEnd);
        }

        return root;
    }
};
