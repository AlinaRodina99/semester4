module Test1.Tests

open NUnit.Framework
open FsUnit
open SumEvenFibonacci

[<Test>]
let ``aa`` () =
    sumEvevnFibonacci 10 |> should equal 10

