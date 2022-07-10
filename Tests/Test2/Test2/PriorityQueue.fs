module PriorityQueue

open System

///Type represents priority queue: the lower the priority the closer to the top of the queue.
type PriorityQueue<'T>() =
     
     ///List for pairs of elements with its value and priority.
     let mutable pairList = []

     ///Check the size of queue.
     member _.Size () = List.length pairList

     ///Check whether queue is empty.
     member _.IsEmpty () = List.isEmpty pairList

     ///Puts an item in the queue.
     member _.Enqueue priority (value : 'T) =
          let rec recEnqueue currentList =
              match currentList with
              | [] -> [(priority, value)]
              | (headPriority, headValue) :: tail -> if headPriority > priority
                                                     then (priority, value) :: currentList
                                                     else recEnqueue currentList.Tail
          pairList  <- recEnqueue pairList

     ///Removes an item from the queue.
     member _.Dequeue () =
          match pairList.Length with
          | 0 -> raise (InvalidOperationException("Queue is empty!"))
          | _ -> let current = pairList.Head
                 pairList <- pairList.Tail
                 current

