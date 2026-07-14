open System
open System.Collections.Generic

[<AllowNullLiteral>]
type TreeNode(v: int, left: TreeNode, right: TreeNode) =
    new(v: int) = TreeNode(v, null, null)
    member val Val = v with get, set
    member val Left = left with get, set
    member val Right = right with get, set

type Solution() =
    let rec isSameTree (root: TreeNode) (subRoot: TreeNode) =
        (isNull root && isNull subRoot)
        || (not (isNull root) && not (isNull subRoot) && root.Val = subRoot.Val
            && isSameTree root.Left subRoot.Left
            && isSameTree root.Right subRoot.Right)

    member this.IsSubtree(root: TreeNode, subRoot: TreeNode) =
        let rec check (node: TreeNode) =
            isSameTree node subRoot
            || (not (isNull node) && (check node.Left || check node.Right))
        check root

let printTree (root: TreeNode) =
    if isNull root then
        printf "null"
    else
        let values = ResizeArray<string>()
        let queue = Queue<TreeNode>()
        queue.Enqueue root

        while queue.Count > 0 do
            let current = queue.Dequeue()
            if not (isNull current) then
                values.Add(string current.Val)
                queue.Enqueue current.Left
                queue.Enqueue current.Right
            else
                values.Add "null"

        printf "[%s]" (String.Join(", ", values))

let root = TreeNode(3, TreeNode(4, TreeNode(1), TreeNode(2)), TreeNode(5))
let subRoot = TreeNode(4, TreeNode(1), TreeNode(2))

printf "root = "
printTree root
printf ", subRoot = "
printTree subRoot
printfn ""

let sol = Solution()
let result = sol.IsSubtree(root, subRoot)

printfn "Output: %s" (if result then "true" else "false")
