module StringBuilder

open System

/// Workflow that does mathematical computations with concrete accuracy.
type StringBuilder () =
   
   member _.Bind((x : string), f) =
       match Int32.TryParse(x) with
       | false, _ -> None
       | true, y -> y |> f

   member _.Return(x) =
       Some(x)