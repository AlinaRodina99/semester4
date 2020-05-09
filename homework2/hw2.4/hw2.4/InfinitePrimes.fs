module InfinitePrimes

open System

///<summary> Function to generate infinite sequence of prime numbers.</summary>
let infinitePrimes =
    
    ///<summary> Inner function to check whether number is prime.</summary>
    let isPrime n =
        match n with 
        | _ when n <= 3 -> true
        | _ -> let length = seq { for i in 2 .. (int)(Math.Sqrt((float)n)) do if (n % i = 0) then yield i } |> Seq.length
               if length = 0 then true else false

    Seq.initInfinite (fun x -> x + 2) |> Seq.filter isPrime