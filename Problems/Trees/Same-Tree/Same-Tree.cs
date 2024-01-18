using System;
using System.Collections.Generic;

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
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        return (p == null && q == null) ||
               (p != null && q != null &&
                p.val == q.val &&
                IsSameTree(p.left, q.left) &&
                IsSameTree(p.right, q.right));
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
        // Input: p = [1,2,3], q = [1,2,3]
        TreeNode tree1 = new TreeNode(1, new TreeNode(2), new TreeNode(3));
        TreeNode tree2 = new TreeNode(1, new TreeNode(2), new TreeNode(3));

        // Input: p = [1,2], q = [1,null,2]
        // TreeNode tree1 = new TreeNode(1, new TreeNode(2));
        // TreeNode tree2 = new TreeNode(1, null, new TreeNode(2));

        Console.Write("Input: p = ");
        PrintTree(tree1);
        Console.Write(", q = ");
        PrintTree(tree2);
        Console.WriteLine();

        Solution sol = new Solution();
        bool ans = sol.IsSameTree(tree1, tree2);

        Console.WriteLine("Output: " + (ans ? "true" : "false"));
    }
}
