open System

// Usando un algoritmo greedy - Tiempo: O(nlogn)
type Solution() =
    member this.EraseOverlapIntervals(intervals: int[][]) =
        Array.Sort(intervals, fun a b -> compare a.[1] b.[1])

        let mutable ans = 0
        let mutable endVar = Int32.MinValue

        for i in intervals do
            if i.[0] >= endVar then
                endVar <- i.[1]
            else
                ans <- ans + 1

        ans

// Ejemplo de uso
let intervals = [|
    [|1; 2|]
    [|2; 3|]
    [|3; 4|]
    [|1; 3|]
|]

printf "Input: intervals = ["
for i in intervals do
    printf "[%d,%d]" i.[0] i.[1]
    if i <> intervals.[intervals.Length - 1] then
        printf ","
printfn "]"

let sol = Solution()
let ans = sol.EraseOverlapIntervals(intervals)

printfn "Output: %d" ans

