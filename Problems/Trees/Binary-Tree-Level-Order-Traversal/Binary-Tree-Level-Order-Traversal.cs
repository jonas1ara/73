using System;
using System.Collections.Generic;

// Using breadth-first search - Time: O(n)

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
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            List<int> currentLevel = new List<int>();

            for (int i = 0; i < levelSize; i++)
            {
                var node = queue.Dequeue();
                currentLevel.Add(node.val);

                if (node.left != null)
                    queue.Enqueue(node.left);

                if (node.right != null)
                    queue.Enqueue(node.right);
            }

            ans.Add(currentLevel);
        }

        return ans;
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
        TreeNode root = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));

        Console.Write("Input: root = ");
        PrintTree(root);
        Console.WriteLine();    

        Solution sol = new Solution();
        IList<IList<int>> ans = sol.LevelOrder(root);

        Console.Write("Output: [");
        foreach (var level in ans)
        {
            Console.Write("[" + string.Join(", ", level) + "]");
            if (level != ans[ans.Count - 1])
                Console.Write(", ");
        }
        Console.WriteLine("]");
    }
}
