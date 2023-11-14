public class Solution
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        if (root == null) return new List<IList<int>>();
        List<IList<int>> ans = new List<IList<int>>();
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        while (q.Count > 0)
        {
            ans.Add(new List<int>());
            for (int cnt = q.Count; cnt > 0; cnt--)
            {
                var n = q.Dequeue();
                ans[ans.Count - 1].Add(n.val);
                if (n.left != null) q.Enqueue(n.left);
                if (n.right != null) q.Enqueue(n.right);
            }
        }
        return ans;
    }
}