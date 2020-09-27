module Lazy

open ILazy

/// Type that represents single-threaded lazy.
type Lazy<'a> (supplier : unit -> 'a) =
    let mutable result = None
    let mutable hasValue = false

    interface ILazy<'a> with
        member _.Get() =
           match hasValue with
           | true -> result.Value
           | _ -> result <- Some(supplier())
                  hasValue <- true
                  result.Value