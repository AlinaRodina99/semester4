module StringTests

open StringBuilder
open NUnit.Framework
open FsUnit

[<Test>]
let ``test from example`` () =
  let stringBuilder = new StringBuilder()
  stringBuilder {
      let! x = "1"
      let! y = "2"
      let z = x + y
      return z 
  } |> should equal (Some(3))

[<Test>]
let ``test that gives none for an answer`` () =
  let stringBuilder = new StringBuilder()
  stringBuilder {
      let! x = "1"
      let! y = "Ъ"
      let z = x + y
      return z
  } |> should equal None

[<Test>]
let ``simple test 1`` () =
  let stringBuilder = new StringBuilder()
  stringBuilder {
      let! x = "2"
      let! y = "3"
      let! z = "6"
      let g = x * y * z
      return g
  } |> should equal (Some(36))

[<Test>]
let ``simple test 2`` () =
  let stringBuilder = new StringBuilder()
  stringBuilder {
      let! x = "4"
      let! y = "2"
      let z = x / y
      return z
  } |> should equal (Some(2))