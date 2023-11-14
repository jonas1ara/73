/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
**/

public class Solution
{
    private bool IsSameTree(TreeNode s, TreeNode t)
    {
        return (s == null && t == null) || (s != null && t != null && s.val == t.val && IsSameTree(s.left, t.left) && IsSameTree(s.right, t.right));
    }

    public bool IsSubtree(TreeNode s, TreeNode t)
    {
        return IsSameTree(s, t) || (s != null && (IsSubtree(s.left, t) || IsSubtree(s.right, t)));
    }
}

