# 非同步運行

## 指令

+ ```do-dev.bat``` 啟動開發環境

## [Coroutine](https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Coroutine.html)

Unity 的 Coroutine 運作是建立在 MonoBehaviour 的行為之上，以單一執行緒 (thread) 的方式運行。

MonoBehaviour 的各種行為依據[執行生命週期](https://docs.unity3d.com/Manual/execution-order.html)運行，而一秒內能循環的生命週期次數即為每秒幀數 ( FPS、Frames Per Second )，躺若如果每幀間要進行的工作內容相似，則其邏輯撰寫 Update 內實行即可，但倘若執行要跨越多幀間的有進程的工作，就可以使用 Unity 的 Coroutine。

參考範例場景 Asynchrony 內的 [ApplicationStartup](./app/Assets/_Asynchrony/Sources/Script/ApplicationStartup.cs)，當 RunCoroutine 在第一幀被調用後，其後每個訊息輸出會在 yield 之後中斷，直到 Unity 判斷可繼續執行。

嚴苛來說，Coroutine 是一套基於 MonoBehaviour 腳本生命週期的運作方式，必需仰賴物件本身的運作狀況，適合用於根據當前狀態的動畫行為。

## [Async/Await](https://learn.microsoft.com/zh-tw/dotnet/csharp/asynchronous-programming/)

Async / Await 是 C# 的[非同步程式設計](https://learn.microsoft.com/zh-tw/dotnet/csharp/asynchronous-programming/task-asynchronous-programming-model)，並於執行期間產生 [Task](https://learn.microsoft.com/zh-tw/dotnet/api/system.threading.tasks.task?view=net-10.0) 物件，以此用於執行序管理與操作。

利用此方法，可以建立多執行續的遠端應用介面 ( Remote API ) 調用，待取回資料後存入相應資料模型，而畫面則應基於 Update 需要提取資料模型進行繪製。

參考範例場景 Asynchrony 內的 [ApplicationCore](./app/Assets/Framework/ApplicationCore.cs)、[ApplicationStartup](./app/Assets/_Asynchrony/Sources/Script/ApplicationStartup.cs)，當腳本 Start 時執行 RunCount，但此函數採非同步運作，因此當 Update 調用前期不會顯示 ApplicationCore 的 Count 數值，直到 RunCount 完成執行最終改寫 Count，此刻下一次 Update 時變會因 Count 改變而顯示數據。
