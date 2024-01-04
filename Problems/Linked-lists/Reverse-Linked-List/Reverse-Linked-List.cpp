#include <iostream>
#include <array>

// Using recursion - Time: O(n)

struct ListNode {
    int val;
    ListNode *next;
    ListNode() : val(0), next(nullptr) {}
    ListNode(int x) : val(x), next(nullptr) {}
    ListNode(int x, ListNode *next) : val(x), next(next) {}
};

class Solution {
    std::array<ListNode*, 2> reverse(ListNode *head) 
    {
        if (!head->next) return {head, head};
    
        auto [h, t] = reverse(head->next);
        t->next = head;
        head->next = NULL;
    
        return {h, head};
    }

public:
    ListNode* reverseList(ListNode* head) 
    {
        if (!head) return NULL;
        return reverse(head)[0];
    }
};

// Using iteration - Time: O(n)

// class Solution {
// public:
//     ListNode* reverseList(ListNode* head) {
//         ListNode h;
//         while (head) {
//             auto p = head;
//             head = head->next;
//             p->next = h.next;
//             h.next = p;
//         }
//         return h.next;
//     }
// };

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
    ListNode *list = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));

    std::cout << "Input: head = ";
    printList(list);
    std::cout << std::endl;

    Solution sol;
    ListNode *reversedList = sol.reverseList(list);

    std::cout << "Output: ";
    printList(reversedList);
    std::cout << std::endl;

    delete list;

    return 0;
}

