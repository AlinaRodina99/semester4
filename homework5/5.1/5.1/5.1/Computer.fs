module Computer

open System

///Class that describes computer view.
type Computer (operationSystem : string, name : string, isInfected : bool) =
    
     let random = new Random()

     member _.OperationSystem = operationSystem

     /// Method to infect computers that are connected to current.
     member _.Infect (probability) = 
          let randomValue = random.NextDouble()
          if randomValue < probability then true else false
     
     /// Property to know that current computer is infected.
     member val IsInfected = isInfected with get, set

     /// Property to know that current computer was just infected during one iteration.
     member val NewlyInfected = false with get, set
     
     /// Name of computer.
     member val Name = name with get 