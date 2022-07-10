module MapCount

///<summary> Function to count even numbers in list using map function.</summary>
let mapCount list = list |> List.map (fun x -> 1 - abs(x) % 2) |> List.fold (+) 0