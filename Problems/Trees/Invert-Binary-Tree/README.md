# Invert Binary Tree:

This directory contains an implementation of the "Invert Binary Tree" problem in C#. The implementation uses recursion to swap every left and right child with temporal complexity `O(n)`.

## Problem description

Given the `root` of a binary tree, invert the tree, and return its root.

- Example 1:

```
Input: root = [4,2,7,1,3,6,9]
Output: [4,7,2,9,6,3,1]
```

- Example 2:

```
Input: root = [2,1,3]
Output: [2,3,1]
```

- Example 3:

```
Input: root = []
Output: []
```

## Solution:

An inverted binary tree is the mirror image of the original: every left child becomes a right child and vice versa, recursively for the whole tree.

1. Base case: if `root` is `null`, return `null`
2. Swap `root.left` and `root.right`
3. Recursively invert the new left and right subtrees
4. Return `root`

For `root = [4,2,7,1,3,6,9]`:

1. Swap `2` and `7` → `[4,7,2,...]`
2. Invert left subtree rooted at `7` → children become `9,6`
3. Invert right subtree rooted at `2` → children become `3,1`
4. Result: `[4,7,2,9,6,3,1]`

## Implementations:

### C# :

```csharp
// Using recursion - Time: O(n)

public class Solution
{
    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null)
        {
            return null;
        }

        Swap(ref root.left, ref root.right);
        InvertTree(root.left);
        InvertTree(root.right);

        return root;
    }

    private void Swap<T>(ref T x, ref T y)
    {
        T temp = x;
        x = y;
        y = temp;
    }
}
```

1. Null root → nothing to invert.

2. Swap left and right children, then recurse into both subtrees.

3. Return the same root (structure inverted in place).
