module Queue

open System

//Type that implements queue.
type Queue<'T> () =
    
    let mutable listOfElements = []

    //method to check size of queue.
    member _.Size () = listOfElements.Length

    //method to check whether queue is empty.
    member _.IsEmpty () = listOfElements.IsEmpty

    //method to enqueue element.
    member _.Enqueue element =
        let reversed = List.rev listOfElements
        listOfElements <- List.rev (element :: reversed)

    //method to dequeue element.
    member _.Dequeue =
        match listOfElements.Length with 
        | 0 -> raise (ArgumentException("Queue is empty!"))
        | _ -> let head = listOfElements.Head
               listOfElements <- listOfElements.Tail
               head
       
