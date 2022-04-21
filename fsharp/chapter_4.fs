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

type OrderQuantity =
    | UnitQuantity of int
    | KilogramQuantity of decimal

let anOrderQtyInUnits = UnitQuantity 10
let anOrderQtyInKg = KilogramQuantity 2.5

let printQuantity aOrderQty =
    match aOrderQty with
    | UnitQuantity uQty ->
     printfn "%i units" uQty
    | KilogramQuantity kQty ->
     printfn "%i kg" kQty

// # Builing a Domain Model by Composing Types
type CheckNumber = CheckNumber of int
type CardNumber = CardNumber of string
type CardType = 
    Visa | MasterCard
type CreditCardInfo = {
    CardType: CardType
    CardNumber: CardNumber
}
type PaymentMethod =
    | Cash
    | Check of CheckNumber
    | Card of CreditCardInfo
type PaymentAmount = PaymentAmount of decimal
type Currency = EUR | USD

type Payment = {
    Amount: PaymentAmount
    Currency: Currency
    Method: PaymentMethod
}

// Function type
type PayInvoice =
    UnpaidInvoice -> Payment -> PaidInvoice
type ConvertPaymentCurrency = Payment -> Currency -> Payment

// Optional value
type Option<'a> =
    | Some of 'a
    | None
type PersonalName = {
    FirstName: string
    MiddleInitial: string option
    LastName: string
}

type Result<'Success, 'Failure> =
    Ok of 'Success
    Error of 'Failure

type PayInvoice =
    UnpaidInvoice -> Payment -> Result<PaidInvoice,PaymentError>
type PaymentError =
    | CardTypeNotRecognized
    | PaymentRejected
    | PaymentProviderOffline

type SaveCustomer = Customer -> unit
type NextRandom = unit -> int
type Order = {
    OrderId: OrderId
    Lines: OrderLine list
}
let aList = [1; 2; 3]
let aNewList = 0 :: aList
let printList1 aList =
    match aList with
    | [] -> printfn "list is empty"
    | [x] -> printfn "list has one element: %A" x
    | [x y] -> printfn "list has two elements: %A and %A" x y
    | longerList -> printfn "list has more than two elements"
let printList2 aList =
    match aList with
    | [] -> printfn "list is empty"
    | first::rest -> printfn "list is non-empty with the first element being: %A" first

