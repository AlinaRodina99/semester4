module Computer

open System
open OperationSystem

///Class that describes computer view.
type Computer (operationSystem : OperationSystem, name : string, isInfected : bool) =
    
     /// Variable to know if computer was infected.
     let mutable isInfected = isInfected

     /// Variable to know if computer was infected on current iteration.
     let mutable newlyInfected = false

     member _.OperationSystem = operationSystem
     
     /// Property to know that current computer is infected.
     member _.IsInfected 
         with get () = isInfected
         and set (value) = isInfected <- value
     
     /// Name of computer.
     member val Name = name with get 

     /// Method to know if computer can infect related computer.
     member _.CanInfect () = (isInfected) && (newlyInfected = false)

     /// Method to know if uninfected computer can be infected.
     member _.CanBeInfected (random : Random) =
         random.NextDouble() < operationSystem.GetProbabilityByOS

     /// Method to change status of infection of recently infected to an already infected.
     member _.ClearNewlyInfectedComputer () =
         if newlyInfected then (newlyInfected <- false)

     /// Methos of computer infection.
     member _.Infect () =
         isInfected <- true
         newlyInfected <- true
         