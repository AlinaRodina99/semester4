module SumEvenFibonacci

       
let sumEvevnFibonacci n =       
    
    let madeFibonacciList =
        let rec madeFibonacciListRec x acc list =
            match acc with 
            | _ when acc >= n -> list
            | _ -> madeFibonacciListRec acc (x + acc) (acc :: list)
        madeFibonacciListRec 1 1 []

    List.filter (fun x -> x % 2 = 0) madeFibonacciList |> List.sum