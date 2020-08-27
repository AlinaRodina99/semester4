module RoundingBuilder

open System

type RoundingBuilder(accuracy : int) =
     member _.Bind(x, f) =
         Math.Round((x : float), accuracy) |> f
        
     member _.Return(x) =
         Math.Round((x : float), accuracy)