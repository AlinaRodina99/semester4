module OperationSystem

/// Class that represents operation system.
type OperationSystem (operationSystem : string) =
    
    /// Property to get probability of infection depending on type of operation system.
    member _.GetProbabilityByOS =
        match operationSystem with 
        | "Windows" -> 1.0
        | "MacOS" -> 0.2
        | "Linux" -> 0.0
        | _ -> 0.5