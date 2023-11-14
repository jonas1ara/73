class Solution {
public:
    int kthSmallest(TreeNode* root, int k) {
        function<int(TreeNode*)> inorder = [&](TreeNode *root) {
            if (!root) return -1;
            int val = inorder(root->left);
            if (val != -1) return val;
            if (--k == 0) return root->val;
            return inorder(root->right);
        };
        return inorder(root);
    }
};