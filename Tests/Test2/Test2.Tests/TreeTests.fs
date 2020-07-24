module TreeTests

open NUnit.Framework
open FsUnit
open MinimumTreeDistance
open PriorityQueue

let testValues =
    [ 
       Tree(0, Tree(1, Tree(2, Tip 3, Tip 4), Tree(3, Tip 6, Tip 7)), Tree(4, Tip 8, Tip 10)), 2
       Tree(0, Tree(2, Tree(4, Tip 5, Tip 6), Tree(6, Tip 8, Tip 9)), Tree(8, Tip 8 , Tip 10)), 2
    ] |> List.map (fun (tree, result) -> TestCaseData(tree, result))

[<TestCaseSource("testValues")>]
[<Test>]
let ``find minimum tree distance on different trees`` tree result =
    minimumTreeDistance tree |> should equal result
