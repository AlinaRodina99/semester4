module Tests

open NUnit.Framework
open FsUnit
open RoundingBuilder

[<Test>]
let ``test from example`` () =
  let rounding = new RoundingBuilder(3)
  rounding {
     let! a = 2.0 / 12.0
     let! b = 3.5
     return a / b
  } |> should (equalWithin 0.0001) 0.048

[<Test>]
let ``simple test 1`` () =
  let rounding = new RoundingBuilder(4)
  rounding {
     let! a = 3.0 / 5.0
     let! b = 3.45 * 6.8
     return a / b
  } |> should (equalWithin 0.00001) 0.0256

[<Test>]
let ``simple test 2 with negative numbers`` () =
  let rounding = new RoundingBuilder(2)
  rounding {
     let! a = -5.0 / 4.0
     let! b = 6.0
     return a * b
  } |> should (equalWithin 0.001) -7.50

[<Test>]
let ``simple test 3`` () =
  let rounding = new RoundingBuilder(3)
  rounding {
     let! a = 6.0 * 8.67
     let! b = 7.0
     return a / b
  } |> should (equalWithin 0.0001) 7.431