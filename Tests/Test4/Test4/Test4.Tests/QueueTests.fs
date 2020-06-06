module QueueTests

open NUnit.Framework
open FsUnit
open Queue
open System

let mutable queue = new Queue<int>()

let mutable stringQueue = new Queue<int>()

[<SetUp>]
let ``Init`` () = queue <- new Queue<int>()

[<Test>]
let ``test isEmpty on empty queue`` () =
    queue.IsEmpty () |> should equal true

[<Test>]
let ``tests to check whether enqueue method is working`` () =
     queue.Enqueue 5 |> ignore
     queue.Enqueue 20 |> ignore
     queue.Enqueue 30 |> ignore
     (fun () -> queue.Enqueue 5 |> ignore) |> should throw typeof<ArgumentException>
     (fun () -> queue.Enqueue 20 |> ignore) |> should throw typeof<ArgumentException>
     (fun () -> queue.Enqueue 30 |> ignore) |> should throw typeof<ArgumentException>

[<Test>]
let ``tests to check whether dequeue method is working`` () =
    queue.Enqueue 2 
    queue.Enqueue 3 
    queue.Dequeue |> should equal 2
    queue.Dequeue |> should equal 3
    (fun () -> queue.Dequeue |> ignore) |> should throw typeof<ArgumentException>
