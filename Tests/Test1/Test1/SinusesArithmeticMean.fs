module SinusesArithmeticMean

open System

let sinusesArithmeticMean list =
    let rec sinusesArithmeticMeanRec list newList =
        match list with 
        | [] -> (List.sum newList) / (float)(List.length newList) 
        | _ -> sinusesArithmeticMeanRec (List.tail list) (Math.Sin (List.head list) :: newList)
    sinusesArithmeticMeanRec list []
