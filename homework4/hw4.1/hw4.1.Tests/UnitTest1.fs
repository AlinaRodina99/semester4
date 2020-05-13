module hw4._1.Tests

open NUnit.Framework
open FsUnit
open BracketBalance

[<Test>]
let Test1 () =
    bracketBalance "(avb)" |> should equal true

[<Test>]
let Test2 () =
    bracketBalance "{((}afc" |> should equal false
