/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     ListNode *next;
 *     ListNode() : val(0), next(nullptr) {}
 *     ListNode(int x) : val(x), next(nullptr) {}
 *     ListNode(int x, ListNode *next) : val(x), next(next) {}
 * };
 */

class Solution {
    array<ListNode*, 2> reverse(ListNode *head) {
        if (!head->next) return {head, head};
        auto [h, t] = reverse(head->next);
        t->next = head;
        head->next = NULL;
        return {h, head};
    }
public:
    ListNode* reverseList(ListNode* head) {
        if (!head) return NULL;
        return reverse(head)[0];
    }
};

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