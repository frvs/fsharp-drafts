module PatternMatching

let rec loopAndPrint lst = 
    match lst with
    | [] -> printfn "%A" []
    | x::xs -> 
        printfn "x: %i" x
        loopAndPrint xs

loopAndPrint []
loopAndPrint [1..4]

let rec loopAndSum lst sumSoFar = 
    match lst with
    | [] -> sumSoFar
    | x::xs -> loopAndSum xs x + sumSoFar

printfn "sum %i" (loopAndSum [1;2;3] 0)

match (1,2) with
| (_, _) -> printfn "I'm a flow control master"
| (_, 2) -> printfn "the second is two"
| (1, _) -> printfn "the first is one"

type x = { First: string; Second: string}
match {First=""; Second=""} with
| {First = "John"} -> printfn "It's John!"
| _ -> printfn "Isn't John :("

type stringOrInt = S of string | I of int

let (x: stringOrInt) = S "haha I'm a string"

match x with
| I i -> printfn "%i" i
| S s -> printfn "%s" s

let isAM aDate =
    match aDate:System.DateTime with
    | x when x.Hour <= 12->
        printfn "AM"

    // otherwise leave alone
    | _ ->
        printfn "PM"

//test
isAM System.DateTime.Now