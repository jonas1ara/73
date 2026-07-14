# Kth Smallest Element in a BST:

This directory contains an implementation of the "Kth Smallest Element in a BST" problem in C#. The implementation uses in-order traversal with temporal complexity `O(n)` (early exit when the k-th node is found).

## Problem description

Given the `root` of a binary search tree, and an integer `k`, return the `k`th smallest value (1-indexed) of all the values of the nodes in the tree.

- Example 1:

```
Input: root = [3,1,4,null,2], k = 1
Output: 1
```

- Example 2:

```
Input: root = [5,3,6,2,4,null,null,1], k = 3
Output: 3
```

## Solution:

In-order traversal of a BST yields values in ascending order. Decrement `k` each time a node is visited; when `k` becomes `0`, that node is the answer.

1. Recurse left
2. If a value was already found in the left subtree, bubble it up
3. Decrement `k`; if it hits `0`, return `node.val`
4. Recurse right

For `root = [3,1,4,null,2]`, `k = 1`:

1. Go left to `1`
2. Left of `1` is null; `--k == 0` → return `1`

## Implementations:

### C# :

```csharp
// Using inorder traversal - Time: O(n)

public class Solution
{
    public int KthSmallest(TreeNode root, int k)
    {
        Func<TreeNode, int> inorder = null;
        inorder = (TreeNode node) =>
        {
            if (node == null)
            {
                return -1;
            }

            int val = inorder(node.left);

            if (val != -1)
            {
                return val;
            }
            if (--k == 0)
            {
                return node.val;
            }

            return inorder(node.right);
        };

        return inorder(root);
    }
}
```

1. Sentinel `-1` means “not found yet” in this branch.

2. Shared `k` is captured by the closure and decremented on each visit.

## Suggested practice 🎯

Same in-order traversal pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Binary Search Tree Iterator](https://leetcode.com/problems/binary-search-tree-iterator/)
- [Kth Smallest Element in a Sorted Matrix](https://leetcode.com/problems/kth-smallest-element-in-a-sorted-matrix/)
- [Inorder Successor in BST](https://leetcode.com/problems/inorder-successor-in-bst/)
