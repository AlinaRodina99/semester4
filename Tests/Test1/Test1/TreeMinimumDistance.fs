module TreeMinimumDistance

type Tree<'a> =
    | Node of 'a * Tree<'a> * Tree<'a>
    | Tip

let treeMinimumDistance tree =
    let rec treeMinimumDistanceRec tree list =
        match tree with 
        | Tip -> list