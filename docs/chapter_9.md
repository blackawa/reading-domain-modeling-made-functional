# パイプラインを作る

適切に命名されたパイプラインは、非開発者にも読みやすい。
ただし関数合成は、下記の点で邪魔されることがある。
- 引数以外の依存関係
- ResultやOptionでラップされた（副作用のある）出力に

## シンプルな型から始めよ


## 感想

F#くん、もしかしてmoduleを使って実質的にデータとふるまいを紐付けるOOPみたいなことをやってない？
private constructorとか...。これ、Clojureだとどうするのがいいんだろう。型による動作の制御なんて存在しないもんなー。

例外って副作用なんだ... たしかに...。