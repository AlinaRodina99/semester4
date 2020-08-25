module TestsOfNet

open NUnit.Framework
open Computer
open Network
open FsUnit

let firstComputers = 
  [
     new Computer("Windows", "HP", true)
     new Computer("Windows", "DELL", false)
     new Computer("Windows", "ASUS", false)
     new Computer("Windows", "Lenovo", false)
     new Computer("Windows", "Prestigious", false)
  ]

let firstMatrix = 
  array2D[
           [false; true; false; false; true]
           [true; false; true; true; false]
           [false; true; false; true; false]
           [false; true; true; false; true]
           [true; false; false; true; false]
         ]

let secondComputers =
  [
    new Computer("Linux", "HP", true)
    new Computer("Linux", "DELL", false)
    new Computer("Linux", "ASUS", false)
    new Computer("Linux", "Lenovo", false)
    new Computer("Linux", "Prestigious", false)
  ]

let secondMatrix =
  array2D[
           [false; true; true; true; false]
           [true; false; false; true; true]
           [true; false; false; true; false]
           [true; true; true; false; true]
           [false; true; false; true; false]
         ]

[<Test>]
let ``check that the 1.0 probability of infection for a virus works like a breadth-first search`` () =
   let network = new Network(firstComputers, firstMatrix)
   network.Work(4)
   (network.Computers.Item 0).IsInfected |> should be True
   (network.Computers.Item 1).IsInfected |> should be True
   (network.Computers.Item 2).IsInfected |> should be True
   (network.Computers.Item 3).IsInfected |> should be True
   (network.Computers.Item 4).IsInfected |> should be True

[<Test>]
let ``check that with a probability of infection 0 no one is infected`` () =
   let network = new Network(secondComputers, secondMatrix)
   network.Work(100)
   (network.Computers.Item 0).IsInfected |> should be True
   (network.Computers.Item 1).IsInfected |> should be False
   (network.Computers.Item 2).IsInfected |> should be False
   (network.Computers.Item 3).IsInfected |> should be False
   (network.Computers.Item 4).IsInfected |> should be False
