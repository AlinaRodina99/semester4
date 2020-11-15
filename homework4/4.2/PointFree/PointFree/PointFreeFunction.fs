module PointFreeFunction

let func x l = List.map (fun y -> y * x) l

let func1 x l = List.map ((*) x) l

let func2 x = List.map ((*) x)

let func3 = (*) >> List.map