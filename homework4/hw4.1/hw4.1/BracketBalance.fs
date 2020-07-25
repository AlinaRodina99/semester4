module BracketBalance

// Function to check whether the bracket is opening.
let openingBracket bracket =
    match bracket with 
    | '(' ->  true
    | '{' ->  true
    | '[' ->  true
    | _ -> false

// Function to check whether the bracket is closing.
let closingBracket bracket =
    match bracket with
    | ')' -> true
    | '}' -> true
    | ']' -> true
    | _ -> false

//Function to check whether two brackets are paired.
let checkPairOfBrackets firstBracket secondBracket =
    match (firstBracket, secondBracket) with
    | ('(', ')') -> true
    | ('{', '}') -> true
    | ('[', ']') -> true
    | _ -> false

// Function to check bracket balance of input string.
let bracketBalance str =

    let rec checkBracketBalanceRec inputString stack =
        if List.length inputString = 0 && List.length stack = 0
           then true
        else if (openingBracket (List.head inputString))
           then checkBracketBalanceRec (List.tail inputString) (inputString.Head :: stack)
        else if (closingBracket (List.head inputString)) && (checkPairOfBrackets (List.head stack) (List.head inputString))
           then checkBracketBalanceRec (List.tail inputString) (List.tail stack)
        else 
           false 
    checkBracketBalanceRec (str |> Seq.toList) []   