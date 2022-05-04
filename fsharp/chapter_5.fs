// 単なる値の定義
type CustomerId = CustoerId of int
type WidgetCode = WidgetCode of string
type UnitQuantity = UnitQuantity of int
type KilogramQuantity = KilogramQuantity of decimal

// インスタンス化
let customerId = CustomerId 42
// デストラクチャリング
let (CustomerId innerValue) = customerId
let processCustomerId (CustomerId innerValue) =
    printfn "innerValue is %i" innerValue

// AND型の定義
type Order = {
    CustomerInfo : CustomerInfo
    ShippingAddress : ShippingAddress
    BillingAddress : BillingAddress
    OrderLines : OrderLine list
    AmountToBill : BillingAmount
}

// ドメインモデルを書き始めてから、まだ知らない業務にいきあたった場合の対処法
type Undefined = exn
type CustomerInfo = Undefined
type ShippingAddress = Undefined
type BillingAddress = Undefined
type OrderLine = Undefined
type BillingAmount = Undefined

// OR型の定義
type ProductCode = 
    | widget of WidgetCode
    | Gizmo of GizmoCode

type OrderQuantity = 
    | Unit of UnitQuantity
    | Kilogram of KilogramQuantity

// ワークフローの定義
type ValidateOrder = UnvalidatedOrder-> ValidatedOrder

// ワークフローの入出力の複雑さに向き合う
// 出力
type PlaceOrderEvents = {
    AcknowledgementSent : AcknowledgementSent
    OrderPlaced : OrderPlaced
    BillableOrderPlaced : BillableOrderPlaced
}

type PlaceOrder = UnvalidatedOrder -> PlaceOrderEvents

// 入力
type EnvelopeContents = EnvelopeContents of string
type CategorizedMail =
    | Quote of QuoteForm
    | Order of OrderForm

type CategorizeInboundMail = EnvelopeContents -> CategorizedMail

// 処理が失敗する可能性と向き合う
type ValidateOrder = UnvalidatedOrder -> Result<ValidatedOrder,ValidationError list>
type ValidationError = {
    FieldName : string
    ErrorDescription : string
}

// 処理が非同期なことを型で表現する
type ValidateOrder = UnvalidatedOrder -> Async<Result<ValidatedOrder, ValidationError list>>
type ValidationResponse<'a> = Async<Result<'a, ValidationError list>>
type ValidateOrder = UnvalidatedOrder -> ValidationResponse<ValidatedOrder>

// Value Objectの同一性を調べる
let widgetCode1 = WidgetCode "W1234"
let widgetCode2 = WidgetCode "W1234"
printfn "%b" (widgetCode1 = widgetCode2) // prints true

let name1 = {FirstName="Alex"; LastName="Adams"}
let name2 = {FirstName="Alex"; LastName="Adams"}
printfn "%b" (name1 = name2) // prints true

// Entityの同一性を調べる
type ContactId = ContactId of int
[<CustomEquality; NoComparison>]
type Contact = {
    ContactId : ContactId
    PhoneNumber : PhoneNumber
    EmailAddress : EmailAddress
}
with
override this.Equals(obj) =
    match obj with
    | :? COntact as c -> this.ContactId = c.ContactId
    | _ -> false
override this.GetHashCode() =
    hash this.ContactId

let contactId = ContactId 1
let contact1 = {
    ContactId = contactId
    PhoneNumber = PhoneNumber "123-456-7890"
    EmailAddress = EmailAddress "bob@example.com"
}

let contact2 = {
    ContactId = contactId
    PhoneNumber = PhoneNumber "123-456-7890"
    EmailAddress = EmailAddress "robert@example.com"
}

printfn "%b" (contact1 = contact2)

// Keyプロパティを使った同一性検査
[<NoEquality; NoComparison>]
type OrderLine = {
    OrderId : OrderId
    ProductId : ProductId
    Qty : int
}
with
member this.Key =
    (this.OrderId,this.ProductId)

printfn "%b" (line1.Key = line2.Key)

// Entityの変更
let initialPerson = {PersonId=PersonId 42; Name="Joseph"}
let updatedPerson = {initialPerson with Name="Joe"}
