// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let myInt = 1
let myFloat = 2.0
let myString = "ASDF"

let twoToFive = [2;3;4;5]
let oneToFive = 1 :: twoToFive
let zeroToFive = [0;1] @ twoToFive

let square (x: int): int = x * x
let add x y = x + y
let squareOneTo100Summed = [1..100] |> List.map square |> List.sum
let squareOneTo100SummedFunctions = [1..100] |> List.map (fun x -> x*x) |> List.sum
let evens xs = 
    let isEven x = x % 2 = 0
    List.filter isEven xs

let noneVal = None
let someVal = Some(11)
    
let pm = 
    let x = "a"
    match x with
    | "a" -> "A!"
    | _ -> "I will never happen!"
    
let tuple = 2,3,4,5
let two, _, _, _= tuple

type User = { Username: string; Password: string; Email: string }
let myUser = { Username= "Frois"; Password= "123"; Email= "frois.dev@gmail.com"}

type Temperature = 
    | DegreesC of float
    | DegreesF of float
let temp = DegreesC 23.5

type Employee = 
    | Worker of User
    | Managers of Employee list

let worker = Worker myUser

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    let message = from "F#" // Call the function
    printfn "Hello world %s" message
    square 3 |> printfn "3 ** 2 = %i"  
    add 3 2 |> printfn "3 + 2 = %i"
    evens zeroToFive |> printfn "evens %A"
    printfn "%s %i" (nameof squareOneTo100Summed) squareOneTo100Summed
    printfn "%s %i" (nameof squareOneTo100SummedFunctions) squareOneTo100SummedFunctions
    printfn "Im None %A" noneVal
    printfn "Im some %i" someVal.Value
    printfn "A? %s" pm
    printfn "I'm a two from tuple: %i" two
    printfn "My user: %A" myUser
    printfn "temperature now: %A" temp
    printfn "se a classe operária tudo produz a ela tudo pertence %A" worker


    0 // return an integer exit code

