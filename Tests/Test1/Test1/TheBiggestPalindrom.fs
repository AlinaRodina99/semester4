module TheBiggestPalindrom

let findBiggestPalindrom =
    
    let countDigitsInNumber number =
        let rec countDigitsInNumberRec digitList number =
            match number with 
            | _ when number = 0 -> digitList
            | _ -> countDigitsInNumberRec (number % 10 :: digitList) (number / 10)
        countDigitsInNumberRec [] number

    let isPalindrom number = 
        let digitList = countDigitsInNumber number
        let rec isPalindromRec digitList =
            match digitList with 
            | _ when List.length digitList = 1 -> true
            | _ when List.head digitList = List.last digitList && digitList.Length = 2 -> true
            | _ -> if List.head digitList = List.last digitList then isPalindromRec (List.tail (List.rev (List.tail digitList)))
                   else false
        isPalindromRec digitList    

    let rec findBiggestPalindromRec x y acc =
        if (x <= 999) && (y < 999) && isPalindrom (x * y) && (x * y) > acc then findBiggestPalindromRec x (y + 1) (x * y)
        elif (x <= 999) && (y < 999) then findBiggestPalindromRec x (y + 1) acc
        elif (x <= 999) && (y = 999) && isPalindrom (x * y) && (x * y) > acc then findBiggestPalindromRec (x + 1) 100 (x * y)
        elif (x <= 999) && (y = 999) then findBiggestPalindromRec (x + 1) 100 acc
        else acc
    findBiggestPalindromRec 100 100 1