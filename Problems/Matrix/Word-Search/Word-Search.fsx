open System

type Solution() =
    member this.Exist(board: char[][], word: string) =
        let m = Array.length board
        let n = Array.length board.[0]
        let dirs = [| [| 0; 1 |]; [| 0; -1 |]; [| 1; 0 |]; [| -1; 0 |] |]

        let found = ref false // Variable mutable para indicar si se encontró la palabra

        let rec dfs x y i =
            if x < 0 || x >= m || y < 0 || y >= n || board.[x].[y] <> word.[i] then false
            else if i + 1 = word.Length then
                found := true
                true
            else
                let c = board.[x].[y]
                board.[x].[y] <- '0' // Mark as visited

                for dir in dirs do
                    let dx, dy = dir.[0], dir.[1]
                    if not !found && dfs (x + dx) (y + dy) (i + 1) then ()

                board.[x].[y] <- c // Restore original value
                false

        for i = 0 to m - 1 do
            for j = 0 to n - 1 do
                if not !found && dfs i j 0 then ()

        !found

let board = 
    [| 
        [| 'A'; 'B'; 'C'; 'E' |];
        [| 'S'; 'F'; 'C'; 'S' |];
        [| 'A'; 'D'; 'E'; 'E' |]
    |]

let word = "ABCCED"

printfn "Input: board = "
board |> Array.iter (fun row -> printfn "%A" row)
printfn "\nInput: word = %s\n" word

let sol = Solution()
let result = sol.Exist(board, word)

if result then
    printfn "Output: true"
else
    printfn "Output: false"

