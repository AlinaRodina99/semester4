module Tests

open NUnit.Framework
open FsUnit
open WebDownloading

[<Test>]
let ``simple test to check that function downloads links`` () =
    let result = getAllLinks "https://github.com"
    result.Length |> should equal 92000
