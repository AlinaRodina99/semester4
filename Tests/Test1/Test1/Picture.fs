module Picture

let picture n =
    let rec pictureRec x y iter =
        match (x, y) with
        | _ when x < n -> printf "*"
                          pictureRec (x + 1) y iter
        | _ when x = n -> pictureRec -1 y iter
        | _ when y < n - 2 && x = -1 -> printf "*"
                                        pictureRec 0 y iter
        | _ -> printf ""
    if n < 0 then printf "square must be posistve"
    else pictureRec 0 0 0
                                      