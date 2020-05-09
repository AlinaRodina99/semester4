module InfinitePrimesTests

open NUnit.Framework
open FsUnit
open InfinitePrimes

[<TestCase(0, 2)>]
[<TestCase(1, 3)>]
[<TestCase(2, 5)>]
[<TestCase(3, 7)>]
[<TestCase(4, 11)>]
[<TestCase(5, 13)>]
[<TestCase(6, 17)>]
[<TestCase(99, 541)>]
[<Test>]
let testsToCheckNumbersInInfiniteSequenceOfPrimes index x =
    Seq.item(index) infinitePrimes |> should equal x
