module InfinitePrimes

///<summary> Function to generate infinite sequence of prime numbers.</summary>
let infinitePrimes =
    
    ///<summary> Inner function to check whether number is prime.</summary>
    let isPrime n =
        let rec isPrimeRecursive n i = 
            match n with 
            | _ when n <= 3 || i >= n -> true
            | _ when n % i = 0 -> false
            | _ -> isPrimeRecursive n (i + 1)
        isPrimeRecursive n 2

    Seq.initInfinite (fun x -> x + 2) |> Seq.filter isPrime