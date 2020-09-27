module MultiThreadedLazy

open ILazy

type MultiThreadedLazy<'a> (supplier : unit -> 'a) =
    let mutable result = None
    let locker = new obj()
    [<VolatileField>]
    let mutable hasValue = false

    interface ILazy<'a> with 
        member _.Get() =
            match hasValue with
            | true -> result.Value
            | _ -> (fun () ->
                       match hasValue with
                       | true -> result.Value
                       | _ -> result <- Some(supplier())
                              hasValue <- true
                              result.Value) |> lock locker