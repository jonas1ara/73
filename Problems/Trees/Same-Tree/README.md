# Same Tree:

This directory contains an implementation of the "Same Tree" problem in C#. The implementation uses depth-first search to compare structure and values with temporal complexity `O(n)`.

## Problem description

Given the roots of two binary trees `p` and `q`, write a function to check if they are the same or not.

Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.

- Example 1:

```
Input: p = [1,2,3], q = [1,2,3]
Output: true
```

- Example 2:

```
Input: p = [1,2], q = [1,null,2]
Output: false
```

- Example 3:

```
Input: p = [1,2,1], q = [1,1,2]
Output: false
```

## Solution:

Recursively compare both trees:

1. Both null → same (`true`)
2. One null and the other not → different (`false`)
3. Values differ → different
4. Otherwise, both left subtrees and both right subtrees must match

For `p = [1,2,3]`, `q = [1,2,3]`:

1. Roots equal (`1`)
2. Left: both `2` (leaves) → true
3. Right: both `3` (leaves) → true
4. Overall `true`

## Implementations:

### C# :

```csharp
// Using depth-first search - Time: O(n)

public class Solution
{
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        return (p == null && q == null) ||
               (p != null && q != null &&
                p.val == q.val &&
                IsSameTree(p.left, q.left) &&
                IsSameTree(p.right, q.right));
    }
}
```

1. Single boolean expression covering null cases, value equality, and recursive children.

2. Short-circuits as soon as a mismatch is found.
