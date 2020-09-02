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
let ``tests to check whether dequeue method is working`` () =
    queue.Enqueue 2 
    queue.Enqueue 3 
    queue.Dequeue |> should equal 2
    queue.Dequeue |> should equal 3
    queue.IsEmpty () |> should equal true
