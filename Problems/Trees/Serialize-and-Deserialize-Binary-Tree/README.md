# Serialize and Deserialize Binary Tree:

This directory contains an implementation of the "Serialize and Deserialize Binary Tree" problem in C#. The implementation uses preorder traversal with null markers and temporal complexity `O(n)`.

## Problem description

Serialization is the process of converting a data structure or object into a sequence of bits so that it can be stored or transmitted and reconstructed later.

Design an algorithm to serialize and deserialize a binary tree. There is no restriction on how your serialization/deserialization algorithm should work. You just need to ensure that a binary tree can be serialized to a string and this string can be deserialized to the original tree structure.

- Example 1:

```
Input: root = [1,2,3,null,null,4,5]
Output: [1,2,3,null,null,4,5]
```

- Example 2:

```
Input: root = []
Output: []
```

## Solution:

**Serialize (preorder):** write `val,` for each node; write `null,` for empty children. This uniquely encodes shape and values.

**Deserialize:** split the string by `,` into a queue of tokens. Recursively:

1. Dequeue a token
2. If `null` → return null node
3. Otherwise create a node, then deserialize left and right children in the same preorder order

For `root = [1,2,3,null,null,4,5]`:

1. Serialize ≈ `1,2,null,null,3,4,null,null,5,null,null,`
2. Deserialize rebuilds the same structure by consuming tokens left-to-right

## Implementations:

### C# :

```csharp
// Using preorder traversal - Time: O(n)

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
```

1. Preorder + explicit nulls makes reconstruction unambiguous.

2. A queue of tokens preserves left-to-right consumption order.
