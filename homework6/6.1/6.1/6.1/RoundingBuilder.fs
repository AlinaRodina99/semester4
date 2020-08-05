module RoundingBuilder

open System

let divide x y (b : int) =
    match y with
    | 0.0 -> None
    | _ -> Some(Math.Round(Some(x/y).Value, b))

type RoundingBuilder(a : int) =
     member _.Bind(x, f) =
        match x with 
        | None -> None
        | Some a -> f a
        
     member _.Return(x) =
        Some(x)

let roundingBuilder = new RoundingBuilder(3)

let rounding 