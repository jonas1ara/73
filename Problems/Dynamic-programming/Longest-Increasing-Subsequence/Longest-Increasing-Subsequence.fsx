open System

// Usando tabulación - Tiempo: O(n^2)
type Solution() =
    member this.LengthOfLIS(nums: int[]) =
        if nums.Length = 0 then 0
        else
            let n = nums.Length
            let dp = Array.create n 1

            for i in 1..n-1 do
                for j in 0..i-1 do
                    if nums.[j] < nums.[i] then
                        dp.[i] <- Math.Max(dp.[i], dp.[j] + 1)
            
            Array.max dp

// Ejemplo de uso
let nums = [| 31; -41; 59; 26; -53; 58; 97; -93; -23; 84 |]
printfn "Input: nums = [%s]" (String.Join(", ", nums))

let sol = Solution()
let result = sol.LengthOfLIS(nums)

printfn "Output: %d" result

