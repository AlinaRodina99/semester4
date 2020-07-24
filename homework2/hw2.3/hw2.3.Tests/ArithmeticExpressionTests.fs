module ArithmeticExpressionTests

open NUnit.Framework
open FsUnit
open System
open ArithmeticExpressionTree

let testValues =
    [
       Add(Number 5, Number 6), 11
       Division(Multiply(Number 4, Number 2), Number 4), 2
       Subtract(Multiply(Division(Number 16, Number 2), Number 10), Add(Multiply(Number 5, Number 5), Number 10)), 45
       Division(Division(Division(Number 20, Number 2), Number 2), Add(Number 4, Number 1)), 1
    ] |> List.map (fun (expression, result) -> TestCaseData(expression, result))

let failingTestValues =
    [
       Division(Number 4, Number 0)
       Multiply(Number 10, Division(Number 6, Number 0))
       Add(Multiply(Number 6, Number 7), Subtract(Division(Number 4, Number 0), Number 10))
    ] |> List.map (fun (expression) -> TestCaseData(expression))

[<TestCaseSource("testValues")>]
[<Test>]
let ``tests with different expressions`` (expression : Expression) (result : int) =
    evaluate expression |> should equal result

[<TestCaseSource("failingTestValues")>]
[<Test>]
let ``check that test failed`` (expression : Expression) =
     (fun () -> evaluate expression |> ignore) |> should throw typeof<DivideByZeroException>
