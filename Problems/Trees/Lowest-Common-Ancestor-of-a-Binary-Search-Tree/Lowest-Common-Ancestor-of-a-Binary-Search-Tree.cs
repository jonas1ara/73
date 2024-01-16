using System;

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
    static void Main()
    {
        // Crear un árbol de ejemplo
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

        Solution solution = new Solution();

        // Encontrar el ancestro común más bajo de 3 y 5
        TreeNode p = new TreeNode(3);
        TreeNode q = new TreeNode(5);
        TreeNode result = solution.LowestCommonAncestor(root, p, q);

        // Mostrar el resultado
        Console.WriteLine($"El ancestro común más bajo de {p.val} y {q.val} es: {result.val}");
    }
}