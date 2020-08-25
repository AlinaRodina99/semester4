module Network

open Computer

/// Class that describes working of net.
type Network (computers : Computer list, matrix : bool [,]) =
     
     /// Varibale for lentgh of computer list that is used in infect function.
     let lentghOfComputerList = List.length computers

     /// Function to infect computers for one iteraion.
     let stepOfInfection () = 
        for i in 0 .. (lentghOfComputerList - 1) do
          for j in 0 .. (lentghOfComputerList - 1) do
             if matrix.[i, j] = true && (computers.Item i).IsInfected then
               if (not (computers.Item j).IsInfected) && (computers.Item j).Infect((computers.Item j).GetProbabilityByOS) then
                  (computers.Item j).IsInfected <- true
                  else ()
     
     /// Function to print current state of net.
     let printStateOfNetwork () =
        for computer in computers do
           printf "Name of computer: %A, operation system: %A, state of infection: " computer.Name computer.OperationSystem 
           if computer.IsInfected then printfn "infected" else printfn "uninfected" 
     
     /// Working of net, amountOfSteps - amount of iterations while net is working.
     member _.Work (amountOfSteps) =
         for i in 1 .. amountOfSteps do
             stepOfInfection()
             if i % 2 = 0 then printStateOfNetwork()
     
     /// Computers in net.
     member _.Computers = computers