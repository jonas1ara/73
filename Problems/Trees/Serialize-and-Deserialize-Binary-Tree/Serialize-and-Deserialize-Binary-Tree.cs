using System;
using System.Collections.Generic;
using System.Text;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
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

    public TreeNode deserialize(string data)
    {
        Queue<string> nodes = new Queue<string>(data.Split(','));

        return deserializeHelper(nodes);
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
    static void Main()
    {
        // Crear un árbol de ejemplo
        TreeNode root = new TreeNode(1)
        {
            left = new TreeNode(2),
            right = new TreeNode(3)
            {
                left = new TreeNode(4),
                right = new TreeNode(5)
            }
        };

        // Crear un objeto Codec
        Codec codec = new Codec();

        // Serializar el árbol
        string serialized = codec.serialize(root);
        Console.WriteLine($"Árbol serializado: {serialized}");

        // Deserializar el árbol
        TreeNode deserialized = codec.deserialize(serialized);

        // Mostrar el resultado
        Console.WriteLine($"Árbol deserializado: {codec.serialize(deserialized)}");
    }
}
