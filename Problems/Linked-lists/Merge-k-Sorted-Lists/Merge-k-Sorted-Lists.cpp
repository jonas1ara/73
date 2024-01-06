#include <iostream>
#include <vector>

// Using merge sort algorithm - Time: O(nlogn)

struct ListNode {
    int val;
    ListNode *next;
    ListNode() : val(0), next(nullptr) {}
    ListNode(int x) : val(x), next(nullptr) {}
    ListNode(int x, ListNode *next) : val(x), next(next) {}
};

class Solution {
private:
    ListNode *mergeTwoLists(ListNode *a, ListNode *b)
    {
        // a = lists[i], b = lists[i + step]

        ListNode *head = new ListNode(0);
        ListNode *tail = head;

        while (a != nullptr && b != nullptr)
        {
            if (a->val < b->val)
            {
                tail->next = a;
                a = a->next;
            }
            else
            {
                tail->next = b;
                b = b->next;
            }
            tail = tail->next;
        }
        tail->next = a ? a : b;

        return head->next;
    }

public:
    ListNode *mergeKLists(std::vector<ListNode *> &lists)
    {
        if (lists.empty())
        {
            return nullptr;
        }

        int n = lists.size();

        for (int step = 1; step < n; step <<= 1)
        {
            for (int i = 0; i < n - step; i += step << 1)
            {
                lists[i] = mergeTwoLists(lists[i], lists[i + step]);
            }
        }

        return lists[0];
    }
};

void PrintList(ListNode* head) 
{
    std::cout << "[";
    while (head != nullptr) {
        std::cout << head->val;
        head = head->next;
        if (head != nullptr) {
            std::cout << ", ";
        }
    }
    std::cout << "]";
}

int main()
{
    ListNode *list1 = new ListNode(1, new ListNode(4, new ListNode(5)));
    ListNode *list2 = new ListNode(1, new ListNode(3, new ListNode(6)));
    ListNode *list3 = new ListNode(2, new ListNode(7, new ListNode(8)));

    std::vector<ListNode *> lists = {list1, list2, list3};

    std::cout << "Input: lists = ";
    for (int i = 0; i < lists.size(); i++)
    {
        PrintList(lists[i]);
        if (i < lists.size() - 1)
        {
            std::cout << ", ";
        }
    }
    std::cout << std::endl;

    Solution sol;
    ListNode *mergedList = sol.mergeKLists(lists);

    std::cout << "Output: ";
    PrintList(mergedList);
    std::cout << std::endl;

    return 0;
}
