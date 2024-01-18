#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <limits.h>

// Using in-order traversal - Time O(n)

struct TreeNode
{
    int val;
    struct TreeNode *left;
    struct TreeNode *right;
};

bool isValidBSTHelper(struct TreeNode *root, struct TreeNode **prev)
{
    if (!root)
        return true;

    if (!isValidBSTHelper(root->left, prev) || (*prev && (*prev)->val >= root->val))
        return false;

    *prev = root;

    return isValidBSTHelper(root->right, prev);
}

bool isValidBST(struct TreeNode *root)
{
    struct TreeNode *prev = NULL;
    return isValidBSTHelper(root, &prev);
}

void printTree(struct TreeNode *root)
{
    if (!root)
    {
        printf("[]\n");
        return;
    }

    struct TreeNode **queue = (struct TreeNode **)malloc(1000 * sizeof(struct TreeNode *));
    int front = -1, rear = -1;
    queue[++rear] = root;

    printf("[");

    while (front != rear)
    {
        struct TreeNode *node = queue[++front];

        if (node)
        {
            printf("%d, ", node->val);

            if (node->left)
                queue[++rear] = node->left;
            else
                queue[++rear] = NULL;

            if (node->right)
                queue[++rear] = node->right;
            else
                queue[++rear] = NULL;
        }
        else
        {
            printf("null");

            if (front != rear)
                printf(", ");
        }
    }

    printf("]\n");

    free(queue);
}

int main()
{
    struct TreeNode *root = (struct TreeNode *)malloc(sizeof(struct TreeNode));
    
    root->val = 5;
    root->left = (struct TreeNode *)malloc(sizeof(struct TreeNode));
    root->left->val = 1;
    root->left->left = NULL;
    root->left->right = NULL;

    root->right = (struct TreeNode *)malloc(sizeof(struct TreeNode));
    root->right->val = 4;
    root->right->left = (struct TreeNode *)malloc(sizeof(struct TreeNode));
    root->right->left->val = 3;
    root->right->left->left = NULL;
    root->right->left->right = NULL;

    root->right->right = (struct TreeNode *)malloc(sizeof(struct TreeNode));
    root->right->right->val = 6;
    root->right->right->left = NULL;
    root->right->right->right = NULL;

    bool ans = isValidBST(root);

    printf("Input: root = ");
    printTree(root);

    printf("Output: %s\n", ans ? "true" : "false");

    free(root->right->right);
    free(root->right->left);
    free(root->right);
    free(root->left);
    free(root);

    return 0;
}
