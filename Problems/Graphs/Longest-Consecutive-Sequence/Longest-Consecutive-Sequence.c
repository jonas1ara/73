#include <stdio.h>
#include <stdlib.h>

// Using union find algorithm - Time: O(n)

struct UnionFind
{
    int *id;
    int *size;
};

void initializeUnionFind(struct UnionFind *uf, int n)
{
    uf->id = (int *)malloc(n * sizeof(int));
    uf->size = (int *)malloc(n * sizeof(int));

    for (int i = 0; i < n; i++)
    {
        uf->id[i] = i;
        uf->size[i] = 1;
    }
}

int find(struct UnionFind *uf, int a)
{
    return (uf->id[a] == a) ? a : (uf->id[a] = find(uf, uf->id[a]));
}

void connect(struct UnionFind *uf, int a, int b)
{
    int x = find(uf, a);
    int y = find(uf, b);

    if (x == y)
        return;

    uf->id[x] = y;
    uf->size[y] += uf->size[x];
}

int *getSizes(struct UnionFind *uf)
{
    return uf->size;
}

void freeUnionFind(struct UnionFind *uf)
{
    free(uf->id);
    free(uf->size);
}

int longestConsecutive(int *nums, int numsSize)
{
    if (numsSize == 0)
        return 0;

    struct UnionFind uf;
    initializeUnionFind(&uf, numsSize);

    int *m = (int *)malloc(numsSize * sizeof(int));

    for (int i = 0; i < numsSize; i++)
    {
        int n = nums[i];
        if (m[n])
            continue;

        m[n] = i;

        if (m[n + 1])
            connect(&uf, m[n], m[n + 1]);

        if (m[n - 1])
            connect(&uf, m[n], m[n - 1]);
    }

    int *sizes = getSizes(&uf);
    int result = 0;

    for (int i = 0; i < numsSize; i++)
    {
        if (sizes[i] > result)
            result = sizes[i];
    }

    free(m);
    freeUnionFind(&uf);

    return result;
}

int main()
{
    int nums[] = {0,3,7,2,5,8,4,6,0,1};
    int numsSize = sizeof(nums) / sizeof(nums[0]);

    printf("Input: [");
    for (int i = 0; i < numsSize; i++)
    {
        printf("%d", nums[i]);
        if (i < numsSize - 1)
            printf(",");
    }
    printf("]\n");

    int result = longestConsecutive(nums, numsSize);

    printf("Output: %d\n", result);

    return 0;
}
