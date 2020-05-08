module FilterCount

///<summary> Function to count even numbers in list using filter function.</summary>
let filterCount list = list |> List.filter (fun x -> abs(x) % 2 = 0) |> List.length