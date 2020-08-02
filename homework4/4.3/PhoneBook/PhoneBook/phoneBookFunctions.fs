module phoneBookFunctions

open System.IO

/// Function to add new contact in phone book.
let addNewContact (book : (string * string) list) (name : string) (phone : string) = (name, phone) :: book

/// Function to find phone by name of the contact.
let findPhoneByName (book : (string * string) list) (name : string) =
    let rec findPhoneByNameRec currentBook =
        match currentBook with 
        | hd :: tl -> if fst hd = name then Some(snd hd)
                      else findPhoneByNameRec tl
        | _ -> None
    findPhoneByNameRec book

/// Function to find name by phone of the contact.
let findNameByPhone (book : (string * string) list) (phone : string) =
    let rec findNameByPhoneRec currentBook =
        match currentBook with
        | hd :: tl -> if snd hd = phone then Some(fst hd)
                      else findNameByPhoneRec tl
        | _ -> None
    findNameByPhoneRec book

/// Function to save database to file on the specified path.
let saveCurrentDatabaseToFile (book : (string * string) list) (path : string) =
    let rec saveCurrentDatabaseToFileRec currentBook currentFile =
        match currentBook with
        | hd :: tl -> let record = "Name: " + (fst hd) + " " + "Phone: " + (snd hd) 
                      let newCurrentFile = record :: currentFile
                      saveCurrentDatabaseToFileRec tl newCurrentFile
        | _ -> File.WriteAllLines(path, currentFile)
    saveCurrentDatabaseToFileRec book []

/// Function to read database from file on the specified path.
let readCurrentDatabaseFromFile (path : string) = File.ReadAllText(path)





    