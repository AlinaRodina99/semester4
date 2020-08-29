module Network

open Computer
open System

/// Class that describes working of net.
type Network (computers : Computer list, matrix : bool [,]) =
     
     /// Varibale for lentgh of computer list that is used in infect function.
     let lengthOfComputerList = List.length computers

     /// Function to infect computers for one iteraion.
     let stepOfInfection (random : Random) = 
        for i in 0 .. (lengthOfComputerList - 1) do
          for j in 0 .. (lengthOfComputerList - 1) do
             List.iter (fun (x : Computer) -> if x.NewlyInfected then x.NewlyInfected <- false) computers
             if matrix.[i, j] && (computers.Item i).CanInfect then
               if (not (computers.Item j).IsInfected) && (computers.Item j).CanBeInfected(random) then
                  (computers.Item j).IsInfected <- true
                  (computers.Item j).NewlyInfected <- true
     
     /// Function to print current state of net.
     let printStateOfNetwork () =
        for computer in computers do
           printf "Name of computer: %A, operation system: %A, state of infection: " computer.Name computer.OperationSystem 
           if computer.IsInfected then printfn "infected" else printfn "uninfected" 
     
     /// Working of net, amountOfSteps - amount of iterations while net is working.
     member _.Work (amountOfSteps, random) =
         for i in 1 .. amountOfSteps do
             stepOfInfection(random)
             if i % 2 = 0 then printStateOfNetwork()
     
     /// Computers in net.
     member _.Computers = computers