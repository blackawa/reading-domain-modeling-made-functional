// どんなコマンドでも必ずTimestampとUserIdを受け取ることを強制する
type Command<'data> = {
    Data: 'data
    Timestamp: DateTime
    UserId: string
}

type PlaceOrder = Command<UnvalidatedOrder>

