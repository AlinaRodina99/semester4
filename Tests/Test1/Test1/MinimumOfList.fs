module MinimumOfList

let isSmaller a b = if a < b then a else b

let minimumOfList list =
    let minValue list = List.fold isSmaller (List.head list) list
    match list with 
    | [] -> failwith "List is empty!"
    | hd :: tl -> minValue list 