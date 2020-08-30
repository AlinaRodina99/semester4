module TestsOfNet

open NUnit.Framework
open Computer
open Network
open FsUnit
open OperationSystem
open System

let firstComputers = 
  [
     new Computer(new OperationSystem("Windows"), "HP", true)
     new Computer(new OperationSystem("Windows"), "DELL", false)
     new Computer(new OperationSystem("Windows"), "ASUS", false)
     new Computer(new OperationSystem("Windows"), "Lenovo", false)
     new Computer(new OperationSystem("Windows"), "Prestigious", false)
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
    new Computer(new OperationSystem("Linux"), "HP", true)
    new Computer(new OperationSystem("Linux"), "DELL", false)
    new Computer(new OperationSystem("Linux"), "ASUS", false)
    new Computer(new OperationSystem("Linux"), "Lenovo", false)
    new Computer(new OperationSystem("Linux"), "Prestigious", false)
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
   network.Work(4, new Random())
   (network.Computers.Item 0).IsInfected |> should be True
   (network.Computers.Item 1).IsInfected |> should be True
   (network.Computers.Item 2).IsInfected |> should be True
   (network.Computers.Item 3).IsInfected |> should be True
   (network.Computers.Item 4).IsInfected |> should be True

[<Test>]
let ``check that with a probability of infection 0 no one is infected`` () =
   let network = new Network(secondComputers, secondMatrix)
   network.Work(100, new Random())
   (network.Computers.Item 0).IsInfected |> should be True
   (network.Computers.Item 1).IsInfected |> should be False
   (network.Computers.Item 2).IsInfected |> should be False
   (network.Computers.Item 3).IsInfected |> should be False
   (network.Computers.Item 4).IsInfected |> should be False
