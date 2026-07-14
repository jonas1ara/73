# Lowest Common Ancestor of a Binary Search Tree:

This directory contains an implementation of the "Lowest Common Ancestor of a Binary Search Tree" problem in C#. The implementation walks the BST using value comparisons with temporal complexity `O(h)` where `h` is the height of the tree.

## Problem description

Given a binary search tree (BST), find the lowest common ancestor (LCA) of two given nodes in the BST.

The lowest common ancestor is defined between two nodes `p` and `q` as the lowest node in `T` that has both `p` and `q` as descendants (where we allow a node to be a descendant of itself).

- Example 1:

```
Input: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 8
Output: 6
Explanation: The LCA of nodes 2 and 8 is 6.
```

- Example 2:

```
Input: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 4
Output: 2
Explanation: The LCA of nodes 2 and 4 is 2, since a node can be a descendant of itself.
```

## Solution:

In a BST, the LCA is the first node where `p` and `q` split to different sides (or one of them is the node itself):

- If both values are **less** than `root` → LCA is in the left subtree
- If both values are **greater** than `root` → LCA is in the right subtree
- Otherwise `root` is the split point → return `root`

For `p = 2`, `q = 8`, `root = 6`:

1. `2 < 6` and `8 > 6` → split at `6` → answer `6`

For `p = 2`, `q = 4`, `root = 6`:

1. Both `< 6` → go left to `2`
2. `2` equals `p`, and `4` is in its right subtree → answer `2`

## Implementations:

### C# :

```csharp
// Using recursion - Time: O(h)

public class Solution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root.val > p.val && root.val > q.val)
        {
            return LowestCommonAncestor(root.left, p, q);
        }
        if (root.val < p.val && root.val < q.val)
        {
            return LowestCommonAncestor(root.right, p, q);
        }
        return root;
    }
}
```

1. Only one path is followed, so time is proportional to height.

2. No need to explore both subtrees (unlike general binary trees).
