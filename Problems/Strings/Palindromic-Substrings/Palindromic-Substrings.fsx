open System

// Usando el algoritmo de Manacher - Tiempo: O(n)
type Solution() =
    member this.CountSubstrings(s: string) =
        let mutable t = "^*"
        for c in s do
            t <- t + string c + "*"
        t <- t + "$"

        let n = s.Length
        let m = t.Length
        let r = Array.zeroCreate<int> m
        r.[1] <- 1
        let mutable j = 1
        let mutable ans = 0

        for i in 2..2 * n do
            let cur = 
                if j + r.[j] > i then
                    Math.Min(r.[2 * j - i], j + r.[j] - i)
                else
                    1

            let mutable curVar = cur
            while t.[i - curVar] = t.[i + curVar] do
                curVar <- curVar + 1

            if i + curVar > j + r.[j] then
                j <- i

            r.[i] <- curVar
            ans <- ans + r.[i] / 2

        ans

let s = "abc"
printfn "Input: s = %s" s

let sol = Solution()
let result = sol.CountSubstrings(s)
printfn "Output: %d" result


