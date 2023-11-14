class Solution {
    int ans = INT_MIN;
    int dfs(TreeNode *root) {
        if (!root) return 0;
        int left = dfs(root->left), right = dfs(root->right);
        ans = max(ans, root->val + left + right);
        return max(0, root->val + max(left, right));
    }
public:
    int maxPathSum(TreeNode* root) {
        dfs(root);
        return ans;
    }
};