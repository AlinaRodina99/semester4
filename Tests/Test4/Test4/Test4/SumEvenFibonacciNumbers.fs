module SumEvenFibonacciNumbers

//function to sum all even numbers <= 100000
let sumEvenFibonacciNumbers =
    
    let generateFinbonacciSeq =
        (1, 1)
        |> Seq.unfold (fun state ->
        if (snd state + fst state > 1000000) then
             None
        else
             Some(fst state + snd state, (snd state, fst state + snd state)))

    Seq.filter (fun x -> x % 2 = 0) generateFinbonacciSeq |> Seq.sum