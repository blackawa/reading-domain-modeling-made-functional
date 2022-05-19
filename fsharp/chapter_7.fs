// どんなコマンドでも必ずTimestampとUserIdを受け取ることを強制する
type Command<'data> = {
    Data: 'data
    Timestamp: DateTime
    UserId: string
}

type PlaceOrder = Command<UnvalidatedOrder>

// 状態ごとに異なるドメインモデルを書く
type ValidatedOrder = {
    OrderId: OrderId
    CustomerInfo: CustomerInfo
    // etc...
}

// 状態の集合は直和型で表現できる
type Order = 
    | Unvalidated of UnvalidatedOrder
    | Validated of ValidatedOrder
    | Priced of PricedOrder