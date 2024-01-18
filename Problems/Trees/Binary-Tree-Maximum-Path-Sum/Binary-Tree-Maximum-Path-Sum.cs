using System;

// Using depth-first search - Time: O(n)

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    private int ans = int.MinValue;

    private int dfs(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        int left = dfs(root.left);
        int right = dfs(root.right);

        ans = Math.Max(ans, root.val + left + right);
        return Math.Max(0, root.val + Math.Max(left, right));
    }

    public int MaxPathSum(TreeNode root)
    {
        dfs(root);
        return ans;
    }
}

class Program
{
    static void PrintTree(TreeNode root)
    {
        if (root == null)
        {
            Console.Write("null");
            return;
        }

        List<string> values = new List<string>();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            TreeNode current = queue.Dequeue();
            if (current != null)
            {
                values.Add(current.val.ToString());
                queue.Enqueue(current.left);
                queue.Enqueue(current.right);
            }
            else
            {
                values.Add("null");
            }
        }

        Console.Write("[" + string.Join(", ", values) + "]");
    }
    static void Main()
    {
        TreeNode root = new TreeNode(-10, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));

        Console.Write("Input: root = ");
        PrintTree(root);
        Console.WriteLine();

        Solution sol = new Solution();
        int ans = sol.MaxPathSum(root);

        Console.WriteLine("Output: " + ans);
    }
}
