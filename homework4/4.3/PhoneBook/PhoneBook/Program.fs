﻿// Learn more about F# at http://fsharp.org

open System
open phoneBookFunctions

[<EntryPoint>]
let main argv =
    printfn "Hello! This is a phone book. Here's how you can use it: "
    printfn "1 - exit"
    printfn "2 - add new contact (name and phone)"
    printfn "3 - find phone by name"
    printfn "4 - find name by phone"
    printfn "5 - show database of phone book"
    printfn "6 - save current database to file on the specified path"
    printfn "7 - read data from file on the specified path"
    let rec interactWithUser list =
        printfn "Input your command: "
        let input = Console.ReadLine()
        match input with
        | "1" ->  printfn "Goodbye!"
        | "2" ->  printfn "Input name of your contact:"
                  let name = Convert.ToString(Console.ReadLine())
                  printfn "Input phone of your contact:"
                  let phone = Convert.ToString(Console.ReadLine())
                  let list = addNewContact list name phone
                  interactWithUser list
        | "3" ->  printfn "Input name of your contact:"
                  let name = Convert.ToString(Console.ReadLine())
                  printfn "Phone of the contact: %A" (findPhoneByName list name)
                  interactWithUser list
        | "4" ->  printfn "Input phone of your contact:"
                  let phone = Convert.ToString(Console.ReadLine())
                  printfn "Name of the contact: %A" (findNameByPhone list phone)
                  interactWithUser list
        | "5" ->  List.iter (fun contact -> printfn "Name: %A Phone: %A" (fst contact) (snd contact)) list
                  interactWithUser list 
        | "6" ->  printfn "Input path to the file:"
                  let path = Convert.ToString(Console.ReadLine())
                  saveCurrentDatabaseToFile list path
                  interactWithUser list
        | "7" ->  printfn "Input path to the file:"
                  let path = Convert.ToString(Console.ReadLine())
                  let data = readCurrentDatabaseFromFile path
                  printf "%A" data
                  interactWithUser list
        | _ ->    printfn "Choose commands from 1 to 7"
                  interactWithUser list
    interactWithUser [] 

    0