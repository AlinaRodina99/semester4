module Lazy

open ILazy

/// Type that represents single-threaded lazy.
type Lazy<'a> (supplier : unit -> 'a) =
    let mutable result = None

    interface ILazy<'a> with
        member _.Get() =
           match result with
           | Some(value) -> value
           | _ -> result <- Some(supplier())
                  result.Value