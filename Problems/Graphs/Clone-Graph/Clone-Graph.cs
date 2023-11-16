/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution
{
    private Dictionary<Node, Node> m = new Dictionary<Node, Node>();

    public Node CloneGraph(Node node)
    {
        if (node == null)
            return null;

        if (m.ContainsKey(node))
            return m[node];

        Node cpy = new Node(node.val);
        m[node] = cpy;

        foreach (var neighbor in node.neighbors)
        {
            cpy.neighbors.Add(CloneGraph(neighbor));
        }

        return cpy;
    }
}

