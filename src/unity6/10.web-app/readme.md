# WebGL 應用程式

針對 Unity 6 發佈、執行相關規範進行調查。

## 指令

+ ```do-dev.bat``` 啟動開發環境
+ ```do-pub.bat``` 執行發佈指令
    - 使用該指令時必需確保當前的 Unity 未啟動
+ ```do-run.bat``` 基於發佈內容啟動運行環境

本項目範例，設計一個繞物運轉的鏡頭操作。

## 發佈

關於[編譯與發佈](https://docs.unity3d.com/Manual/building-introduction.html)可參考連結的官方文獻說明，簡略來說，Unity 編譯與發佈有兩個主要方式：

+ 使用編輯器，可參考[Create a build from the Editor](https://docs.unity3d.com/Manual/BuildSettings.html)

簡約來說是使用 ( File -> Build Profile )，在其介面中選擇 Platform 並設定需編譯的場景 ( Open Scene List )，在點擊下方的編譯或發佈。

+ 使用腳本，可參考[Customize the build pipeline](https://docs.unity3d.com/Manual/build-customize-build-pipeline.html)

參考 Editor 內的 [WebGLBuilder](./app/Assets/Editor/WebGLBuilder.cs) 的內容，此方式是透過腳本編寫編譯、發佈所需的內容，並透過如下指令運行：

```
[Unity_Editor_App] -- -quit -batchmode -logfile [DEVOPS_LOGFILE_PATH] -projectPath [PROJECT_PATH] -executeMethod WebGLBuilder.build
```
> Unity_Editor_App 依據不同作業系統會存在不同位置，且執行該指令必需經過授權驗證才可正常運作

若要自訂 WebGL 匯出的 HTML 樣板，可參考 [Web templates](https://docs.unity3d.com/6000.3/Documentation/Manual/webgl-templates.html) 文獻。

## 執行

發佈 WebGL 的內容後，會儲存於 ```app/Build``` 目錄內，啟動 Nginx 伺服器即可運行該服務。

但需注意，由於 Unity 需下載數個檔案，為此 Nginx 需有相應設定確保檔案回傳的資訊正確，詳細資訊可參考 [Set up your Nginx server configuration for Web builds](https://docs.unity3d.com/6000.3/Documentation/Manual/web-server-config-nginx.html)。

## 瀏覽器互動

參考文獻 [Interaction with browser scripting](https://docs.unity3d.com/6000.3/Documentation/Manual/webgl-interactingwithbrowserscripting.html) 所述，並設置如下腳本：

+ [utils.jslib](./app/Assets/Plugins/utils.jslib)
+ [InteractionWithBrowser.cs](./app/Assets/_WebApp/Sources/Script/InteractionWithBrowser.cs)

從文獻描述來看，其概念是透過 C# 的 [DllImportAttribute 類別](https://learn.microsoft.com/zh-tw/dotnet/api/system.runtime.interopservices.dllimportattribute?view=net-9.0) 實踐引入外部函示庫的操作；實測上，可以確認 .jslib 中能直接調用到 [window](https://developer.mozilla.org/en-US/docs/Web/API/Window)，亦可直接調用到 localStorage 等資訊，亦可透過執行狀態透過[回呼 ( Callback ) 反饋](https://docs.unity3d.com/6000.3/Documentation/Manual/web-interacting-browser-example.html)訊息。

但需注意，若在 Unity 使用 Play 測試，會因為 DLLImport 的函數不存在導致異常訊息『```unity EntryPointNotFoundException: Hello assembly:<unknown assembly> type:<unknown type> member:(null)```』，若要規避這問題需做以下設定：

+ 特定平台使用指令應用[預處理指令](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/preprocessor-directives)包裹。
```
#if UNITY_WEBGL
[DllImport("__Internal")]
private static extern void Hello();
#endif
```
+ UNITY_WEBGL 此標記僅當 Build Profile 的 WebGL 平台為啟動時才存在。
+ 使用 ```do-pub.bat``` 編譯與發佈後，會導致 Build Profile 啟動平台置換成 WebGL，需手動切回對應主機的平台才能確保上述異常不會發生。

範本使用的是 WebGL 樣板，若要修改 JavaScript 溝通方式與 HTML 結構，則參考 [Web templates](https://docs.unity3d.com/6000.3/Documentation/Manual/webgl-templates.html) 文獻，建立符合需求的樣板，並在編譯程序中添加 [PlayerSettings.WebGL.template](https://docs.unity3d.com/ScriptReference/PlayerSettings.WebGL-template.html) 設定。
