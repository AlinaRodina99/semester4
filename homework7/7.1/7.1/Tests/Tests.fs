module LazyTests

open NUnit.Framework
open FsUnit
open LazyFactory
open System.Threading

[<Test>]
let ``simple test to check that single lazy works`` () =
    let singleLazy = LazyFactory.CreateSingleLazy(fun () -> 34)
    singleLazy.Get() |> should equal 34

[<Test>]
let ``test to check that single lazy returns none with none supplier`` () =
    let singleLazy = LazyFactory.CreateSingleLazy(fun () -> None)
    singleLazy.Get() |> should equal None

[<Test>]
let ``test to check that single lazy was calculated once`` () =
    let mutable current = 6
    let singleLazy = LazyFactory.CreateSingleLazy(fun () -> Interlocked.Increment(ref current))
    let firstResult = singleLazy.Get()
    let secondResult = singleLazy.Get()
    firstResult |> should equal secondResult

[<Test>]
let ``simple test to check that multithreaded lazy works`` () =
    let multiLazy = LazyFactory.CreateMultiThreadedLazy(fun () -> 50)
    multiLazy.Get() |> should equal 50

[<Test>]
let ``test to check that multithreaded lazy returns none with none supplier`` () =
    let multiLazy = LazyFactory.CreateMultiThreadedLazy(fun () -> None)
    multiLazy.Get() |> should equal None

[<Test>]
let ``test to check that multithreaded lazy calculated once`` () =
    let mutable current = 8
    let multiLazy = LazyFactory.CreateMultiThreadedLazy(fun () -> Interlocked.Increment(ref current))
    let firstResult = multiLazy.Get()
    for i in 1 .. 100 do
        ThreadPool.QueueUserWorkItem(fun object -> firstResult = multiLazy.Get() |> should be True) |> ignore

[<Test>]
let ``simple test to check that lock-free lazy works`` () =
    let lockFreeLazy = LazyFactory.CreateLockFreeLazy(fun () -> 8 * 2)
    lockFreeLazy.Get() |> should equal 16

[<Test>]
let ``test to check that lock-free lazy returns none with none supplier`` () =
    let lockFreeLazy = LazyFactory.CreateLockFreeLazy(fun () -> None)
    lockFreeLazy.Get() |> should equal None

[<Test>]
let ``test to check that lock-free lazy calculated once`` () =
    let mutable current = 7
    let lockFreeLazy = LazyFactory.CreateLockFreeLazy(fun () -> Interlocked.Increment(ref current))
    let firstResult = lockFreeLazy.Get()
    for i in 1 .. 10000 do
        ThreadPool.QueueUserWorkItem(fun object -> firstResult = lockFreeLazy.Get() |> should be True) |> ignore
    
