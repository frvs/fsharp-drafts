module PatternMatchingWithUnionTypes

type Degrees = 
    | DegreesC of float
    | DegreesF of float


let degreesCelsiusOnly (degree: Degrees): float option = 
    match degree with
    | DegreesC x -> Some x
    | DegreesF x -> None

let divide x y =
    try
        x / y
    with 
    | :? System.DivideByZeroException -> 0