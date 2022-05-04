// Smart Constructor
type UnitQuantity = private UnitQuantity of int
module UnitQuantity = // 同名のコンストラクタを書く
    let create qty =
        if qty < 1 then
            Error "unitQuantity can not be negative"
        else if qty > 1000 then
            Error "UnitQuantity can not be more than 1000"
        else
            Ok (UnitQuantity qty)
    let value (UnitQuantity qty) = qty

let unitQty = UnitQuantity 1 // will cause Error
let unitQtyResult = UnitQuantity.create 1
match unitQtyReesult with
    | Error msg -> printfn "Failure, Message is %s" msg
    | Ok uQty -> printfn "Succes. Value is %A" uQty
     let innerValue = UnitQuantity.value uQty
     printfn "innverValue is %i" innverValue

// 単位を使って型安全を実現する
[<Measure>]
type kg
[<Measure>]
type m

let fiveKilos = 5.0<kg>
let fiveMeters = 5.0<m>

// ビジネスロジックを型で表現する
// 1. 顧客のメアドがverifiedな場合だけ、パスワードリセットメールを送れる。逆にunverifiedな場合だけ、メアド確認メールを送れる。
type CustomerEmail = {
    EmailAddress : EmailAddress
    IsVerified : bool
} // これだと、いつ、なぜIsVerifiedが更新されるのか分からない。それに、うっかり開発者がIsVerifiedを更新する不具合を作ってしまったら、セキュリティ事案の種になってしまう。

// 上の問題を解決するために、同じ型を別のラベルで直和型として扱うことができる。
type CustomerEmail =
    | Unverified of EmailAddress
    | Verified of EmailAddress

// 型も分けることで、さらに安全にできる。
type CustomerEmail = 
    | Unverified of EmailAddress
    | Verified of VerifiedEmailAddress

// 2. 顧客情報として、メアドか住所のどちらかは必ず必要。
type Contact = {
    Name : Name
    Email: EmailContactInfo option
    Address: PostalContactInfo option
} // これだとどっちも空でも動いてしまう

type BothContactMethods = {
    Email : EmailContactInfo
    Address :PostalContactInfo
}

type ContactInfo = // 直和型を使って全部のパターンを網羅する
    | EmailOnly of EmailContactInfo
    | AddrOnly of PostalContactInfo
    | EmailAndAddr of BothContactMethods

type Contact = {
    Name : Name
    ContactInfo : ContactInfo
}

