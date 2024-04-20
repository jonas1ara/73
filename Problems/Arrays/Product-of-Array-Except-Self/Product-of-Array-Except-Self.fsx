open System

type Solution() =
    member this.ProductExceptSelf(nums : int[]) =
        let result = Array.zeroCreate<int>(nums.Length)
        result.[0] <- 1

        for i = 1 to nums.Length - 1 do
            result.[i] <- result.[i - 1] * nums.[i - 1]

        let mutable rightSide = 1
        for i = nums.Length - 1 downto 0 do
            result.[i] <- result.[i] * rightSide
            rightSide <- rightSide * nums.[i]

        result

let nums = [| 1; 2; 3; 4 |]

// Print input
printfn "Input: nums = [%s]" (String.Join(", ", Array.map string nums))

let sol = Solution()
let result = sol.ProductExceptSelf(nums)

// Print output
printfn "Output: [%s]" (String.Join(", ", Array.map string result))
