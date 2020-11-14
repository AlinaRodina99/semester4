module InterpreterTests

open NUnit.Framework
open FsUnit 
open LambdaInterpreter
open LambdaTerm

[<Test>]
let ``Chech with one variable expression`` () =
    betaReduction (Variable('x')) |> should equal (Variable('x'))

[<Test>]
let ``Check with one application expression`` () =
    betaReduction (Application(Variable('x'), Variable('y'))) |> should equal (Application(Variable('x'), Variable('y')))

[<Test>]
let ``Check with one abstraction expression`` () =
    betaReduction (Abstraction('x', Variable('x'))) |> should equal (Abstraction('x', Variable('x')))

[<Test>]
let ``Check (λx.x) ((λx.x) (λz. (λx.x) z)) expression`` () =
    betaReduction (Application(Abstraction('x', Variable('x')), Application(Abstraction('x', Variable('x')), Abstraction('z', Application(Abstraction('x', Variable('x')), Variable('z'))))))
        |> should equal (Abstraction('z', Variable('z')))

[<Test>]
let ``Another λa.(λb.ab) b expression`` () =
    betaReduction (Application(Abstraction('a', Abstraction('b', Application(Variable('a'), Variable('b')))), Variable('b')))
        |> should equal (Abstraction('c', Application(Variable('b'), Variable('c'))))


