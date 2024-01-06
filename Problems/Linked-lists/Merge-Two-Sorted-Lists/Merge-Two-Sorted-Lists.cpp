#include <iostream>

// Using a part of the merge sort algorithm - Time: O(m + n)

struct ListNode {
    int val;
    ListNode *next;
    ListNode() : val(0), next(nullptr) {}
    ListNode(int x) : val(x), next(nullptr) {}
    ListNode(int x, ListNode *next) : val(x), next(next) {}
};

class Solution {
public:
    ListNode *mergeTwoLists(ListNode *list1, ListNode *list2)
    {
        ListNode *head = new ListNode(0);
        ListNode *p = head;
        head->next = list1;

        while (p->next != nullptr && list2 != nullptr)
        {
            if (p->next->val > list2->val)
            {
                ListNode *node = list2;
                list2 = list2->next;
                node->next = p->next;
                p->next = node;
            }
            p = p->next;
        }

        if (list2 != nullptr)
        {
            p->next = list2;
        }

        return head->next;
    }
};

void printList(ListNode *node)
{
    std::cout << "[";
    while (node != nullptr)
    {
        std::cout << node->val;
        node = node->next;
        if (node != nullptr)
        {
            std::cout << ", ";
        }
    }
    std::cout << "]";
}

int main()
{
    ListNode *list1 = new ListNode(1, new ListNode(2, new ListNode(4)));
    ListNode *list2 = new ListNode(1, new ListNode(3, new ListNode(4)));

    std::cout << "Input: list 1 = ";
    printList(list1);

    std::cout << ", list 2 = ";
    printList(list2);
    std::cout << std::endl;

    Solution sol;
    ListNode *mergedList = sol.mergeTwoLists(list1, list2);

    std::cout << "Output: ";
    printList(mergedList);
    std::cout << std::endl;

    delete mergedList;

    return 0;
}
