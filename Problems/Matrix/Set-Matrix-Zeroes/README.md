# Set Matrix Zeroes:

This directory contains an implementation of the "Set Matrix Zeroes" problem in C#. The implementation marks rows and columns that contain zeros and then zeroes them out with temporal complexity `O(m·n)`.

## Problem description

Given an `m x n` integer matrix `matrix`, if an element is `0`, set its entire row and column to `0`'s.

You must do it in place.

- Example 1:

```
Input: matrix = [[1,1,1],[1,0,1],[1,1,1]]
Output: [[1,0,1],[0,0,0],[1,0,1]]
```

- Example 2:

```
Input: matrix = [[0,1,2,0],[3,4,5,2],[1,3,1,5]]
Output: [[0,0,0,0],[0,4,5,0],[0,3,1,0]]
```

## Solution:

If you zero a cell as soon as you find a `0`, you lose information about which zeros were original.

This solution uses two boolean arrays:

1. `row[i] = true` if row `i` contains a zero
2. `col[j] = true` if column `j` contains a zero

First pass records which rows/cols must become zero. Second pass sets `matrix[i][j] = 0` when `row[i]` or `col[j]` is true.

Extra space is `O(m + n)`. (A stricter in-place variant can reuse the first row/column as markers.)

Let's go through `[[1,1,1],[1,0,1],[1,1,1]]`:

1. Find zero at `(1,1)` → `row[1] = true`, `col[1] = true`
2. Second pass zeros all of row 1 and column 1
3. Result: `[[1,0,1],[0,0,0],[1,0,1]]`

## Implementations:

### C# :

```csharp
// Using in-place algorithm - Time: O(m⋅n)

public class Solution
{
    public void SetZeroes(int[][] matrix)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;

        bool[] row = new bool[m];
        bool[] col = new bool[n];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                row[i] = row[i] || matrix[i][j] == 0;
                col[j] = col[j] || matrix[i][j] == 0;
            }
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (row[i] || col[j])
                {
                    matrix[i][j] = 0;
                }
            }
        }
    }
}
```

1. `public class Solution` : Define a public class called `Solution`.

2. `public void SetZeroes(int[][] matrix)` : Zero entire rows/cols that contain a zero.

3. `bool[] row`, `bool[] col` : Markers for rows and columns that must be zeroed.

4. First double loop: mark rows/cols when a zero is found.

5. Second double loop: write zeros where a row or column marker is set.
