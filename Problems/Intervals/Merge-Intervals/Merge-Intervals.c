#include <stdio.h>
#include <stdlib.h>

// Using merge and quick sort - Time: O(nlogn)

int compare(const void *a, const void *b)
{
    int *intervalA = *(int **)a;
    int *intervalB = *(int **)b;
    return intervalA[0] - intervalB[0];
}

int **merge(int **intervals, int intervalsSize, int *intervalsColSize, int *returnSize, int **returnColumnSizes)
{
    if (intervalsSize == 0)
    {
        *returnSize = 0;
        return NULL;
    }

    qsort(intervals, intervalsSize, sizeof(int *), compare);

    int **merged = malloc(intervalsSize * sizeof(int *));
    *returnColumnSizes = malloc(intervalsSize * sizeof(int));
    merged[0] = intervals[0];
    (*returnColumnSizes)[0] = 2;
    *returnSize = 1;

    for (int i = 1; i < intervalsSize; i++)
    {
        if (merged[*returnSize - 1][1] < intervals[i][0])
        {
            merged[*returnSize] = intervals[i];
            (*returnColumnSizes)[*returnSize] = 2;
            ++(*returnSize);
        }
        else
        {
            merged[*returnSize - 1][1] = intervals[i][1] > merged[*returnSize - 1][1] ? intervals[i][1] : merged[*returnSize - 1][1];
        }
    }

    return merged;
}

int main()
{
    int intervalsSize = 4;
    int intervalsColSize[4] = {2, 2, 2, 2};
    int *intervals[4];

    for (int i = 0; i < intervalsSize; i++)
    {
        intervals[i] = malloc(intervalsColSize[i] * sizeof(int));
    }
    intervals[0][0] = 1;
    intervals[0][1] = 3;
    intervals[1][0] = 2;
    intervals[1][1] = 6;
    intervals[2][0] = 8;
    intervals[2][1] = 10;
    intervals[3][0] = 15;
    intervals[3][1] = 18;

    printf("Input: intervals = [");
    for (int i = 0; i < intervalsSize; i++)
    {
        printf("[%d, %d]", intervals[i][0], intervals[i][1]);
        if (i != intervalsSize - 1)
        {
            printf(", ");
        }
    }
    printf("]\n");

    int returnSize;
    int *returnColumnSizes;
    int **merged = merge(intervals, intervalsSize, intervalsColSize, &returnSize, &returnColumnSizes);

    printf("Output: [");
    for (int i = 0; i < returnSize; i++)
    {
        printf("[%d, %d]", merged[i][0], merged[i][1]);
        if (i != returnSize - 1)
        {
            printf(", ");
        }
    }
    printf("]\n");

    for (int i = 0; i < intervalsSize; i++)
    {
        free(intervals[i]);
    }
    free(merged);
    free(returnColumnSizes);

    return 0;
}
