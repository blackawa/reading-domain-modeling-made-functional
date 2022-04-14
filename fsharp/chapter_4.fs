// basic function
let add x y = x + y // signature is: int -> int -> int

// multiple lines
let squarePlusOne x =
    let square = x * x
    square + 1

// generic type
let areEqual x y = 
    (x = y)

// composing record type(PRODUCT type)
type FruitSalad = {
    Apple: AppleVariety
    Banana: BananaVariety
    Cherries: CherryVariety
}

// composing choice type(SUM type / discriminated union)
type FruitSnack = 
    | Apple of AppleVariety
    | Banana of BananaVariety
    | Cherries of CherryVariety

// Varieties are also types.
type AppleVariety =
    | GoldenDelicious
    | GrannySmith
    | Fuji

type BananaVariety = 
    | Cavendish
    | GrosMichel
    | Manzano

type CherryVariety =
    | Montmorency
    | Bing

// simple types
type ProductCode = ProductCode of string

// composing type and use it as a value
type Person = {First:string, Last:string}
let aPerson = {First="Alex"; Last="Adams"}

// deconstruct value in a type
let {First=first1; Last=last1} = aPerson
let first2 = aPerson.First
let last2 = aPerson.Last

