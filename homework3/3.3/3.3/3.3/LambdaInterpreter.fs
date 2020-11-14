module LambdaInterpreter

open LambdaTerm

/// Function to check whether variable is free in expression.
let rec isFreeVariable expression variable =
    match expression with
    | Variable x -> x = variable
    | Abstraction(var, term)  -> var <> variable && isFreeVariable term variable
    | Application(term1, term2) -> isFreeVariable term1 variable || isFreeVariable term2 variable

/// Function that makes beta-reduction using normal strategy
let rec betaReduction expression =
    
    /// Function that makes substitution of new expression in current.
    let rec substitution previousExpression newExpression currentExpression =
        match currentExpression with 
        | Variable var when var = previousExpression -> newExpression
        | Variable _ -> currentExpression
        | Abstraction(var, term) when var = previousExpression -> currentExpression
        | Abstraction(var, term) when not (isFreeVariable newExpression var) -> Abstraction(var, substitution previousExpression newExpression term)
        | Abstraction(var, term) -> let newVariable = List.head (List.filter (fun x -> x <> previousExpression) (List.filter (not << isFreeVariable newExpression) ['a'..'z']))
                                    Abstraction(newVariable, substitution previousExpression newExpression (substitution var (Variable newVariable) term))
        | Application(term1, term2) -> Application(substitution previousExpression newExpression term1, substitution previousExpression newExpression term2)
    
    let rec betaReduction (expression : Term) =
        match expression with 
        | Variable _ -> expression
        | Abstraction(var, term) -> Abstraction(var, betaReduction term)
        | Application(Abstraction(var, term1), term2) -> betaReduction (substitution var term2 term1)
        | Application(term1, term2) -> Application(betaReduction term1, betaReduction term2)
    betaReduction expression