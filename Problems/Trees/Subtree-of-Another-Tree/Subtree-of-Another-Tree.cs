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
    private bool IsSameTree(TreeNode s, TreeNode t)
    {
        return (s == null && t == null) || (s != null && t != null && s.val == t.val && IsSameTree(s.left, t.left) && IsSameTree(s.right, t.right));
    }

    public bool IsSubtree(TreeNode s, TreeNode t)
    {
        return IsSameTree(s, t) || (s != null && (IsSubtree(s.left, t) || IsSubtree(s.right, t)));
    }
}

class Program
{
    static void Main()
    {
        // Crear dos árboles de ejemplo
        TreeNode treeS = new TreeNode(3,
            new TreeNode(4,
                new TreeNode(1),
                new TreeNode(2)),
            new TreeNode(5));

        TreeNode treeT = new TreeNode(4,
            new TreeNode(1),
            new TreeNode(2));

        // Crear un objeto Solution
        Solution solution = new Solution();

        // Verificar si treeT es subárbol de treeS
        bool result = solution.IsSubtree(treeS, treeT);

        // Mostrar el resultado
        Console.WriteLine($"treeT {(result ? "es" : "no es")} subárbol de treeS");
    }
}
