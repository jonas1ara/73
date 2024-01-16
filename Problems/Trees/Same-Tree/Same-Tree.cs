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
    static void Main()
    {
        // Crear dos árboles para probar
        TreeNode tree1 = new TreeNode(1, new TreeNode(2), new TreeNode(3));
        TreeNode tree2 = new TreeNode(1, new TreeNode(2), new TreeNode(3));

        // Crear una instancia de la solución
        Solution solution = new Solution();

        // Probar la función IsSameTree
        bool result = solution.IsSameTree(tree1, tree2);

        // Mostrar el resultado
        Console.WriteLine("Los dos árboles son iguales: " + result);
    }
}
