module DifferentCountsTests

open NUnit.Framework
open MapCount
open FoldCount
open FilterCount
open FsUnit
open FsCheck

[<Test>]
let ``map count in list several tests`` () =
    mapCount [1; 2; 3; 5; 7; 8] |> should equal 2
    mapCount [2; 4; 6; 8] |> should equal 4
    mapCount [1; 3; 5] |> should equal 0

[<Test>]
let ``map count with empty list`` () =
    mapCount [] |> should equal 0

[<Test>]
let ``filter count in list several tests`` () =
    filterCount [1; 2; 3; 5; 7; 8] |> should equal 2
    filterCount [2; 4; 6; 8] |> should equal 4
    filterCount [1; 3; 5] |> should equal 0

[<Test>]
let ``filter count with empty list`` () =
    filterCount [] |> should equal 0

[<Test>]
let ``fold count in list several tests`` () =
    foldCount [1; 2; 3; 5; 7; 8] |> should equal 2
    foldCount [2; 4; 6; 8] |> should equal 4
    foldCount [1; 3; 5] |> should equal 0

[<Test>]
let ``fold count with empty list`` () =
    foldCount [] |> should equal 0

[<Test>]
let ``filter count with negative numbers several tests`` () =
    filterCount [-1; 2; -3; 5; 7; 8] |> should equal 2
    filterCount [-2; 4; 6; -8] |> should equal 4
    filterCount [1; 3; -5] |> should equal 0

[<Test>]
let ``map count with negative numbers several tests`` () =
    mapCount [1; 2; 3; -5; 7; 8] |> should equal 2
    mapCount [2; -4; -6; -8] |> should equal 4
    mapCount [1; -3; -5] |> should equal 0
    
[<Test>]
let ``fold count with negative numbers several tests`` () =
    foldCount [1; -2; -3; -5; 7; 8] |> should equal 2
    foldCount [2; -4; -6; -8] |> should equal 4
    foldCount [1; -3; -5] |> should equal 0

[<Test>]
let ``check equivalence of map and fold count`` () =
    Check.QuickThrowOnFailure (fun list -> mapCount list = foldCount list)

[<Test>] 
let ``check equivalence of map and filtercount`` () =
    Check.QuickThrowOnFailure (fun list -> mapCount list = filterCount list)