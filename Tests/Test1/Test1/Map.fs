module Map

open System

let superMap list =
    let innerMap list = List.map (fun x -> [Math.Sin x; Math.Cos x]) list
    match list with 
    | [] -> failwith "List is empty!"
    | hd :: tl -> innerMap list