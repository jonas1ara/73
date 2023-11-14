class Solution {
public:
    vector<vector<int>> levelOrder(TreeNode* root) {
        if (!root) return {};
        vector<vector<int>> ans;
        queue<TreeNode*> q{{root}};
        while (q.size()) {
            ans.emplace_back();
            for (int cnt = q.size(); cnt--; ) {
                auto n = q.front();
                q.pop();
                ans.back().push_back(n->val);
                if (n->left) q.push(n->left);
                if (n->right) q.push(n->right);
            }
        }
        return ans;
    }
};