module BracketBalance

/// Function to check whether the bracket is opening.
let openingBracket bracket =
    match bracket with 
    | '(' | '{' | '[' -> true
    | _ -> false

/// Function to check whether the bracket is closing.
let closingBracket bracket =
    match bracket with
    | ')' | '}' | ']' -> true
    | _ -> false

/// Function to check whether two brackets are paired.
let checkPairOfBrackets firstBracket secondBracket =
    match (firstBracket, secondBracket) with
    | ('(', ')') | ('{', '}') | ('[', ']') -> true
    | _ -> false

/// Function to check bracket balance of input string.
let bracketBalance str =

    let rec bracketBalanceRec inputString stack =
        match (inputString, stack) with
        | ([], []) -> true
        | (hd :: tl, _) when (openingBracket hd) -> bracketBalanceRec tl (hd :: stack)
        | (hd1 :: tl1, hd2 :: tl2) -> if (openingBracket hd1) then bracketBalanceRec tl1 (hd1 :: stack)
                                      else if (closingBracket hd1) && (checkPairOfBrackets hd2 hd1) then bracketBalanceRec tl1 tl2
                                      else false
        | (_, _) -> false
    bracketBalanceRec (str |> Seq.toList) []   