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
    public int MaxDepth(TreeNode root)
    {
        return root != null ? 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right)) : 0;
    }
}

class Program
{
    static void Main()
    {
        // Crear un árbol para probar
        TreeNode root = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));

        // Crear una instancia de la solución
        Solution solution = new Solution();

        // Probar la función MaxDepth
        int result = solution.MaxDepth(root);

        // Mostrar el resultado
        Console.WriteLine("La profundidad máxima del árbol es: " + result);
    }
}
