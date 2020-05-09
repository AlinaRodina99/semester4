module hw2._2.Tests

open NUnit.Framework
open FsUnit
open MapTree

[<Test>]
let ``Test1`` () =
    mapTree (fun x -> x * 2) (Node(0, Node(1, Node(2, Tip, Tip), Node(3, Tip, Tip)), Node(4, Tip, Tip))) |> should equal (Node(0, Node(2, Node(4, Tip, Tip), Node(6, Tip, Tip)), Node(8, Tip, Tip)))
