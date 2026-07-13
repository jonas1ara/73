# Rotate Image:

This directory contains implementations of the "Rotate Image" problem in the C, C++, and C# languages. Each implementation rotates an `n x n` matrix 90 degrees clockwise in place with temporal complexity `O(n^2)`.

## Problem description

You are given an `n x n` 2D matrix representing an image, rotate the image by 90 degrees (clockwise).

You have to rotate the image in-place, which means you have to modify the input 2D matrix directly. DO NOT allocate another 2D matrix and do the rotation.

- Example 1:

```
Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
Output: [[7,4,1],[8,5,2],[9,6,3]]
```

- Example 2:

```
Input: matrix = [[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]]
Output: [[15,13,2,5],[14,3,4,1],[12,6,8,9],[16,7,10,11]]
```

## Solution:

A 90° clockwise rotation maps `(i, j)` → `(j, n - 1 - i)`.

The C++/C# solutions rotate layer by layer: for each ring, cycle four cells in place with a temporary variable.

The C solution does it as two steps:

1. **Transpose** the matrix (`matrix[i][j] ↔ matrix[j][i]`)
2. **Reverse each row** (swap left/right)

Both approaches use constant extra space besides a few variables.

Let's go through `[[1,2,3],[4,5,6],[7,8,9]]` with the cycle method (outer layer only):

1. Cycle `1 → 3 → 9 → 7 → 1`
2. Cycle `2 → 6 → 8 → 4 → 2`
3. Center `5` stays
4. Result: `[[7,4,1],[8,5,2],[9,6,3]]`

## Implementations:

### C# :

```csharp
// Using in-place algorithm - Time: O(n^2)

public class Solution
{
    public void Rotate(int[][] matrix)
    {
        int n = matrix.Length;

        for (int i = 0; i < n / 2; i++)
        {
            for (int j = i; j < n - i - 1; j++)
            {
                int tmp = matrix[i][j];
                matrix[i][j] = matrix[n - j - 1][i];
                matrix[n - j - 1][i] = matrix[n - i - 1][n - j - 1];
                matrix[n - i - 1][n - j - 1] = matrix[j][n - i - 1];
                matrix[j][n - i - 1] = tmp;
            }
        }
    }
}
```

1. `public class Solution` : Define a public class called `Solution`.

2. `public void Rotate(int[][] matrix)` : Rotate the matrix 90° clockwise in place.

3. Outer loop `i` iterates over layers from the outside in.

4. Inner loop `j` walks the top edge of the current layer (excluding the last corner).

5. The four assignments cycle values: top ← left ← bottom ← right ← top (via `tmp`).

### C++ :

```cpp
// Using in-place algorithm - Time: O(n^2)

class Solution {
public:
    void rotate(std::vector<std::vector<int>> &matrix)
    {
        int n = matrix.size();

        for (int i = 0; i < n / 2; i++)
        {
            for (int j = i; j < n - i - 1; j++)
            {
                int tmp = matrix[i][j];
                matrix[i][j] = matrix[n - j - 1][i];
                matrix[n - j - 1][i] = matrix[n - i - 1][n - j - 1];
                matrix[n - i - 1][n - j - 1] = matrix[j][n - i - 1];
                matrix[j][n - i - 1] = tmp;
            }
        }
    }
};
```

1. `class Solution {public: ...};` : Define a public class called `Solution`.

2. `void rotate(...)` : Same layer-by-layer 4-cycle rotation as C#.

### C:

```c
// Using in-place algorithm - Time: O(n^2)

void rotate(int **matrix, int matrixSize, int *matrixColSize)
{
    // Transpose the matrix
    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = i + 1; j < matrixSize; j++)
        {
            int temp = matrix[i][j];
            matrix[i][j] = matrix[j][i];
            matrix[j][i] = temp;
        }
    }

    // Reverse each row to rotate clockwise
    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = 0; j < matrixSize / 2; j++)
        {
            int temp = matrix[i][j];
            matrix[i][j] = matrix[i][matrixSize - 1 - j];
            matrix[i][matrixSize - 1 - j] = temp;
        }
    }
}
```

1. First nested loops transpose the matrix.

2. Second nested loops reverse every row.

3. Transpose + reverse row = 90° clockwise rotation.
