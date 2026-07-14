# Construct Binary Tree from Preorder and Inorder Traversal:

This directory contains an implementation of the "Construct Binary Tree from Preorder and Inorder Traversal" problem in C#. The implementation rebuilds the tree recursively with temporal complexity `O(n²)` in the linear-scan version (or `O(n)` with an index map).

## Problem description

Given two integer arrays `preorder` and `inorder` where `preorder` is the preorder traversal of a binary tree and `inorder` is the inorder traversal of the same tree, construct and return the binary tree.

- Example 1:

```
Input: preorder = [3,9,20,15,7], inorder = [9,3,15,20,7]
Output: [3,9,20,null,null,15,7]
```

- Example 2:

```
Input: preorder = [-1], inorder = [-1]
Output: [-1]
```

## Solution:

- **Preorder**: root, then left subtree, then right subtree
- **Inorder**: left subtree, root, then right subtree

Algorithm:

1. First element of the current preorder range is the root
2. Find that value in the inorder range → everything left of it is the left subtree; everything right is the right subtree
3. Split both arrays into corresponding ranges and recurse

For `preorder = [3,9,20,15,7]`, `inorder = [9,3,15,20,7]`:

1. Root = `3`; inorder splits into left `[9]` and right `[15,20,7]`
2. Left: preorder next is `9` → leaf
3. Right: preorder starts with `20`; inorder `[15,20,7]` → left `15`, right `7`
4. Result: `[3,9,20,null,null,15,7]`

## Implementations:

### C# :

```csharp
// Using preorder and inorder traversal - Time: O(n)

public class Solution
{
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        if (preorder.Length == 0 || inorder.Length == 0)
        {
            return null;
        }
        return BuildTree(preorder, 0, preorder.Length, inorder, 0, inorder.Length);
    }

    private TreeNode BuildTree(int[] preorder, int preorderStart, int preorderEnd,
                               int[] inorder, int inorderStart, int inorderEnd)
    {
        var root = new TreeNode(preorder[preorderStart]);

        var inorderIndex = inorderStart;
        for (; inorderIndex < inorderEnd; inorderIndex++)
        {
            if (inorder[inorderIndex] == preorder[preorderStart])
            {
                break;
            }
        }

        var leftLength = inorderIndex - inorderStart;

        if (leftLength > 0)
        {
            root.left = BuildTree(preorder, preorderStart + 1, preorderStart + 1 + leftLength,
                                  inorder, inorderStart, inorderIndex);
        }
        if (inorderEnd > inorderIndex + 1)
        {
            root.right = BuildTree(preorder, preorderStart + 1 + leftLength, preorderEnd,
                                   inorder, inorderIndex + 1, inorderEnd);
        }

        return root;
    }
}
```

1. Ranges are half-open / end-exclusive style indices over the original arrays (no copying).

2. `leftLength` sizes the left preorder slice after the root.

## Suggested practice 🎯

Same traversal-to-tree reconstruction pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Construct Binary Tree from Inorder and Postorder Traversal](https://leetcode.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/)
- [Construct Binary Search Tree from Preorder Traversal](https://leetcode.com/problems/construct-binary-search-tree-from-preorder-traversal/)
- [Convert Sorted Array to Binary Search Tree](https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/)
