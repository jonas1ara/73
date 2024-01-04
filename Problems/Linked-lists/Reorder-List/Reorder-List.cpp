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
    int getLength(ListNode *head)
    {
        int ans = 0;
        for (; head; head = head->next)
        {
            ans++;
        }

        return ans;
    }

    ListNode *splitList(ListNode *head)
    {
        int len = (getLength(head) - 1) / 2;

        while (len--)
        {
            head = head->next;
        }
        auto ans = head->next;
        head->next = nullptr;

        return ans;
    }

    ListNode *reverseList(ListNode *head)
    {
        ListNode dummy;
        while (head)
        {
            auto node = head;
            head = head->next;
            node->next = dummy.next;
            dummy.next = node;
        }
        
        return dummy.next;
    }

    void interleave(ListNode *first, ListNode *second)
    {
        while (second)
        {
            auto node = second;
            second = second->next;
            node->next = first->next;
            first->next = node;
            first = node->next;
        }
    }

public:
    void reorderList(ListNode *head)
    {
        if (!head || !head->next) 
        {
            return;
        }
        
        auto second = splitList(head);
        second = reverseList(second);
        interleave(head, second);
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
    ListNode *list = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4))));

    std::cout << "Input: head = ";
    printList(list);
    std::cout << std::endl;

    Solution sol;
    sol.reorderList(list);

    std::cout << "Output: ";
    printList(list);
    std::cout << std::endl;

    delete list;

    return 0;
}