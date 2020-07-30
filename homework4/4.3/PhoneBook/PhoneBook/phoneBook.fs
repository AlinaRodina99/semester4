module phoneBook

open System.IO

let addNewContact (list : (string * string) list) (name : string) (phone : string) = (name, phone) :: list

let findPhoneByName (list : (string * string) list) (name : string) =
    let rec findPhoneByNameRec currentList =
        match currentList with 
        | hd :: tl -> if fst hd = name then printfn "%A" (snd hd)
                      else findPhoneByNameRec tl
        | _ -> printfn "This person does not exist!"
    findPhoneByNameRec list

let findNameByPhone (list : (string * string) list) (phone : string) =
    let rec findNameByPhoneRec currentList =
        match currentList with
        | hd :: tl -> if snd hd = phone then printfn "%A" (fst hd)
                      else findNameByPhoneRec tl
        | _ -> printfn "This phone does not exist!"
    findNameByPhoneRec list

let showDataBaseOfPhoneBook (list : (string * string) list) =
    let rec showDataBaseOfPhoneBookRec currentList =
        match currentList with 
        | hd :: tl -> printfn "%A" hd
                      showDataBaseOfPhoneBookRec tl
        | _ -> printfn "Thats all"
    showDataBaseOfPhoneBookRec list





    