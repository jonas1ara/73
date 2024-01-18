using System;
using System.Text;
using System.Collections.Generic;

// Using preorder traversal - Time: O(n)

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    // public TreeNode(int x) { val = x; }
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Codec
{
    public string serialize(TreeNode root)
    {
        if (root == null)
        {
            return "null";
        }

        StringBuilder sb = new StringBuilder();
        serializeHelper(root, sb);

        return sb.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        Queue<string> nodes = new Queue<string>(data.Split(','));

        return deserializeHelper(nodes);
    }

    private void serializeHelper(TreeNode node, StringBuilder sb)
    {
        if (node == null)
        {
            sb.Append("null,");
        }
        else
        {
            sb.Append(node.val).Append(",");
            serializeHelper(node.left, sb);
            serializeHelper(node.right, sb);
        }
    }

    private TreeNode deserializeHelper(Queue<string> nodes)
    {
        string val = nodes.Dequeue();

        if (val == "null")
        {
            return null;
        }

        TreeNode node = new TreeNode(int.Parse(val));
        node.left = deserializeHelper(nodes);
        node.right = deserializeHelper(nodes);

        return node;
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
        // TreeNode root = new TreeNode(1)
        // {
        //     left = new TreeNode(2),
        //     right = new TreeNode(3)
        //     {
        //         left = new TreeNode(4),
        //         right = new TreeNode(5)
        //     }
        // };

        TreeNode root = new TreeNode(1, new TreeNode(2), new TreeNode(3, new TreeNode(4), new TreeNode(5)));

        Console.Write("Input: root = ");
        PrintTree(root);
        Console.WriteLine();

        Codec codec = new Codec();
        string serialized = codec.serialize(root);

        Console.Write("Output: ");
        PrintTree(codec.deserialize(serialized));
        Console.WriteLine();
    }
}
