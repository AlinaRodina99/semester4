module BracketBalance

///<summary> Function to check bracket balance of input string.</summary>
let bracketBalance (str : string) =
    
    let checkBracketBalance =
        let rec checkBracketBalanceRec firstBracketList secondBracketList iter =
            match (Seq.item (iter) str, iter) with
            | '(', _ when iter = (Seq.length str - 1) -> ("(" :: firstBracketList, secondBracketList)
            | ')', _ when iter = (Seq.length str - 1) -> (firstBracketList, ")" :: secondBracketList)
            | '{', _ when iter = (Seq.length str - 1) -> ("(" :: firstBracketList, secondBracketList)
            | '}', _ when iter = (Seq.length str - 1) -> (firstBracketList, ")" :: secondBracketList)
            | '[', _ when iter = (Seq.length str - 1) -> ("(" :: firstBracketList, secondBracketList)
            | ']', _ when iter = (Seq.length str - 1) -> (firstBracketList, ")" :: secondBracketList)
            | _, _ when iter = (Seq.length str - 1) -> (firstBracketList, secondBracketList)
            | '(', _ -> checkBracketBalanceRec ("(" :: firstBracketList) secondBracketList (iter + 1)
            | ')', _ -> checkBracketBalanceRec firstBracketList (")" :: secondBracketList) (iter + 1)
            | '{', _ -> checkBracketBalanceRec ("(" :: firstBracketList) secondBracketList (iter + 1)
            | '}', _ -> checkBracketBalanceRec firstBracketList (")" :: secondBracketList) (iter + 1)
            | '[', _ -> checkBracketBalanceRec ("(" :: firstBracketList) secondBracketList (iter + 1)
            | ']', _ -> checkBracketBalanceRec firstBracketList (")" :: secondBracketList) (iter + 1)
            | _, _ -> checkBracketBalanceRec firstBracketList secondBracketList (iter + 1)
        checkBracketBalanceRec [] [] 0
    
    match checkBracketBalance with 
    | (a, b) when a.Length = b.Length -> true
    | _ -> false