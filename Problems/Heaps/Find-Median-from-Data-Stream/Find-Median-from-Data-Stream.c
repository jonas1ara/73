#include <stdio.h>
#include <stdlib.h>

// Using two heaps - Time: O(log(n))

struct MedianFinder {
    int *sm;
    int *gt;
    int sm_size;
    int gt_size;
};

struct MedianFinder *createMedianFinder() {
    struct MedianFinder *obj = (struct MedianFinder *)malloc(sizeof(struct MedianFinder));
    obj->sm = NULL;
    obj->gt = NULL;
    obj->sm_size = 0;
    obj->gt_size = 0;

    return obj;
}

void addNum(struct MedianFinder *obj, int num)
{
    if (obj->gt_size && num > obj->gt[0])
    {
        obj->gt_size++;
        obj->gt = (int *)realloc(obj->gt, obj->gt_size * sizeof(int));
        obj->gt[obj->gt_size - 1] = num;

        if (obj->gt_size > obj->sm_size)
        {
            obj->sm_size++;
            obj->sm = (int *)realloc(obj->sm, obj->sm_size * sizeof(int));
            obj->sm[obj->sm_size - 1] = obj->gt[0];

            // Move the smallest element from gt to sm
            for (int i = 0; i < obj->gt_size - 1; i++)
            {
                obj->gt[i] = obj->gt[i + 1];
            }
            obj->gt_size--;
            obj->gt = (int *)realloc(obj->gt, obj->gt_size * sizeof(int));
        }
    }
    else
    {
        obj->sm_size++;
        obj->sm = (int *)realloc(obj->sm, obj->sm_size * sizeof(int));
        obj->sm[obj->sm_size - 1] = num;

        if (obj->sm_size > obj->gt_size + 1)
        {
            obj->gt_size++;
            obj->gt = (int *)realloc(obj->gt, obj->gt_size * sizeof(int));
            obj->gt[obj->gt_size - 1] = obj->sm[0];

            // Move the smallest element from sm to gt
            for (int i = 0; i < obj->sm_size - 1; i++)
            {
                obj->sm[i] = obj->sm[i + 1];
            }
            obj->sm_size--;
            obj->sm = (int *)realloc(obj->sm, obj->sm_size * sizeof(int));
        }
    }
}

double findMedian(struct MedianFinder *obj)
{
    if (obj->sm_size > obj->gt_size)
    {
        return obj->sm[0];
    }
    else
    {
        return (double)(obj->sm[0] + obj->gt[0]) / 2;
    }
}

void freeMedianFinder(struct MedianFinder *obj)
{
    free(obj->sm);
    free(obj->gt);
    free(obj);
}

int main()
{
    struct MedianFinder *medianFinder = createMedianFinder();

    printf("Input\n");
    printf("[\"MedianFinder\", \"addNum\", \"addNum\", \"findMedian\", \"addNum\", \"findMedian\"]\n");
    printf("[[], [1], [2], [], [3], []]\n");

    printf("Output\n");
    printf("[[null], ");

    addNum(medianFinder, 1);
    printf("[null], ");

    addNum(medianFinder, 2);
    printf("[null], ");

    printf("[%0.1f], ", findMedian(medianFinder));

    addNum(medianFinder, 3);
    printf("[null], ");

    printf("[%0.1f]]\n", findMedian(medianFinder));

    freeMedianFinder(medianFinder);

    return 0;
}