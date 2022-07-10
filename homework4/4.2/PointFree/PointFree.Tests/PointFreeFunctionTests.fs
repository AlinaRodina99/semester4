module PointFreeFunctionTests

open NUnit.Framework
open FsCheck
open PointFreeFunction

let test1 x l = func x l = func1 x l

let test2 x l = func x l = func2 x l

let test3 x l = func x l = func3 x l

[<Test>]
let first () =
    Check.QuickThrowOnFailure test1

[<Test>]
let second () =
    Check.QuickThrowOnFailure test2

[<Test>]
let third () =
    Check.QuickThrowOnFailure test3


