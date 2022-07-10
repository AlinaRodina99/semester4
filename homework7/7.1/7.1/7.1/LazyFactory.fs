module LazyFactory

open ILazy
open Lazy
open MultiThreadedLazy
open LockFreeLazy

/// Type that creates different types of lazy.
type LazyFactory =
     
     /// Create single-threaded lazy.
     static member CreateSingleLazy supplier =
         new Lazy<'a>(supplier) :> ILazy<'a>
     
     /// Create multithreadede lazy.
     static member CreateMultiThreadedLazy supplier =
         new MultiThreadedLazy<'a>(supplier) :> ILazy<'a>
     
     /// Create lock-free lazy.
     static member CreateLockFreeLazy supplier =
         new LockFreeLazy<'a>(supplier) :> ILazy<'a>