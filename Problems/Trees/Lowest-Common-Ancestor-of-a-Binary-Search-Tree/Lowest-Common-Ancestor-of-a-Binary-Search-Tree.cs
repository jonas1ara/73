using System;

// Using recursion - Time: O(h)

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root.val > p.val && root.val > q.val)
        {
            return LowestCommonAncestor(root.left, p, q);
        }
        if (root.val < p.val && root.val < q.val)
        {
            return LowestCommonAncestor(root.right, p, q);
        }
        return root;
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
        TreeNode root = new TreeNode(6)
        {
            left = new TreeNode(2)
            {
                left = new TreeNode(0),
                right = new TreeNode(4)
                {
                    left = new TreeNode(3),
                    right = new TreeNode(5)
                }
            },
            right = new TreeNode(8)
            {
                left = new TreeNode(7),
                right = new TreeNode(9)
            }
        };

        TreeNode p = new TreeNode(2);
        TreeNode q = new TreeNode(8);

        Console.Write("Input: root = ");
        PrintTree(root);
        Console.WriteLine(", p = " + p.val + ", q = " + q.val);

        Solution sol = new Solution();
        TreeNode result = sol.LowestCommonAncestor(root, p, q);

        Console.WriteLine("Output: " + result.val);
    }
}