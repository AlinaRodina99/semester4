// Learn more about F# at http://fsharp.org

open System
open Picture

[<EntryPoint>]
let main argv =
    
    let picture n =
        let rec pictureRec x y iter =
            match (x, y) with
            | _ when x = n -> pictureRec -1 y iter 
            | _ when x < n  && x >= 0 -> printf "*"
                                         pictureRec (x + 1) y iter
            | _ when y = 0 && x = -1 -> printf "*"
                                        pictureRec -1 (y + 1) iter
            | _ when y = n - 1 && x = -1 -> printf "*"
                                            pictureRec -1 0 iter
            | _ when y < n - 1 && x = -1 -> printf " "
                                            pictureRec -1 (y + 1) iter
            | _ when y = n - 2 && x = -1 && iter < n - 1 -> printf "/n"
                                                            pictureRec -1 0 (iter + 1)
            | _ when iter = 3 -> printf "*"
                                 pictureRec x -1 iter
            | _ -> printf "/n"
        
        if n < 0 then printf "square must be posistve"
        else pictureRec 0 0 0

    picture 1
    printfn "Hello World from F#!"
    
    0 // return an integer exit code
