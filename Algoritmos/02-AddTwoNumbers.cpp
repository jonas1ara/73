#include <iostream>

struct ListNode {
    int val;
    ListNode* next;
    ListNode() : val(0), next(nullptr) {}
    ListNode(int x) : val(x), next(nullptr) {}
    ListNode(int x, ListNode* next) : val(x), next(next) {}
};

ListNode* addTwoNumbers(ListNode* l1, ListNode* l2) {
    int carry = 0;
    ListNode dummy, *current = &dummy;
    while (l1 || l2 || carry) {
        
        //Add the values of the two nodes and the carry
        if (l1) {
            carry += l1->val; // 2 , 0 + 4 = 4, 0 + 3 = 3
            l1 = l1->next; // 4 , 3, NULL
        }
        if (l2) {
            carry += l2->val; // 2 + 5 = 7, 4 + 6 = 10, 3 + 4 = 7
            l2 = l2->next; // 6, 4, NULL
        }
        //Insert a new node with the value of carry % 10
        current->next = new ListNode(carry % 10); // 7 % 10 = 7, 10 % 10 = 0, 7 % 10 = 7

        // new list = 7 -> 0 -> 7 -> NULL


        //Move current to the next node and update carry
        current = current->next; // 7, 0, 7
        carry /= 10; // 7 / 10 = 0, 0 / 10 = 0
    }

    //Return the next node of the dummy node, which is the head of the new list
    return dummy.next;
}

void printList(ListNode* n)
{
    while (n != NULL)
    {
        std::cout << "[" << n->val << "] -> ";
        n = n->next;
    }

    std::cout << "NULL";
}

int main()
{
    //Build the first linked list
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

    //Build the second linked list
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

    //Add the two linked lists
    ListNode* l7 = addTwoNumbers(l1, l4);

    std::cout << "Output: ";
    printList(l7);
    std::cout << "\n";

    //std::cin.get();

}
