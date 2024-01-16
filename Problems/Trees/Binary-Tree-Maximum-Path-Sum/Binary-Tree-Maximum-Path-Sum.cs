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
    private int ans = int.MinValue;

    private int Dfs(TreeNode root)
    {
        if (root == null)
            return 0;

        int left = Dfs(root.left);
        int right = Dfs(root.right);

        ans = Math.Max(ans, root.val + left + right);
        return Math.Max(0, root.val + Math.Max(left, right));
    }

    public int MaxPathSum(TreeNode root)
    {
        Dfs(root);
        return ans;
    }
}

class Program
{
    static void Main()
    {
        // Ejemplo de uso
        TreeNode root = new TreeNode(-10,
                                     new TreeNode(9),
                                     new TreeNode(20,
                                                  new TreeNode(15),
                                                  new TreeNode(7)));

        // Crear una instancia de la solución
        Solution solution = new Solution();

        // Calcular la suma máxima de rutas en el árbol
        int result = solution.MaxPathSum(root);

        // Mostrar el resultado
        Console.WriteLine("La suma máxima de rutas en el árbol es: " + result);
    }
}
