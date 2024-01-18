using System;

// Using preorder and inorder traversal - Time: O(n)

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
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        if (preorder.Length == 0 || inorder.Length == 0) 
        {
            return null;
        }
        return BuildTree(preorder, 0, preorder.Length, inorder, 0, inorder.Length);
    }

    private TreeNode BuildTree(int[] preorder, int preorderStart, int preorderEnd, int[] inorder, int inorderStart, int inorderEnd)
    {
        var root = new TreeNode(preorder[preorderStart]);

        var inorderIndex = inorderStart;
        for (; inorderIndex < inorderEnd; inorderIndex++)
        {
            if (inorder[inorderIndex] == preorder[preorderStart])
            {
                break;
            }
        }


        var leftLength = inorderIndex - inorderStart;

        if (leftLength > 0)
        {
            root.left = BuildTree(preorder, preorderStart + 1, preorderStart + 1 + leftLength, inorder, inorderStart, inorderIndex);
        }
        if (inorderEnd > inorderIndex + 1)
        {
            root.right = BuildTree(preorder, preorderStart + 1 + leftLength, preorderEnd, inorder, inorderIndex + 1, inorderEnd);
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
        int[] preorder = { 3, 9, 20, 15, 7 };
        int[] inorder = { 9, 3, 15, 20, 7 };

        Console.WriteLine("Input: preorder = [" + string.Join(", ", preorder) + "], inorder = [" + string.Join(", ", inorder) + "]");

        Solution sol = new Solution();
        TreeNode root = sol.BuildTree(preorder, inorder);

        Console.Write("Ouput: ");
        PrintTree(root);
        Console.WriteLine();
    }
}
