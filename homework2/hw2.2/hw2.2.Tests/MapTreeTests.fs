module MapTreeTests

open NUnit.Framework
open FsUnit
open MapTree

let testIntValues =
    [
       (fun x -> x * 2), Node(0, Node(1, Node(2, Tip, Tip), Node(3, Tip, Tip)), Node(4, Tip, Tip)),
       Node(0, Node(2, Node(4, Tip, Tip), Node(6, Tip, Tip)), Node(8, Tip, Tip))

       (fun x -> x / 2), Node(0, Node(1, Node(2, Tip, Tip), Node(3, Tip, Tip)), Node(4, Tip, Tip)),
       Node(0, Node(0, Node(1, Tip, Tip), Node(1, Tip, Tip)), Node(2, Tip, Tip))

       (fun x -> x * 0), Tip, Tip
    ] |> List.map (fun (func, initialTree, newTree) -> TestCaseData(func, initialTree, newTree))

let testStringValues =
    [ 
       (fun (x : string) -> (x.Length)), Node("Math", Node("Algebra", Node("Geometry", Tip, Tip), Node("Topology", Tip, Tip)), Node("Programming", Tip, Tip)),
       Node(4, Node(7, Node(8, Tip, Tip), Node(8, Tip, Tip)), Node(11, Tip, Tip))

       (fun (x : string) -> x.LastIndexOf("!")), Node("Hello!", Node("Good morning", Tip, Tip), Node("Good evening!", Tip, Tip)), 
       Node(5, Node(-1, Tip, Tip), Node(12, Tip, Tip))
    ] |> List.map (fun (func, initialTree, newTree) -> TestCaseData(func, initialTree, newTree))

[<TestCaseSource("testIntValues")>]
[<Test>]
let ``tests with int values of elements of the tree`` (func : int -> int) (initialTree : Tree<int>) (newTree : Tree<int>) =
    mapTree func initialTree |> should equal newTree

[<TestCaseSource("testStringValues")>]
[<Test>]
let ``tests with string values of elements of the tree`` (func : string -> int) (initialTree : Tree<string>) (newTree : Tree<int>) =
    mapTree func initialTree |> should equal newTree