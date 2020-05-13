module hw4._1.Tests

open NUnit.Framework
open FsUnit
open BracketBalance

let testValues = 
    [
       "abc", true
       "(avb)", true
       "(2+3)", true
       "{((}afc", false
       "{{{}}", false
       "[{(2 + 3 + 4}])", true
       "(", false
       "[]", true
       "[[[((]]avbn]))", true
    ] |> List.map (fun (str, checkResult) -> TestCaseData(str, checkResult))

[<TestCaseSource("testValues")>]
[<Test>]
let ``check bracket balance on different inputs`` str checkResult =
    bracketBalance str |> should equal checkResult

