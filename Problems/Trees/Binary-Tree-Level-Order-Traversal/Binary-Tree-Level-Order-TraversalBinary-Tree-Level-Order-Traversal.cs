using System;
using System.Collections.Generic;

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
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        if (root == null)
            return new List<IList<int>>();

        List<IList<int>> ans = new List<IList<int>>();
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            int levelSize = q.Count;
            List<int> currentLevel = new List<int>();

            for (int i = 0; i < levelSize; i++)
            {
                var node = q.Dequeue();
                currentLevel.Add(node.val);

                if (node.left != null)
                    q.Enqueue(node.left);

                if (node.right != null)
                    q.Enqueue(node.right);
            }

            ans.Add(currentLevel);
        }

        return ans;
    }
}

class Program
{
    static void Main()
    {
        // Crear un árbol para probar
        TreeNode root = new TreeNode(3,
            new TreeNode(9),
            new TreeNode(20, new TreeNode(15), new TreeNode(7))
        );

        // Crear una instancia de la solución
        Solution solution = new Solution();

        // Probar la función LevelOrder
        IList<IList<int>> result = solution.LevelOrder(root);

        // Mostrar el resultado
        Console.WriteLine("Recorrido por niveles del árbol:");
        foreach (var level in result)
        {
            foreach (var value in level)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }
    }
}
