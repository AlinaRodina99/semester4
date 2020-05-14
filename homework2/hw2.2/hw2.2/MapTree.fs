module MapTree

///<summary> Representation of the binary tree as discrimanted union.</summary>
type Tree<'a> =
    | Node of 'a * Tree<'a> * Tree<'a>
    | Tip

///<summary> Function that applies inner function to each element of the tree and makes new tree.</summary>
let rec mapTree f tree =
    match tree with 
    | Tip -> Tip
    | Node(value, left, right) -> Node(f value, mapTree f left, mapTree f right)