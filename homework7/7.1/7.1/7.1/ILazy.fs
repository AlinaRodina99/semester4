module ILazy

/// Interface that represents lazy calculations.
type ILazy<'a> =
     
     /// Method to get value of lazy calculation.
     abstract member Get: unit -> 'a
