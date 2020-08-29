module Tests

open NUnit.Framework
open FsUnit
open RoundingBuilder


[<Test>]
let ``test`` () =
  let rounding = new RoundingBuilder(3)
  rounding {
     let! a = 2.0 / 12.0
     let! b = 3.5
     return a / b
  } |> should equal 0.048
