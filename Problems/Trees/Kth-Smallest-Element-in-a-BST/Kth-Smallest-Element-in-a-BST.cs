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
    public int KthSmallest(TreeNode root, int k)
    {
        Func<TreeNode, int> inorder = null;
        inorder = (TreeNode node) =>
        {
            if (node == null) return -1;
            int val = inorder(node.left);
            if (val != -1) return val;
            if (--k == 0) return node.val;
            return inorder(node.right);
        };

        return inorder(root);
    }
}