/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
**/
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

// Tu objeto Codec se instanciará y se llamará de la siguiente manera:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));
