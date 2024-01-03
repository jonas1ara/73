#include <iostream>

// Using Floyd's tortoise and hare algorithm - Time: O(n) 

struct ListNode {
    int val;
    ListNode* next;

    ListNode(int x) : val(x), next(nullptr) {}
};

class Solution {
public:
    bool hasCycle(ListNode* head) 
    {
        ListNode* p = head; 
        ListNode* q = head;  

        while (q != nullptr && q->next != nullptr) 
        {
            p = p->next;
            q = q->next->next;

            if (p == q) 
            {
                return true;
            }
        }

        return false;
    }
};

int main() 
{
    // Example 1 
    // 3 -> 2 -> 0 -> -4 
    ListNode* node1 = new ListNode(3);
    ListNode* node2 = new ListNode(2);
    ListNode* node3 = new ListNode(0);
    ListNode* node4 = new ListNode(-4);

    // pos = 1
    node1->next = node2;
    node2->next = node3;
    node3->next = node4;
    node4->next = node2;

    std::cout << "Input: head = [3,2,0,-4], pos = 1" << std::endl;

    // Example 2
    // 1 -> 2
    // ListNode* node1 = new ListNode(1);
    // ListNode* node2 = new ListNode(2);

    // pos = 0
    // node1->next = node2;
    // node2->next = node1;

    // std::cout << "Input: head = [1,2], pos = 0" << std::endl;

    Solution sol;
    bool hasCycle = sol.hasCycle(node1);

    if (hasCycle) {
        std::cout << "Output: true" << std::endl;
    } else {
        std::cout << "Output: false" << std::endl;
    }

    // Liberar memoria
    delete node1;
    delete node2;
    delete node3;
    delete node4;

    return 0;
}
