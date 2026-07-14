# Subtree of Another Tree:

This directory contains an implementation of the "Subtree of Another Tree" problem in C#. The implementation checks every node of the main tree against the candidate subtree with temporal complexity `O(m · n)`.

## Problem description

Given the roots of two binary trees `root` and `subRoot`, return `true` if there is a subtree of `root` with the same structure and node values of `subRoot`, and `false` otherwise.

A subtree of a binary tree `tree` is a tree that consists of a node in `tree` and all of this node's descendants.

- Example 1:

```
Input: root = [3,4,5,1,2], subRoot = [4,1,2]
Output: true
```

- Example 2:

```
Input: root = [3,4,5,1,2,null,null,null,null,0], subRoot = [4,1,2]
Output: false
```

## Solution:

Two helpers:

1. **`IsSameTree(a, b)`** — identical structure and values (same as the Same Tree problem)
2. **`IsSubtree(root, subRoot)`** — `subRoot` matches at `root`, or appears in the left subtree, or in the right subtree

```
IsSubtree(root, sub) =
    IsSameTree(root, sub)
    OR (root ≠ null AND (IsSubtree(left) OR IsSubtree(right)))
```

For `root = [3,4,5,1,2]`, `subRoot = [4,1,2]`:

1. Root `3` is not the same tree as `subRoot`
2. Check left child `4` → `IsSameTree` matches fully → `true`

## Implementations:

### C# :

```csharp
// Using recursion - Time: O(m * n)

public class Solution
{
    private bool IsSameTree(TreeNode root, TreeNode subRoot)
    {
        return (root == null && subRoot == null) ||
               (root != null && subRoot != null &&
                root.val == subRoot.val &&
                IsSameTree(root.left, subRoot.left) &&
                IsSameTree(root.right, subRoot.right));
    }

    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        return IsSameTree(root, subRoot) ||
               (root != null && (IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot)));
    }
}
```

1. `IsSameTree` verifies an exact match at the current alignment.

2. `IsSubtree` tries the current node, then left, then right.

### F# :

```fsharp
open System

[<AllowNullLiteral>]
type TreeNode(v: int, left: TreeNode, right: TreeNode) =
    new(v: int) = TreeNode(v, null, null)
    member val Val = v with get, set
    member val Left = left with get, set
    member val Right = right with get, set

type Solution() =
    let rec isSameTree (root: TreeNode) (subRoot: TreeNode) =
        (isNull root && isNull subRoot)
        || (not (isNull root) && not (isNull subRoot) && root.Val = subRoot.Val
            && isSameTree root.Left subRoot.Left
            && isSameTree root.Right subRoot.Right)

    member this.IsSubtree(root: TreeNode, subRoot: TreeNode) =
        let rec check (node: TreeNode) =
            isSameTree node subRoot
            || (not (isNull node) && (check node.Left || check node.Right))
        check root
```

1. `[<AllowNullLiteral>]` : F# reference types can't hold `null` by default; this attribute opts `TreeNode` back in so it behaves like a C# reference (`null` children, `isNull` checks).

2. `let rec isSameTree ... = ... isSameTree ...` : A private recursive `let` binding inside the type plays the same role as the C# private method.

3. `member this.IsSubtree(...)` : Defines a local recursive `check` function that closes over `subRoot`, avoiding re-passing it on every call like the C# version does.

4. The boolean logic (`isSameTree node subRoot || (not (isNull node) && ...)`) mirrors the C# `||`/`&&` short-circuiting exactly.
