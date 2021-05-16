module Folds

let product n =
    let initialValue = 1
    let action productSoFar x = productSoFar * x
    [1..n] |> List.fold action initialValue

//test
product 10

let sumOfOdds n =
    let initialValue = 0
    let action sumSoFar x = if x%2=0 then sumSoFar else sumSoFar+x
    [1..n] |> List.fold action initialValue

//test
sumOfOdds 10

let alternatingSum n =
    let initialValue = (true,0)
    let action (isNeg,sumSoFar) x = if isNeg then (false,sumSoFar-x)
                                             else (true ,sumSoFar+x)
    [1..n] |> List.fold action initialValue |> snd

//test
alternatingSum 100

let sumOfNumbersTo x = 
    [1..x] |> List.fold (fun x y -> x + y) 0

sumOfNumbersTo 3 // 6

let count xs = 
    xs |> List.fold (fun x y -> x + 1) 0

count [1;2;3;4;5;6] // 6

let max x y = if x > y then x else y
let findMax xs = xs |> List.reduce max

findMax [1;2;3;4;5] // 5

let merge xs ys =
    xs @ ys

List.fold merge [] [[1;2;3]; [4;5;6]; [7;8;9]] // [1;2;3;4;5;6;7;8;9]

let factorial n = 
    List.fold (fun x y -> x * y) 1 [1..n]

factorial 3 // 6

let reverse xs = 
    List.fold (fun acc x -> x :: acc) [] xs

reverse [1..3] // [3;2;1]

let map f = 
    List.fold (fun acc x -> List.append acc [f x]) 
