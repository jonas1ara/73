public class CloneGraphTests
{
    private static List<string> GraphSignature(Node start)
    {
        var visited = new HashSet<Node>();
        var result = new List<string>();
        var queue = new Queue<Node>();

        queue.Enqueue(start);
        visited.Add(start);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            var neighborVals = string.Join(",", node.neighbors.Select(x => x.val).OrderBy(x => x));
            result.Add($"{node.val}:{neighborVals}");

            foreach (var neighbor in node.neighbors)
            {
                if (visited.Add(neighbor))
                {
                    queue.Enqueue(neighbor);
                }
            }
        }

        return result.OrderBy(x => x).ToList();
    }

    [Fact]
    public void CloneGraph_FourNodeCycle_ReturnsDeepCopyWithMatchingStructure()
    {
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
        var sol = new Solution();

        var clone = sol.CloneGraph(n1);

        Assert.NotSame(n1, clone);
        Assert.Equal(GraphSignature(n1), GraphSignature(clone!));
    }

    [Fact]
    public void CloneGraph_SingleNodeWithNoNeighbors_ReturnsClone()
    {
        var n1 = new Node(1);
        var sol = new Solution();

        var clone = sol.CloneGraph(n1);

        Assert.NotSame(n1, clone);
        Assert.Equal(1, clone!.val);
        Assert.Empty(clone.neighbors);
    }

    [Fact]
    public void CloneGraph_NullNode_ReturnsNull()
    {
        var sol = new Solution();

        var clone = sol.CloneGraph(null!);

        Assert.Null(clone);
    }
}
