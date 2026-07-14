# Validate Binary Search Tree:

This directory contains an implementation of the "Validate Binary Search Tree" problem in C#. The implementation uses in-order traversal with temporal complexity `O(n)`.

## Problem description

Given the `root` of a binary tree, determine if it is a valid binary search tree (BST).

A valid BST is defined as follows:

- The left subtree of a node contains only nodes with keys **strictly less** than the node's key
- The right subtree of a node contains only nodes with keys **strictly greater** than the node's key
- Both the left and right subtrees must also be binary search trees

- Example 1:

```
Input: root = [2,1,3]
Output: true
```

- Example 2:

```
Input: root = [5,1,4,null,null,3,6]
Output: false
Explanation: The root node's value is 5 but its right child's value is 4.
```

## Solution:

In-order traversal of a BST visits values in **strictly increasing** order. Keep a pointer `prev` to the previous node:

1. Recurse into the left subtree
2. If `prev` exists and `prev.val >= root.val` → not a BST
3. Set `prev = root`
4. Recurse into the right subtree

For `root = [5,1,4,null,null,3,6]`:

1. Visit `1` → `prev = 1`
2. Visit `5` → `1 < 5` OK → `prev = 5`
3. Visit `3` → `5 >= 3` → **false**

## Implementations:

### C# :

```csharp
// Using in-order traversal - Time O(n)

public class Solution
{
    private TreeNode prev = null;

    public bool IsValidBST(TreeNode root)
    {
        if (root == null)
            return true;

        if (!IsValidBST(root.left) || (prev != null && prev.val >= root.val))
            return false;

        prev = root;

        return IsValidBST(root.right);
    }
}
```

1. Left-root-right order guarantees increasing values in a valid BST.

2. Strict `<` is enforced via `prev.val >= root.val` failing the check.

## Suggested practice 🎯

Same in-order traversal / bounds recursion pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Recover Binary Search Tree](https://leetcode.com/problems/recover-binary-search-tree/)
- [Binary Search Tree Iterator](https://leetcode.com/problems/binary-search-tree-iterator/)
- [Convert Sorted Array to Binary Search Tree](https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/)
