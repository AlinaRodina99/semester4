module PriorityQueueTests

open NUnit.Framework
open FsUnit
open PriorityQueue
open System

let mutable queue = new PriorityQueue<string>()

[<SetUp>]
let ``Init``() = queue <- new PriorityQueue<string>()

[<Test>]
let ``test isEmpty on empty queue`` () =
    queue.IsEmpty () |> should equal true

[<Test>]
let ``Enqueue some elements in ascending priority order`` () =
    queue.Enqueue 4 "Hello"
    queue.Enqueue 3 "GoodBye"
    queue.Enqueue 2 "Good morning"
    queue.Dequeue () |> should equal (2, "Good morning")
    queue.Dequeue () |> should equal (3, "GoodBye")
    queue.Dequeue () |> should equal (4, "Hello")

[<Test>]
let ``dequeue from empty queue must throw exception`` () =
    (fun () -> queue.Dequeue() |> ignore) |> should throw (typeof<InvalidOperationException>)