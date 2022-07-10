module Tests

open NUnit.Framework
open FsUnit
open WebDownloading

[<Test>]
let ``simple test to check that function downloads links`` () =
    let result = getAllLinks "https://fsharpforfunandprofit.com/"
    result.Length |> should equal 11

[<Test>]
let ``simple test with another link`` () =
    let result = getAllLinks "https://lyrsense.com"
    result.Length |> should equal 7

[<Test>]
let ``test with nonexistent site`` () =
    let result = getAllLinks "https://nonexistent_site"
    result.IsEmpty |> should be True

