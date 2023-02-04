#include <iostream>
#include <vector>

using namespace std;

string longestCommonPrefix(vector<string>& A)
{
        int len = A[0].size();
        
		for (int i = 1; i < A.size() && len; ++i)
		{
            int j = 0, end = min(len, (int)A[i].size());
        
		    while (j < end && A[0][j] == A[i][j]) ++j;
        
		    len = j;
        }
        return A[0].substr(0, len);
}

int main()
{
    vector<string> A = {"flower","flow","flight"};
    cout << longestCommonPrefix(A);
    
    return 0;
}
