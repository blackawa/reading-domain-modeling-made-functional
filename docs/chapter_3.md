# Chapter 3

## bounded context間の通信方法
1. ワークフローがイベントを発行する
2. イベントをリッスンしているコンテキストが存在する
3. コンテキストは、イベントを受信するとコマンドを発行する
4. コマンドは新しいワークフローを開始する

イベントをキューイングするようにすると、真に分離（decoupled）なシステムができるが、実際のところどうやってイベントをコンテキスト間で送り合うかは、選定したアーキテクチャ次第。
キューイングは、マイクロサービスとか非同期システムでは便利だけど、モノリスでは関数呼び出しで実現できるしね。

[脚注 Long running processes in DDD](https://www.slideshare.net/BerndRuecker/long-running-processes-in-ddd)（これだけで67ページあって、読むのしんどそうで草）

## コンウェイの法則の逆
「アーキテクチャがチーム構成を決める」のだ。現職ではそこまで明確にそれを感じたことはないが、言ってることは分かる。

## Bounded Context内でドメインイベントを生成するな
イベントはイベントなので、ワークフローの終わりに発行しなさい。さもないと、ドメインイベントに暗黙に状態が発生して、話がややこしくなるよ。

## 既存のレイヤードアーキテクチャの課題
「同時に変更が必要な箇所は、ひとつにまとまっているべき」という原則を侵している。なぜなら技術的にHorizontalに分割されているから。だから、それを避けるためにはワークフローごとにVerticalに分割すべき。
副作用をドメインワークフローの入口と出口にだけ配置し、内部は純粋に保とう。