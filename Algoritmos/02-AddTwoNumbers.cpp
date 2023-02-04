#include <iostream>

struct ListNode {
    int val;
    ListNode* next;
    ListNode() : val(0), next(nullptr) {}
    ListNode(int x) : val(x), next(nullptr) {}
    ListNode(int x, ListNode* next) : val(x), next(next) {}
};

void printList(ListNode* n)
{
    while (n != NULL)
    {
        std::cout << "[" << n->val << "] -> ";
        n = n->next;
    }

    std::cout << "NULL";
}

ListNode* addTwoNumbers(ListNode* a, ListNode* b) {
    int carry = 0;
    ListNode dummy, * tail = &dummy;
    while (a || b || carry) {
        if (a) {
            carry += a->val;
            a = a->next;
        }
        if (b) {
            carry += b->val;
            b = b->next;
        }
        tail->next = new ListNode(carry % 10);
        tail = tail->next;
        carry /= 10;
    }
    return dummy.next;
}

int main()
{
    //Construir primer lista enlazada
    ListNode* l1 = new ListNode();
    ListNode* l2 = new ListNode();
    ListNode* l3 = new ListNode();

    l1->val = 2;
    l1->next = l2;

    l2->val = 4;
    l2->next = l3;

    l3->val = 3;
    l3->next = NULL;

    std::cout << "Input: l1 =  " ;
    printList(l1);
    std::cout << ", ";

    //Construir segunda lista enlazada
    ListNode* l4 = new ListNode();
    ListNode* l5 = new ListNode();
    ListNode* l6 = new ListNode();

    l4->val = 5;
    l4->next = l5;
    l5->val = 6;
    l5->next = l6;
    l6->val = 4;
    l6->next = NULL;

    std::cout << "l2 =  " ;
    printList(l4);
    std::cout << "\n";

    
    ListNode* l7 = addTwoNumbers(l1, l4);

    std::cout << "Output: ";
    printList(l7);
    std::cout << "\n";

    //std::cin.get();

}