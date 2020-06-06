module Queue

open System

type Queue<'T> () =
    
    let mutable listOfElements = []

    member _.Size () = listOfElements.Length

    member _.IsEmpty () = listOfElements.IsEmpty

    member _.Enqueue element =
        let enqueue currentList =
            match currentList with
            | [] -> [element]
            | hd :: tl -> 
              let rec innerRecEnqueue innerIndex =
                  match currentList.Item(innerIndex) with 
                  | x when x = element -> raise (ArgumentException("This element already exists in queue!"))
                  | _ when innerIndex = currentList.Length - 1 -> (element :: (List.rev currentList))
                  | _ -> innerRecEnqueue (innerIndex + 1)
              innerRecEnqueue 0
        listOfElements  <- enqueue listOfElements

    member _.Dequeue element =
        let dequeue currentList =
            match currentList with 
            | [] -> raise (ArgumentException("Queue is empty!"))
            | hd :: tl ->
              let rec innerRecDequeue innerIndex =
                  match currentList.Item(innerIndex) with
                  | x when x = element -> List.mapi (fun index el -> (index <> innerIndex, el)) currentList |> List.filter fst |> List.map snd
                  | _ when innerIndex = currentList.Length - 1 -> raise (ArgumentException("Such element does not exist!"))
                  | _ -> innerRecDequeue (innerIndex + 1)
              innerRecDequeue 0
        listOfElements <- dequeue listOfElements

    member _.FindElement element =
        let findElement currentList =
            match currentList with 
            | [] -> raise (ArgumentException("Queue is empty!"))
            | hd :: tl ->
              let rec innerRecFindElement innerIndex =
                  match currentList.Item(innerIndex) with
                  | x when x = element -> true
                  | _ when innerIndex = currentList.Length - 1 -> false
                  | _ -> innerRecFindElement (innerIndex + 1)
              innerRecFindElement 0
        findElement listOfElements