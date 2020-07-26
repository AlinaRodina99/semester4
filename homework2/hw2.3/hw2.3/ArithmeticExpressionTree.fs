module ArithmeticExpressionTree

open System

///<summary> Representation of еhe parse tree of the arithmetic expression. </summary>
type Expression =
     | Number of int
     | Add of Expression * Expression
     | Multiply of Expression * Expression
     | Subtract of Expression * Expression
     | Division of Expression * Expression

///<summary> Function to calculate tree.</summary>
let rec evaluate expression =
    match expression with 
    | Number n -> n
    | Add (x, y) -> evaluate x + evaluate y
    | Multiply (x, y) -> evaluate x * evaluate y
    | Subtract (x, y) -> evaluate x - evaluate y
    | Division (x, y) -> if evaluate y = 0 then raise (DivideByZeroException())
                         else evaluate x / evaluate y

