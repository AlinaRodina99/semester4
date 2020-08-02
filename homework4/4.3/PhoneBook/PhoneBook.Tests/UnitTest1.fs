module PhoneBook.Tests

open NUnit.Framework
open phoneBookFunctions
open FsUnit

[<Test>]
let ``check that adding new contact is working`` () =
    let book = addNewContact [] "Bob" "5555" |> List.append (addNewContact [] "alla" "333") 
    book |> should contain ("Bob", "5555")
    book |> should contain ("alla", "333")

[<Test>]
let ``check that finding name by phone is working`` () =
    let book = addNewContact [] "Bob" "555-555" |> List.append (addNewContact [] "Angela" "444-444")
               |> List.append (addNewContact [] "Sam" "55-55-55")
    let name1 = findNameByPhone book "555-555" 
    name1 |> should equal (Some("Bob"))
    let name2 = findNameByPhone book "444-444"
    name2 |> should equal (Some("Angela"))
    let name3 = findNameByPhone book "55-55-55"
    name3 |> should equal (Some("Sam"))

[<Test>]
let ``chack that finding phone by name is working`` () =
    let book = addNewContact [] "Kate" "123456" |> List.append (addNewContact [] "Liza" "666-666")
    let phone1 = findPhoneByName book "Kate"
    phone1 |> should equal (Some("123456"))
    let phone2 = findPhoneByName book "Liza"
    phone2 |> should equal (Some("666-666"))



