module MapCount

let mapCount list = list |> List.map (fun x -> 1 - abs(x) % 2) |> List.fold (+) 0