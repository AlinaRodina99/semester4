module Computer

open System

type Computer (operationSystem : string, name : string, isInfected : bool, listOfRelatedComputers : Computer list) =
     
     member _.GetProbabilityByOS = 
          match operationSystem with
          | "Windows" -> 0.5
          | "MacOS" -> 0.2
          | "Linux" -> 0.1
          | _ -> 1.0

     member _.OperationSystem = operationSystem

     member _.Infect (probability : float) = 
          let rnd = new Random()
          let randomValue = rnd.NextDouble()
          if randomValue <  probability then true else false

     member _.ListOfRelatedComputers = listOfRelatedComputers 

     member val IsInfected = isInfected with get, set

     member _.Name = name