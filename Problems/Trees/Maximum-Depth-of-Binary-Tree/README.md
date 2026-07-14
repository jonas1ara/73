# Maximum Depth of Binary Tree:

This directory contains an implementation of the "Maximum Depth of Binary Tree" problem in C#. The implementation uses depth-first search (recursion) with temporal complexity `O(n)`.

## Problem description

Given the `root` of a binary tree, return its maximum depth.

A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

- Example 1:

```
Input: root = [3,9,20,null,null,15,7]
Output: 3
```

- Example 2:

```
Input: root = [1,null,2]
Output: 2
```

## Solution:

The depth of a node is `1` plus the maximum depth of its children. An empty tree has depth `0`.

```
depth(root) = 0                          if root is null
depth(root) = 1 + max(depth(L), depth(R)) otherwise
```

Walk for `root = [3,9,20,null,null,15,7]`:

1. Leaf `9` → depth `1`
2. Leaves `15` and `7` → depth `1` each; node `20` → `1 + max(1,1) = 2`
3. Root `3` → `1 + max(1, 2) = 3`

## Implementations:

### C# :

```csharp
// Using depth-first search - Time: O(n)

public class Solution
{
    public int MaxDepth(TreeNode root)
    {
        return root != null ? 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right)) : 0;
    }
}
```

1. One expression: base case `0`, otherwise `1 + max` of both sides.

2. Visits each node once → `O(n)` time, `O(h)` stack space.
