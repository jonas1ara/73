#include <stdio.h>
#include <stdlib.h>

void rotate(int **matrix, int matrixSize, int *matrixColSize)
{
    // Transponer la matriz
    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = i + 1; j < matrixSize; j++)
        {
            int temp = matrix[i][j];
            matrix[i][j] = matrix[j][i];
            matrix[j][i] = temp;
        }
    }

    // Invertir las columnas
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

int main()
{
    int matrixSize = 3;
    int matrixColSize = 3;

    // allocate memory for matrix
    int **matrix = (int **)malloc(matrixSize * sizeof(int *));
    for (int i = 0; i < matrixSize; i++)
    {
        matrix[i] = (int *)malloc(matrixColSize * sizeof(int));
    }

    // Case 1 - matrix = [[1,2,3],[4,5,6],[7,8,9]]
    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = 0; j < matrixColSize; j++)
        {
            matrix[i][j] = i * matrixColSize + j + 1;
        }
    }

    // // Case 2 - matrix = [[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]]
    // int values[matrixSize][matrixColSize] = 
    // {
    //     {5, 1, 9, 11},
    //     {2, 4, 8, 10},
    //     {13, 3, 6, 7},
    //     {15, 14, 12, 16}
    // };

    // // Inicializar la matriz con los valores proporcionados
    // for (int i = 0; i < matrixSize; i++)
    // {
    //     for (int j = 0; j < matrixColSize; j++)
    //     {
    //         matrix[i][j] = values[i][j];
    //     }
    // }

    printf("Matriz original:\n");
    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = 0; j < matrixColSize; j++)
        {
            printf("%d ", matrix[i][j]);
        }
        printf("\n");
    }

    rotate(matrix, matrixSize, &matrixColSize);

    printf("\nMatriz rotada:\n");
    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = 0; j < matrixColSize; j++)
        {
            printf("%d ", matrix[i][j]);
        }
        printf("\n");
    }

    // Liberar memoria
    for (int i = 0; i < matrixSize; i++)
    {
        free(matrix[i]);
    }
    free(matrix);

    return 0;
}
