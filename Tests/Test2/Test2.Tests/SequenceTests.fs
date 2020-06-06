module SequenceTests

open NUnit.Framework
open FsUnit
open InfiniteSequence

[<TestCase(0, 1)>]
[<TestCase(1, 2)>]
[<TestCase(2, 2)>]
[<TestCase(3, 3)>]
[<TestCase(4, 3)>]
[<TestCase(5, 3)>]
[<TestCase(6, 4)>]
[<TestCase(7, 4)>]
[<TestCase(8, 4)>]
[<TestCase(99, 4)>]
[<Test>]
let testsToCheckNumbersInInfiniteSequenceOfPrimes index x =
    makeSequence |> Seq.item index |> should equal x