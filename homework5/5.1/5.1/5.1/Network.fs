module Network

open Computer

type Network (computers : Computer list, matrix : bool [,]) =

     let stepOfInfection = 
        List.iter (fun (x : Computer) -> 
        if x.IsInfected then (List.iter (fun (y : Computer) -> 
           if (x.Infect(y.GetProbabilityByOS)) then (y.IsInfected <- true)
           else (y.IsInfected <- true))) x.ListOfRelatedComputers
        else ())

     let fillListsOfRelatedComputers =
        let lengthOfComputerList = List.length computers
        for i in 0 .. (lengthOfComputerList - 1) do
           for j in 0 .. (lengthOfComputerList - 1) do
              if matrix.[i, j] = true then ((computers.Item i).ListOfRelatedComputers) <- (computers.Item j) :: ((computers.Item i).ListOfRelatedComputers)
              else ()

     let printStateOfNetwork =
        for computer in computers do
           printf "Name of computer: %A, operation system: %A, state of infection: " computer.Name computer.OperationSystem 
           if computer.IsInfected then printfn "infected" else printfn "uninfected" 

     member _.Work (amountOfSteps : int) = 
         fillListsOfRelatedComputers
         stepOfInfection

     member _.PrintStateOfNetwork = printStateOfNetwork

     member _.Computers = computers

     
     
