open System

// Usando manipulación de bits - Tiempo: O(1)
type Solution() =
    member this.GetSum(a: int, b: int) =
        let mutable carry = 0
        let mutable ans = 0

        for i in 0..31 do
            let x = (a >>> i) &&& 1
            let y = (b >>> i) &&& 1

            if carry <> 0 then
                if x = y then
                    ans <- ans ||| (1 <<< i)
                    if x = 0 && y = 0 then carry <- 0
            else
                if x <> y then ans <- ans ||| (1 <<< i)
                if x = 1 && y = 1 then carry <- 1

        ans

// Ejemplo de uso
let a = 1
let b = 2
printfn "Input: a = %d, b = %d" a b

let sol = Solution()
let ans = sol.GetSum(a, b)

printfn "Output: %d" ans

