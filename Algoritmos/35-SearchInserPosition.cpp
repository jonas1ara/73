#include <iostream>
#include <vector>

using namespace std;

int searchInsert(vector<int> &A, int target)
{
    int L = 0, R = A.size() - 1;
    while (L <= R)
    {
        int M = (L + R) / 2;
        if (A[M] == target)
            return M;
        if (A[M] < target)
            L = M + 1;
        else
            R = M - 1;
    }
    return L;
}

int main()
{
    vector <int> A = {1, 3, 5, 6};
    int target = 5;

    cout << searchInsert(A, target) << endl;

    return 0;

}