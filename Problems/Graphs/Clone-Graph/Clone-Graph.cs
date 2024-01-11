using System;
using System.Collections.Generic;

// Using depth-first search - Time: O(n)

public class Node
{
    public int val;
    public IList<Node> neighbors;

    public Node()
    {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val)
    {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors)
    {
        val = _val;
        neighbors = _neighbors;
    }
}

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

class Program
{
    static void Main()
    {
        // Constructing the original graph
        var s = new Solution();
        var n1 = new Node(1);
        var n2 = new Node(2);
        var n3 = new Node(3);
        var n4 = new Node(4);

        n1.neighbors.Add(n2);
        n1.neighbors.Add(n4);
        n2.neighbors.Add(n1);
        n2.neighbors.Add(n3);
        n3.neighbors.Add(n2);
        n3.neighbors.Add(n4);
        n4.neighbors.Add(n1);
        n4.neighbors.Add(n3);

        Console.Write("Input: adjList = [");
        foreach (var node in new Node[] { n1, n2, n3, n4 })
        {
            Console.Write("[");
            foreach (var neighbor in node.neighbors)
            {
                Console.Write(neighbor.val + "");
                if (neighbor != node.neighbors[node.neighbors.Count - 1])
                    Console.Write(", ");
            }
            Console.Write("]");
            if (node != n4)
                Console.Write(", ");
        }
        Console.WriteLine("]");

        Solution sol = new Solution();
        var clone = sol.CloneGraph(n1);

        Console.Write("Output: [");
        foreach (var cloneNode in new Node[] {clone, clone.neighbors[0], clone.neighbors[1].neighbors[1], clone.neighbors[1]})
        {
            Console.Write("[");
            foreach (var neighbor in cloneNode.neighbors)
            {
                Console.Write(neighbor.val + "");
                if (neighbor != cloneNode.neighbors[cloneNode.neighbors.Count - 1])
                    Console.Write(", ");
            }
            Console.Write("]");
            if (cloneNode != clone.neighbors[1])
                Console.Write(", ");
        }
        Console.WriteLine("]");
    }
}
