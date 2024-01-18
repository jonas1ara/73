using System;

// Using in-order traversal - Time O(n)

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
    private TreeNode prev = null;

    public bool IsValidBST(TreeNode root)
    {
        if (root == null)
            return true;

        if (!IsValidBST(root.left) || (prev != null && prev.val >= root.val))
            return false;

        prev = root;

        return IsValidBST(root.right);
    }
}


class Program
{
    static void PrintTree(TreeNode root)
    {
        if (root == null)
        {
            Console.WriteLine("[]");
            return;
        }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        Console.Write("[");

        while (queue.Count > 0)
        {
            int n = queue.Count;

            for (int i = 0; i < n; i++)
            {
                TreeNode node = queue.Dequeue();

                if (node != null)
                {
                    Console.Write(node.val + ", ");

                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
                else
                {
                    Console.Write("null");

                    if (i < n - 1)
                        Console.Write(", ");
                }
            }
        }

        Console.WriteLine("]");
    }

    static void Main()
    {
        TreeNode root = new TreeNode(5, new TreeNode(1), new TreeNode(4, new TreeNode(3), new TreeNode(6)));

        Solution sol = new Solution();
        bool ans = sol.IsValidBST(root);

        Console.Write("Input: root = ");
        PrintTree(root);

        Console.WriteLine("Output: " + (ans ? "true" : "false"));
    }
}