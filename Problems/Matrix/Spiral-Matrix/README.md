# Spiral Matrix:

This directory contains an implementation of the "Spiral Matrix" problem in C#. The implementation walks the matrix layer by layer in spiral order with temporal complexity `O(m·n)`.

## Problem description

Given an `m x n` matrix, return all elements of the matrix in spiral order.

- Example 1:

```
Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
Output: [1,2,3,6,9,8,7,4,5]
```

- Example 2:

```
Input: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
Output: [1,2,3,4,8,12,11,10,9,5,6,7]
```

## Solution:

Think of the matrix as concentric rectangles (layers). For layer `i`:

1. Left → right along the top row
2. Top → bottom along the right column
3. Right → left along the bottom row (if it is not the same as the top)
4. Bottom → top along the left column (if it is not the same as the right)

Guards `m - i - 1 != i` and `n - i - 1 != i` avoid double-counting a single middle row or column.

Stop when `ans` has collected all `m * n` elements.

Let's go through `[[1,2,3],[4,5,6],[7,8,9]]`:

1. Layer 0 top: `1,2,3`
2. Right: `6,9`
3. Bottom: `8,7`
4. Left: `4`
5. Center layer: `5`
6. Result: `[1,2,3,6,9,8,7,4,5]`

## Implementations:

### C# :

```csharp
// Using spiral iterative traversals - Time: O(m⋅n)

public class Solution
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        if (matrix.Length == 0 || matrix[0].Length == 0)
        {
            return new List<int>();
        }

        List<int> ans = new List<int>();
        int m = matrix.Length;
        int n = matrix[0].Length;

        for (int i = 0; ans.Count < m * n; i++)
        {
            for (int j = i; j < n - i; j++)
                ans.Add(matrix[i][j]);

            for (int j = i + 1; j < m - i; j++)
                ans.Add(matrix[j][n - i - 1]);

            if (m - i - 1 != i)
            {
                for (int j = n - i - 2; j >= i; j--)
                    ans.Add(matrix[m - i - 1][j]);
            }

            if (n - i - 1 != i)
            {
                for (int j = m - i - 2; j > i; j--)
                    ans.Add(matrix[j][i]);
            }
        }

        return ans;
    }
}
```

1. `public class Solution` : Define a public class called `Solution`.

2. `public IList<int> SpiralOrder(int[][] matrix)` : Return matrix elements in spiral order.

3. Handle empty matrix early.

4. Layer loop continues until all elements are collected.

5. Four directional passes per layer, with guards for single-row/column layers.

6. `return ans;` : Return the spiral sequence.

## Suggested practice 🎯

Same boundary-by-boundary traversal pattern, different constraints — solve these next to check you generalized it instead of memorizing it:

- [Spiral Matrix II](https://leetcode.com/problems/spiral-matrix-ii/)
- [Spiral Matrix III](https://leetcode.com/problems/spiral-matrix-iii/)
- [Diagonal Traverse](https://leetcode.com/problems/diagonal-traverse/)
