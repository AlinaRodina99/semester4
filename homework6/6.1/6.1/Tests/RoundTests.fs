module Tests

open NUnit.Framework
open FsUnit
open RoundingBuilder


[<Test>]
let ``test 1`` () =
  let rounding = new RoundingBuilder(3)
  rounding {
     let! a = 2.0 / 12.0
     let! b = 3.5
     return a / b
  } |> should (equalWithin 0.0001) 0.048

[<Test>]
let ``test 2`` () =
  let rounding = new RoundingBuilder(4)
  rounding {
     let! a = 3.0 / 5.0
     let! b = 3.45 * 6.8
     return a / b
  } |> should (equalWithin 0.00001) 0.0256

[<Test>]
let ``test 3`` () =
  let rounding = new RoundingBuilder(2)
  rounding {
     let! a = -5.0 / 4.0
     let! b = 6.0
     return a * b
  } |> should equal -7.50