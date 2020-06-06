module QueueTests

open NUnit.Framework
open FsUnit
open Queue
open System

let mutable queue = new Queue<int>()

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
    queue.Enqueue 2 |> ignore
    queue.Enqueue 3 |> ignore
    queue.Dequeue 2 |> ignore
    queue.FindElement 2 |> should equal false
    (fun () -> queue.Dequeue 2 |> ignore) |> should throw typeof<ArgumentException>

[<Test>]
let ``tests to check whether find element method is working`` () =
    (fun () -> queue.FindElement 3 |> ignore) |> should throw typeof<ArgumentException>
    queue.Enqueue 60 |> ignore
    queue.FindElement 60 |> should equal true
    queue.FindElement 12 |> should equal false
