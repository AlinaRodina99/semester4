module SumEvenNumbersTests

open NUnit.Framework
open SumEvenFibonacciNumbers
open FsUnit

[<Test>]
let ``check whether sum of even fibonacci numbers that are less or equal 100000 is right`` () =
    sumEvenFibonacciNumbers |> should equal 1089154
