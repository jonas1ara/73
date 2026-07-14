open System

type ListNode(v: int) =
    member val Val = v with get, set
    member val Next : ListNode option = None with get, set

type Solution() =
    member this.ReverseList(head: ListNode option) =
        let rec reverse (node: ListNode) =
            match node.Next with
            | None -> (node, node)
            | Some next ->
                let (h, t) = reverse next
                t.Next <- Some node
                node.Next <- None
                (h, node)

        match head with
        | None -> None
        | Some h -> reverse h |> fst |> Some

let buildList (values: int list) =
    let nodes = values |> List.map ListNode
    for i in 0 .. nodes.Length - 2 do
        nodes.[i].Next <- Some nodes.[i + 1]
    if nodes.IsEmpty then None else Some nodes.[0]

let rec printList (node: ListNode option) =
    match node with
    | None -> ()
    | Some n ->
        printf "%d" n.Val
        if n.Next.IsSome then printf ", "
        printList n.Next

let list = buildList [1; 2; 3; 4; 5]

printf "Input: head = ["
printList list
printfn "]"

let sol = Solution()
let reversed = sol.ReverseList(list)

printf "Output: ["
printList reversed
printfn "]"
