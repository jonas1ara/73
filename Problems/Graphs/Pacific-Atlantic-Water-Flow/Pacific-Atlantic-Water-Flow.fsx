open System

// Using depth-first search - Time: O(mn)

type Solution() =
    let dirs = [| (0, 1); (0, -1); (1, 0); (-1, 0) |]

    let rec dfs (heights: int[][]) (visited: bool[][]) x y m n =
        visited.[x].[y] <- true
        for (dx, dy) in dirs do
            let a, b = x + dx, y + dy
            if a >= 0 && a < m && b >= 0 && b < n && not visited.[a].[b] && heights.[a].[b] >= heights.[x].[y] then
                dfs heights visited a b m n

    member this.PacificAtlantic(heights: int[][]) =
        if isNull heights || heights.Length = 0 || heights.[0].Length = 0 then
            []
        else
            let m = heights.Length
            let n = heights.[0].Length

            let pacific = Array.init m (fun _ -> Array.create n false)
            let atlantic = Array.init m (fun _ -> Array.create n false)

            for i in 0 .. m - 1 do
                dfs heights pacific i 0 m n
                dfs heights atlantic i (n - 1) m n

            for j in 0 .. n - 1 do
                dfs heights pacific 0 j m n
                dfs heights atlantic (m - 1) j m n

            [ for i in 0 .. m - 1 do
                for j in 0 .. n - 1 do
                    if pacific.[i].[j] && atlantic.[i].[j] then
                        yield [ i; j ] ]

let heights =
    [|
        [| 1; 2; 2; 3; 5 |]
        [| 3; 2; 3; 4; 4 |]
        [| 2; 4; 5; 3; 1 |]
        [| 6; 7; 1; 4; 5 |]
        [| 5; 1; 1; 2; 4 |]
    |]

printf "Input: ["
heights
|> Array.iteri (fun i row ->
    printf "[%s]" (String.Join(", ", row))
    if i < heights.Length - 1 then printf ", ")
printfn "]"

let sol = Solution()
let result = sol.PacificAtlantic(heights)

printf "Output: ["
result
|> List.iteri (fun i point ->
    printf "[%d, %d]" point.[0] point.[1]
    if i < result.Length - 1 then printf ", ")
printfn "]"
