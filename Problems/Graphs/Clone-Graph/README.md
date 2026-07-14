# Clone Graph:

This directory contains an implementation of the "Clone Graph" problem in C#. The implementation uses depth-first search with a map from original nodes to clones with temporal complexity `O(n + e)`.

## Problem description

Given a reference of a node in a connected undirected graph, return a deep copy (clone) of the graph.

Each node in the graph contains a value (`int`) and a list (`List[Node]`) of its neighbors.

```
class Node {
    public int val;
    public List<Node> neighbors;
}
```

- Example 1:

```
Input: adjList = [[2,4],[1,3],[2,4],[1,3]]
Output: [[2,4],[1,3],[2,4],[1,3]]
Explanation: There are 4 nodes.
1st node (val = 1)'s neighbors are 2nd node (val = 2) and 4th node (val = 4).
2nd node (val = 2)'s neighbors are 1st node (val = 1) and 3rd node (val = 3).
3rd node (val = 3)'s neighbors are 2nd node (val = 2) and 4th node (val = 4).
4th node (val = 4)'s neighbors are 1st node (val = 1) and 3rd node (val = 3).
```

- Example 2:

```
Input: adjList = [[]]
Output: [[]]
```

- Example 3:

```
Input: adjList = []
Output: []
```

## Solution:

DFS with a hash map `original → clone`:

1. If the node is null, return null
2. If already cloned, return the stored clone (handles cycles)
3. Create a new node with the same value; store the mapping
4. For each neighbor, recursively clone and append to the new node's neighbor list

This produces a deep copy: no shared node objects with the original graph.

## Implementations:

### C# :

```csharp
// Using depth-first search - Time: O(n)

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
```

1. The map both memoizes clones and breaks cycles.

2. Neighbors are filled after the clone node exists so mutual edges link correctly.

## Suggested practice 🎯

Same graph traversal with a visited map pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Copy List with Random Pointer](https://leetcode.com/problems/copy-list-with-random-pointer/)
- [Clone Binary Tree With Random Pointer](https://leetcode.com/problems/clone-binary-tree-with-random-pointer/)
- [Find Eventual Safe States](https://leetcode.com/problems/find-eventual-safe-states/)
