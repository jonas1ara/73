// int arr[] = {2, 5, 7, 10, 14, 18, 20};
// int n = sizeof(arr) / sizeof(arr[0]);
// int target = 10;

int binarySearch(int arr[], int left, int right, int target)
{
    if (right >= left)
    {
        int half = left + (right - left) / 2;

        if (arr[half] == target)
        {
            return half;
        }

        if (arr[half] > target)
        {
            return binarySearch(arr, left, half - 1, target);
        }

        return binarySearch(arr, half + 1, right, target);
    }

    return -1; 
}