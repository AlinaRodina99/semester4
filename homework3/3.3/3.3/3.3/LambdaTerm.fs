module LambdaTerm

/// Class represents the concept of term.
type Term =
    | Variable of char
    | Abstraction of char * Term
    | Application of Term * Term
