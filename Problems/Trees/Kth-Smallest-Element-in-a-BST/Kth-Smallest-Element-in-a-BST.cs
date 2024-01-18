using System;

// Using inorder traversal - Time: O(n)

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
    public int KthSmallest(TreeNode root, int k)
    {
        Func<TreeNode, int> inorder = null;
        inorder = (TreeNode node) =>
        {
            if (node == null)
            {
                return -1;
            }

            int val = inorder(node.left);

            if (val != -1) 
            {
                return val;
            }
            if (--k == 0) 
            { 
                return node.val;
            }

            return inorder(node.right);
        };

        return inorder(root);
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
        TreeNode root = new TreeNode(3, new TreeNode(1, null, new TreeNode(2)), new TreeNode(4));
        int k = 1;

        Console.Write("Input: root = ");
        PrintTree(root);
        Console.Write(", k = " + k + "\n");

        Solution sol = new Solution();
        int ans = sol.KthSmallest(root, k);

        Console.WriteLine("Output: " + ans);
    }
}
