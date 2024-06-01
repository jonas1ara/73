#include <stdio.h>
#include <stdlib.h>

// Using hash table - Time: O(n)

#define SIZE 10000

typedef struct
{
    int key;
    int value;
} HashNode;

typedef struct
{
    HashNode **array;
} HashMap;

HashMap *createHashMap()
{
    HashMap *map = (HashMap *)malloc(sizeof(HashMap));
    map->array = (HashNode **)calloc(SIZE, sizeof(HashNode *));
    return map;
}

void insert(HashMap *map, int key, int value)
{
    int index = abs(key) % SIZE;
    while (map->array[index] != NULL && map->array[index]->key != key)
    {
        index = (index + 1) % SIZE;
    }
    if (map->array[index] == NULL)
    {
        map->array[index] = (HashNode *)malloc(sizeof(HashNode));
    }
    map->array[index]->key = key;
    map->array[index]->value = value;
}

int search(HashMap *map, int key)
{
    int index = abs(key) % SIZE;
    while (map->array[index] != NULL)
    {
        if (map->array[index]->key == key)
        {
            return map->array[index]->value;
        }
        index = (index + 1) % SIZE;
    }
    return -1;
}

int *twoSum(int *nums, int numsSize, int target, int *returnSize)
{
    HashMap *map = createHashMap();
    for (int i = 0; i < numsSize; i++)
    {
        int t = target - nums[i];
        int searchIndex = search(map, t);

        // If the hash table contains the key, return the index and the current index i
        
		if (searchIndex != -1)
        {
            int *result = (int *)malloc(2 * sizeof(int));
            result[0] = searchIndex;
            result[1] = i;
            *returnSize = 2;
            return result;
        }
        insert(map, nums[i], i);
    }

    *returnSize = 0;
    return NULL; 
}

int main()
{
    int nums[] = {2, 7, 11, 15};
    int target = 9;
    int returnSize;

    printf("Input: nums = [");
    for (int i = 0; i < sizeof(nums) / sizeof(nums[0]); i++)
    {
        printf("%d, ", nums[i]);
    }
    printf("], target = %d\n", target);

    int *result = twoSum(nums, sizeof(nums) / sizeof(nums[0]), target, &returnSize);

    if (result != NULL)
    {
        printf("Output: [%d, %d]\n", result[0], result[1]);
        free(result);
    }
    else
    {
        printf("Output: []\n");
    }

    return 0;
}
