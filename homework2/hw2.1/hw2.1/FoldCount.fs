module FoldCount

///<summary> Function to count even numbers in list using fold function.</summary>
let foldCount list = List.fold (fun acc x -> acc + (1 - abs(x) % 2)) 0 list