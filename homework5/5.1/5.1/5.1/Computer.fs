module Computer

open System

///Class that describes computer view.
type Computer (operationSystem : string, name : string, isInfected : bool) =
    
     /// Current state of infection.
     let mutable isInfected = isInfected

     /// Possiblity of infection depending on operation system.
     member _.GetProbabilityByOS = 
          match operationSystem with
          | "Windows" -> 1.0
          | "MacOS" -> 0.2
          | "Linux" -> 0.0
          | _ -> 0.5

     member _.OperationSystem = operationSystem

     /// Method to infect computers that are connected to current.
     member _.Infect (probability : float) = 
          let rnd = new Random()
          let randomValue = rnd.NextDouble()
          if randomValue <  probability then true else false
    
     member _.IsInfected 
         with get () = isInfected
         and set (value) = isInfected <- value
     
     /// Name of computer.
     member val Name = name with get 