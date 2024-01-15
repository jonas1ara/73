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

    // Función para imprimir el árbol
    public void PrintTree(TreeNode root)
    {
        if (root == null)
            return;

        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            int n = q.Count;

            for (int i = 0; i < n; i++)
            {
                TreeNode node = q.Dequeue();

                if (node != null)
                {
                    Console.Write(node.val + " ");

                    q.Enqueue(node.left);
                    q.Enqueue(node.right);
                }
                else
                {
                    Console.Write("null ");
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();

        // Tu código original
        TreeNode root = new TreeNode(5, new TreeNode(1), new TreeNode(4, new TreeNode(3), new TreeNode(6)));
        bool isValid = solution.IsValidBST(root);

        // Imprimir el árbol
        Console.Write("Árbol: ");
        solution.PrintTree(root);

        // Imprimir si el árbol es válido
        Console.WriteLine("\nEl árbol es válido: " + (isValid ? "true" : "false"));
    }
}