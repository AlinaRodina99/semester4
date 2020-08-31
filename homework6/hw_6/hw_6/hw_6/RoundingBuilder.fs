module RoundingBuilder

open System

/// Workflow that does computations with numbers as strings.
type RoundingBuilder(accuracy : int) =
     member _.Bind(x, f) =
         Math.Round((x : float), accuracy) |> f
        
     member _.Return(x) =
         Math.Round((x : float), accuracy)