# Binary Tree Maximum Path Sum:

This directory contains an implementation of the "Binary Tree Maximum Path Sum" problem in C#. The implementation uses depth-first search with temporal complexity `O(n)`.

## Problem description

A **path** in a binary tree is a sequence of nodes where each pair of adjacent nodes in the sequence has an edge connecting them. A node can only appear in the sequence **at most once**. The path does not need to pass through the root.

The **path sum** is the sum of the node's values in the path.

Given the `root` of a binary tree, return the maximum path sum of any non-empty path.

- Example 1:

```
Input: root = [1,2,3]
Output: 6
Explanation: The optimal path is 2 → 1 → 3 with sum 6.
```

- Example 2:

```
Input: root = [-10,9,20,null,null,15,7]
Output: 42
Explanation: The optimal path is 15 → 20 → 7 with sum 42.
```

## Solution:

For each node, DFS returns the **best downward contribution** that parent can use (only one child branch can continue upward):

```
gain(node) = max(0, node.val + max(gain(left), gain(right)))
```

Negative gains are clamped to `0` (skip that branch).

At each node, also consider a path that uses **both** children as a candidate global answer:

```
ans = max(ans, node.val + gain(left) + gain(right))
```

For `root = [-10,9,20,null,null,15,7]`:

1. At `20`: path `15 + 20 + 7 = 42` updates `ans`
2. Gain returned to `-10` from `20` is `20 + max(15,7) = 35`
3. Path through `-10` is worse; final answer is `42`

## Implementations:

### C# :

```csharp
// Using depth-first search - Time: O(n)

public class Solution
{
    private int ans = int.MinValue;

    private int dfs(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        int left = dfs(root.left);
        int right = dfs(root.right);

        ans = Math.Max(ans, root.val + left + right);
        return Math.Max(0, root.val + Math.Max(left, right));
    }

    public int MaxPathSum(TreeNode root)
    {
        dfs(root);
        return ans;
    }
}
```

1. `dfs` returns the best single-branch gain for the parent.

2. Global `ans` tracks the best path that may bend at the current node.

## Suggested practice 🎯

Same post-order recursion with a global max pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Diameter of Binary Tree](https://leetcode.com/problems/diameter-of-binary-tree/)
- [Path Sum](https://leetcode.com/problems/path-sum/)
- [Path Sum III](https://leetcode.com/problems/path-sum-iii/)
