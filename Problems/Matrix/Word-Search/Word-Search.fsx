open System

let exist (board: char[][]) (word: string) =
    let m = Array.length board
    let n = Array.length board.[0]
    let dirs = [| [|0; 1|]; [|0; -1|]; [|1; 0|]; [|-1; 0|] |]

    let rec dfs x y i =
        if x < 0 || x >= m || y < 0 || y >= n || board.[x].[y] <> word.[i] then false
        elif i + 1 = word.Length then true
        else
            let c = board.[x].[y]
            board.[x].[y] <- '0' // Marcar como visitado

            for dir in dirs do
                let dx, dy = dir.[0], dir.[1]
                if dfs (x + dx) (y + dy) (i + 1) then return true

            board.[x].[y] <- c // Restaurar el valor original
            false

    for i = 0 to m - 1 do
        for j = 0 to n - 1 do
            if dfs i j 0 then return true

    false


let main argv =
    let board = [|
        [| 'A'; 'B'; 'C'; 'E' |]
        [| 'S'; 'F'; 'C'; 'S' |]
        [| 'A'; 'D'; 'E'; 'E' |]
    |]

    let word = "ABCCED"

    let result = exist board word
    if result then
        printfn "La palabra '%s' se encuentra en el tablero." word
    else
        printfn "La palabra '%s' no se encuentra en el tablero." word

    0 // Return an exit code

[<EntryPoint>]
let main argv =
    main argv


