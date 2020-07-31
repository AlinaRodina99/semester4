module phoneBook

/// Function to add new contact in phone book.
let addNewContact (list : (string * string) list) (name : string) (phone : string) = (name, phone) :: list

/// Function to find phone by name of the contact.
let findPhoneByName (list : (string * string) list) (name : string) =
    let rec findPhoneByNameRec currentList =
        match currentList with 
        | hd :: tl -> if fst hd = name then printfn "%A" (snd hd)
                      else findPhoneByNameRec tl
        | _ -> printfn "This person does not exist!"
    findPhoneByNameRec list

/// Function to find name by phone of the contact.
let findNameByPhone (list : (string * string) list) (phone : string) =
    let rec findNameByPhoneRec currentList =
        match currentList with
        | hd :: tl -> if snd hd = phone then printfn "%A" (fst hd)
                      else findNameByPhoneRec tl
        | _ -> printfn "This phone does not exist!"
    findNameByPhoneRec list

/// Function to print database of phone book.
let showDataBaseOfPhoneBook (list : (string * string) list) =
    let rec showDataBaseOfPhoneBookRec currentList =
        match currentList with 
        | hd :: tl -> printfn "Name: %A Phone: %A" (fst hd) (snd hd) 
                      showDataBaseOfPhoneBookRec tl
        | _ -> printfn "Thats all"
    showDataBaseOfPhoneBookRec list





    