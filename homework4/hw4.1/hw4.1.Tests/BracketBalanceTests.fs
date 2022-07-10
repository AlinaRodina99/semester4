module hw4._1.Tests

open NUnit.Framework
open FsUnit
open BracketBalance

let testValues = 
    [
       "()", true
       "(())", true
       "(()())", true
       "()[()]{()()[]}", true
       "", true
       "[(]{})", false
       "([)]", false
       "{()}[(])", false
       "(]", false
       "{{}}", true
       "abc", false
       "(((", false
    ] |> List.map (fun (str, checkResult) -> TestCaseData(str, checkResult))

[<TestCaseSource("testValues")>]
[<Test>]
let ``check bracket balance on different inputs`` str checkResult =
    bracketBalance str |> should equal checkResult

