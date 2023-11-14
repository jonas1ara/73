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
    public int MaxDepth(TreeNode root)
    {
        return root != null ? 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right)) : 0;
    }
}