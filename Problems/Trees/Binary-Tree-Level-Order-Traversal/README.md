# Binary Tree Level Order Traversal:

This directory contains an implementation of the "Binary Tree Level Order Traversal" problem in C#. The implementation uses breadth-first search (queue) with temporal complexity `O(n)`.

## Problem description

Given the `root` of a binary tree, return the level order traversal of its nodes' values (i.e., from left to right, level by level).

- Example 1:

```
Input: root = [3,9,20,null,null,15,7]
Output: [[3],[9,20],[15,7]]
```

- Example 2:

```
Input: root = [1]
Output: [[1]]
```

- Example 3:

```
Input: root = []
Output: []
```

## Solution:

BFS with a queue:

1. Enqueue the root
2. While the queue is not empty, process exactly the nodes currently in the queue (one full level)
3. Collect their values into a list for this level
4. Enqueue each node's left and right children for the next level

For `root = [3,9,20,null,null,15,7]`:

1. Level 0: `[3]` → enqueue `9`, `20`
2. Level 1: `[9,20]` → enqueue `15`, `7`
3. Level 2: `[15,7]`
4. Result: `[[3],[9,20],[15,7]]`

## Implementations:

### C# :

```csharp
// Using breadth-first search - Time: O(n)

public class Solution
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        if (root == null)
            return new List<IList<int>>();

        List<IList<int>> ans = new List<IList<int>>();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            List<int> currentLevel = new List<int>();

            for (int i = 0; i < levelSize; i++)
            {
                var node = queue.Dequeue();
                currentLevel.Add(node.val);

                if (node.left != null)
                    queue.Enqueue(node.left);

                if (node.right != null)
                    queue.Enqueue(node.right);
            }

            ans.Add(currentLevel);
        }

        return ans;
    }
}
```

1. Snapshot `levelSize` so only the current level is drained each outer loop.

2. Children are enqueued after their parent is recorded.

## Suggested practice 🎯

Same BFS by level pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Binary Tree Zigzag Level Order Traversal](https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/)
- [Binary Tree Level Order Traversal II](https://leetcode.com/problems/binary-tree-level-order-traversal-ii/)
- [Average of Levels in Binary Tree](https://leetcode.com/problems/average-of-levels-in-binary-tree/)
