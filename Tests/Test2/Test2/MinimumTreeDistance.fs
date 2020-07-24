module MinimumTreeDistance

///Representation of tree.
type Tree<'a> =
    | Tip of 'a
    | Tree of 'a * Tree<'a> * Tree<'a>

///Function to find minimum distance from root to tips in tree. 
let minimumTreeDistance tree =
    let rec recMinimumTreeDistance t =
        match t with 
        | Tip _ -> 1
        | Tree(_, l, r) -> if recMinimumTreeDistance l < recMinimumTreeDistance r
                           then recMinimumTreeDistance l + 1
                           else recMinimumTreeDistance r + 1
    recMinimumTreeDistance tree - 1
