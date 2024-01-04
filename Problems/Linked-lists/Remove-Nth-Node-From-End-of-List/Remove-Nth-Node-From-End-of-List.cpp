#include <iostream>

// Using two pointers - Time: O(n)

struct ListNode {
    int val;
    ListNode *next;
    ListNode() : val(0), next(nullptr) {}
    ListNode(int x) : val(x), next(nullptr) {}
    ListNode(int x, ListNode *next) : val(x), next(next) {}
};

class Solution {
public:
    ListNode *removeNthFromEnd(ListNode *head, int n)
    {
        ListNode *p = head;
        ListNode *q = head;

        while (n > 0)
        {
            q = q->next;
            n--;
        }

        if (q == nullptr)
        {
            return head->next;
        }

        while (q->next != nullptr)
        {
            p = p->next;
            q = q->next;
        }

        p->next = p->next->next;

        return head;
    }
};

void printList(ListNode *head)
{
    std::cout << "[";
    while (head != nullptr)
    {
        std::cout << head->val;
        head = head->next;
        if (head != nullptr)
        {
            std::cout << ", ";
        }
    }
    std::cout << "]";
}

int main()
{
    ListNode *head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
    int n = 2;

    std::cout << "Input: head = ";
    printList(head);
    std::cout << ", n = " << n << std::endl;

    Solution sol;
    head = sol.removeNthFromEnd(head, n);

    std::cout << "Output: ";
    printList(head);
    std::cout << std::endl;

    delete head;

    return 0;
}
