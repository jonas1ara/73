class Solution {
private:
    bool isSameTree(TreeNode* s, TreeNode* t) {
        return (!s && !t) || (s && t && s->val == t->val && isSameTree(s->left, t->left) && isSameTree(s->right, t->right));
    }
public:
    bool isSubtree(TreeNode* s, TreeNode* t) {
        return isSameTree(s, t) || (s && (isSubtree(s->left, t) || isSubtree(s->right, t)));
    }
};