module LockFreeLazy

open ILazy
open System.Threading
open System

/// Type that represents lock-free lazy. 
type LockFreeLazy<'a> (supplier : unit -> 'a) =
     let mutable result = None
     let mutable hasValue = false

     interface ILazy<'a> with
        member _.Get() =
            match hasValue with
            | true -> result.Value
            | _ -> let startVal = result
                   let desiredVal = Some(supplier())
                   Interlocked.CompareExchange(&result, desiredVal, startVal) |> ignore
                   hasValue <- true
                   result.Value