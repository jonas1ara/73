#include <stdio.h>
#include <stdlib.h>

// Using two pointers - Time: O(n)

struct ListNode {
    int val;
    struct ListNode *next;
};

struct ListNode *removeNthFromEnd(struct ListNode *head, int n)
{
    struct ListNode *p = head;
    struct ListNode *q = head;
    struct ListNode *prev = NULL;

    while (n > 0)
    {
        q = q->next;
        n--;
    }

    if (q == NULL)
    {
        struct ListNode *newHead = head->next;
        free(head);
        return newHead;
    }

    while (q != NULL)
    {
        prev = p;
        p = p->next;
        q = q->next;
    }

    prev->next = p->next;
    free(p);

    return head;
}

struct ListNode *createList(int values[], int n)
{
    struct ListNode *head = NULL;
    struct ListNode *tail = NULL;

    for (int i = 0; i < n; i++)
    {
        struct ListNode *newNode = (struct ListNode *)malloc(sizeof(struct ListNode));
        newNode->val = values[i];
        newNode->next = NULL;

        if (tail == NULL)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail->next = newNode;
            tail = newNode;
        }
    }

    return head;
}

void printList(struct ListNode *head)
{
    struct ListNode *current = head;

    printf("[");
    while (current != NULL)
    {
        printf("%d", current->val);
        current = current->next;
        if (current != NULL)
        {
            printf(", ");
        }
    }
    printf("]");
}

int main()
{
    int values[] = {1, 2, 3, 4, 5};
    int n = 2;

    struct ListNode *head = createList(values, sizeof(values) / sizeof(values[0]));

    printf("Input: head = ");
    printList(head);
    printf(", n = 2\n");

    head = removeNthFromEnd(head, n);

    printf("Output: ");
    printList(head);
    printf("\n");

    struct ListNode *current = head;
    while (current != NULL)
    {
        struct ListNode *next = current->next;
        free(current);
        current = next;
    }

    return 0;
}
