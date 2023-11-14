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
 */
public class Solution
{
    private int ans = int.MinValue;

    private int Dfs(TreeNode root)
    {
        if (root == null) return 0;

        int left = Dfs(root.left);
        int right = Dfs(root.right);

        ans = Math.Max(ans, root.val + left + right);
        return Math.Max(0, root.val + Math.Max(left, right));
    }

    public int MaxPathSum(TreeNode root)
    {
        Dfs(root);
        return ans;
    }
}
