using System;

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
            if (node == null) return -1;
            int val = inorder(node.left);
            if (val != -1) return val;
            if (--k == 0) return node.val;
            return inorder(node.right);
        };

        return inorder(root);
    }
}

class Program
{
    static void Main()
    {
        // Crear un árbol de ejemplo
        TreeNode root = new TreeNode(3,
                                    new TreeNode(1, null, new TreeNode(2)),
                                    new TreeNode(4));

        Solution solution = new Solution();

        // Encontrar el k-ésimo elemento más pequeño
        int k = 1; // Puedes cambiar este valor según tus necesidades
        int result = solution.KthSmallest(root, k);

        // Mostrar el resultado
        Console.WriteLine($"El {k}-ésimo elemento más pequeño es: {result}");
    }
}
