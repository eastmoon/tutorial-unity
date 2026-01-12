# Unity 核心流程

以 [Unity 5 - Core](../../unity5/0. Core) 研究為基礎，針對 Unity 6 與相關規範進行調查。

## 指令

+ ```do-dev.bat``` 啟動開發環境

## Unity 結構

Unity 應用程式啟動是必需存在一個[場景 ( Scene )](https://docs.unity3d.com/6000.3/Documentation/Manual/CreatingScenes.html)，此場景可以是預設的 Untitled ，也可以是資源 ( Assets ) 中的任一場景物件。

場景內可以包括數個[遊戲物件 ( GameObject )](https://docs.unity3d.com/6000.3/Documentation/Manual/GameObjects.html)，其中包括常見的光源 ( Light )、相機 ( Camera )、音訊 ( Audio )、影片 ( Video )、3D 物件 ( 3D Object ) 等，用於構建場景的各類資源。

遊戲物件可以包括數個[元件 ( Component )](https://docs.unity3d.com/6000.3/Documentation/Manual/Components.html)，其中包括常見的腳本 ( Script )、動畫 ( Animation ) 等，用於提供遊戲物件行為、效果的行為。

## Unity 軟體架構

若從軟體架構來觀察，Unity 本身具有完整的環境建構框架，開發人員僅需針對場景中的遊戲物件定義行為元件，即可讓互動遊戲運作起來；這樣的設計是一套完善的無程式碼設計 ( No-code design )，但反面來說也讓程式介入點難以理解且抽象。

倘若要定義一個適當的程式進入點，那麼任一場景( Scene ) 的相機 ( Camera ) 物件的腳本 ( Script ) 元件會最恰當；但由於 Unity 允許複數的場景同時存在，亦即會同是觸發複數程式進入點，導致啟動並行的狀況。

每個腳本 ( Script ) 元件會指向一個繼承 [MonoBehaviour](https://docs.unity3d.com/6000.3/Documentation/Manual/class-MonoBehaviour.html) 的類別，此類別主要提供了遊戲物件生命週期的事件掛勾 ( hooks )，透過函數覆寫讓掛勾行使當前類別定義的邏輯，從而調整遊戲物件的[執行生命週期](https://docs.unity3d.com/Manual/execution-order.html)。

## 範本

### 專案 ( Projects )

本範例定義了兩個專案項目 [Application](./app/Assets/_Application)、[HelloWorld](./app/Assets/_HelloWorld)，並在各項目定義 Scenes、Scources，細節如下：

+ Application、HelloWorld 皆包括一個場景於 Scenes 目錄。
+ Application、HelloWorld 場景包括一個相機 Camera 物件。
+ Application、HelloWorld 的 Camera 物件指向 ```Soruces/Script``` 內的 MonoBehaviour 類別。
+ HelloWorld 測試 MonoBehaviour 類別的事件函數執行順序。
+ Application 測試 MonoBehaviour 類別的事件中調用唯一化 ( Singleton ) 物件順序與方案。

### 插件 ( Plugins )

在實務範本時，會於場景階層 ( Window -> General -> Hierarchy，ctrl + 4) 定義測試要執行的場景；然而，若遵照 [01.project-structure](../01.project-structure) 所定義的專案目錄架構設定版本控制忽略內容，會因為忽略 Library 資料夾，導致啟動 Unity 專案後遺失場景階層的設定。

在 [Multi-Scene editing](https://docs.unity3d.com/2020.1/Documentation/Manual/MultiSceneEditing.html) 的 Tips and tricks 一節描述到『To avoid having to set up your hierarchy every time you restart unity or to make it easy to store different setups you can use ```EditorSceneManager.GetSceneManagerSetup``` to get a list of SceneSetup objects which describes the current setup. 』。

對此，參考上述建議，設計一個插件 [SceneSetupPlugin](./app/Assets/Plugins/SceneSetupPlugin.cs)，包擃以下功能：

+ 插件類別繼承 [EditorWindow](https://docs.unity3d.com/6000.3/Documentation/ScriptReference/EditorWindow.html)。
+ 宣告一個工具選單 ( Tools -> Scene Setup Manager )。
+ 啟動會載入一個資源檔 [SceneSetup.asset](./app/Assets/Plugins/SceneSetup.asset)，若此檔案不存在會在第一次執行產生。
+ 透過 ```Save Current Setup to Asset``` 將當前場景階層的設定存入 SceneSetup.asset。
+ 透過 ```Load Setup from Asset``` 將 SceneSetup.asset 載入場景階層。

透過此插件實務，可以瞭解 Unity 編輯器整體是可以透過自定義類別建構相應的客制化介面，從而生成相應的資源或檢測服務；略讀文件可以看到為數不少的類別，若有自動化相關的插件若需撰寫應基於此觀念調查。
