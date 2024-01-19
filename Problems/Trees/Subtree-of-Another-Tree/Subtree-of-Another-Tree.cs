using System;

// Using recursion - Time: O(m * n)

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
    private bool IsSameTree(TreeNode root, TreeNode subRoot)
    {
        return (root == null && subRoot == null) || (root != null && subRoot != null && root.val == subRoot.val && IsSameTree(root.left, subRoot.left) && IsSameTree(root.right, subRoot.right));
    }

    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        return IsSameTree(root, subRoot) || (root != null && (IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot)));
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
        TreeNode root = new TreeNode(3,
            new TreeNode(4,
                new TreeNode(1),
                new TreeNode(2)),
            new TreeNode(5));

        TreeNode subRoot = new TreeNode(4,
            new TreeNode(1),
            new TreeNode(2));

        Console.Write("root = ");
        PrintTree(root);
        Console.Write(", subRoot = ");
        PrintTree(subRoot);
        Console.WriteLine();

        Solution sol = new Solution();
        bool result = sol.IsSubtree(root, subRoot);

        Console.WriteLine("Output: " + (result ? "true" : "false"));
    }
}
