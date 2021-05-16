module Exceptions

open System

exception MyException1 of string
exception MyException2 of string * int

let f1 x = 
    if x <> 0 then x
    else failwith "message"

let f2 x = 
    if x <> 0 then x
    else invalidArg (nameof(x)) "invalid arg"

let f3 x =
    if x <> null then x
    else nullArg (nameof(x))

let f4 x y = 
    if y = 0 then invalidOp "cannot divide by zero"
    else x / y

let f5 x = 
    if x = "bad" then 
        failwithf "Operation is bad!"
    else 
        printf "Operations is good!"

let f6 x = 
    if not (x) then raise (new InvalidOperationException("message"))
    else "ok"


let f7 x = 
    if not (x) then raise (MyException2 ("", 0))
    else "ok"

let f8 x =
   if x then failwith "error in true branch"
   else failwith "error in false branch"

let f9 x = 
    try
        failwith "asdf"
    with 
        | MyException1 msg -> printfn "haha I'm caught from type MyException %s" msg
        | :? System.InvalidOperationException as ex -> printfn "omg! I'm caught from type InvalidOperationException %s" ex.Message

let f10 x =
    try
        if x then "ok" else failwith "fail"
    finally
        1+1  // This expression should have type 'unit

// a approach to exposing functions that throw or not exceptions
let divideExn x y = x / y
let tryDivide x y = 
    try
        Some (x / y)
    with 
    | :? System.DivideByZeroException -> None

   
try 
    try 

        let n = divideExn 1 0
        printfn "result is %i" n
    finally 
        printfn "operation finished!"
with 
| :? System.DivideByZeroException -> printfn "haha u cannot divide by zero"
