module Computer

open System
open OperationSystem

///Class that describes computer view.
type Computer (operationSystem : OperationSystem, name : string, isInfected : bool) =
    
     /// Operation system of computer.
     member _.OperationSystem = operationSystem

     /// Property to know that computer was just infected.
     member val NewlyInfected = false with get, set
     
     /// Property to know that current computer is infected.
     member val IsInfected = isInfected with get, set
     
     /// Name of computer.
     member val Name = name with get 

     /// Method to know if computer can infect related computer.
     member this.CanInfect () = this.IsInfected && (this.NewlyInfected = false)

     /// Method to know if uninfected computer can be infected.
     member _.CanBeInfected (random : Random) =
         random.NextDouble() < operationSystem.GetProbabilityByOS

     /// Method to change status of infection of recently infected to an already infected.
     member this.ClearNewlyInfectedComputer () =
         if this.NewlyInfected then (this.NewlyInfected <- false)

     /// Methos of computer infection.
     member this.Infect () =
         this.IsInfected <- true
         this.NewlyInfected <- true
         