# UI toolkit

針對 Unity 6 功能  UI toolkit 相關規範進行調查。

## 指令

+ ```do-dev.bat``` 啟動開發環境

## UI toolkit VS UGUI

彙整 [UI toolkit VS UGUI - AI 檢索](https://share.google/aimode/NyJg3K1rl0tQHyjNJ) 概述如下：

### UI Toolkit (UITK)

+ 架構 ( Architecture )：Document-based，採用 UXML 為佈局結構、USS 為樣式、C# 為邏輯。
+ 優點 ( Pros )：適用於複雜 UI，諸如列表 ( List )、網格 ( Grids )，設計方式類同網頁版面設計，其中 UXML 類同 HTML、USS 類同 CSS，並且提供資料綁定、編譯與運行結構一致、適合開發複雜介面等優點。
+ 缺點 ( Cons )：基於遊戲物件為主的功能如 world space canvas、advanced shaders 並未支援或等待支援。

UITK 其類同網頁設計 ( web-like design ) 亦表示繼承網頁設計在 DOM 設計概念上的優點，讓其適合結構性排版設計，越是根據佈局、框線、樣式、內容元件構成的畫面越亦適合，且相關設計概念可一併應用。

### uGUI (Unity UI)

+ 架構 ( Architecture )：GameObject-based，採用 Canvas 為基礎，並以 RectTransform 做定位，可添加運用於 3D、2D 空間的 Components 來輔助。
+ 優點 ( Pros )：Unity 原生體系，對舊版本支援且累積豐富開源，基本利用 Unity 遊戲物件為基礎，容易與空間物件、動畫等物件互用。
+ 缺點 ( Cons )：會增加 Unity 場景中的遊戲物件總數，導致效能議題，且不易設計複雜介面、資料綁定需依賴程式。

+ Best For: Runtime game UIs needing 3D integration, simple HUDs, projects prioritizing deep animation/shaders.

UGUI 適合簡易的 UI 介面，如 HUDs 等設計，且介面有 3D、2D 整合需要，或需應用於動畫 ( Animation ) 與著色 ( Shaders ) 元件。

## UITK

### 建立 UI Editor

參考文獻 [Get started with UI Toolkit](https://docs.unity3d.com/6000.3/Documentation/Manual/UIE-simple-ui-toolkit-workflow.html) 的 『 Create a custom Editor window 』段落執行，並在自定目錄實行後產生一系列基礎檔案：

+ [SimpleCustomUI.uxml](./app/Assets/_UITK/UI/SimpleCustomUI.uxml)，用於 UI 的版面佈局，UXML 是一種專用於 Unity 的 XML 格式，詳細可參閱 [Structure UI](https://docs.unity3d.com/6000.3/Documentation/Manual/UIE-structure-ui.html)
    - 設定佈局雖可使用 UXML，亦可使用程式生成元件並放入佈局中，主要類別來源於 [UnityEngine.UIElements](https://docs.unity3d.com/6000.3/Documentation/ScriptReference/UnityEngine.UIElementsModule.html)。
+ [SimpleCustomUI.uss](./app/Assets/_UITK/UI/SimpleCustomUI.uss)，用於 UI 的樣式設計，語法與 CSS 相同且具有相似的值可運用，詳細可參閱 [Style UI](https://docs.unity3d.com/6000.3/Documentation/Manual/UIE-USS.html)
+ [SimpleCustomEditor.cs](./app/Assets/_UITK/UI/SimpleCustomEditor.cs)，用於 UI 編輯檢視，提供一個靜態函數並宣告可經由 ( Window -> UI Toolkit -> SimpleCustomEditor ) 開啟檢閱模式。
    - 實務確認，cs 和 uxml、uss 可為不同名稱，Unity 系統知悉其關聯主要來源於 cs.meta 中的設定 ```m_VisualTreeAsset``` 指定了 uxml 的 guid，而在 cs 中此變數採用預設值，因此可以固定下來源檔案。

原則上，此方式用於快速建立 UITK 的 uxml、uss，但並不包括場景中的互動行為，僅用於檢視佈局與樣式。

### 執行 UI

參考文獻 [Get started with runtime UI](https://docs.unity3d.com/6000.3/Documentation/Manual/UIE-get-started-with-runtime-ui.html)，其主要步驟如下：

+ 使用 UI Toolskit 建立好 uxml、uss 物件
+ 於場景 ( Scene ) 建立 UI Documnet 並讓 Source Asset 指向前述的 uxml 檔案
+ 於 UI Document 新增 Component，選擇 Script 並指向 [SimpleCustomUI.cs](./app/Assets/_UITK/UI/SimpleCustomUI.cs)

執行 Play 即可看到 UI Document 呈現於 3D 空間之前。

### 繪製 UI

[UI Renderer](https://docs.unity3d.com/6000.3/Documentation/Manual/UIE-ui-renderer.html) 是基於 Unity 圖像與渲染機制來建立相應視覺內容，其主要包括如下技術：

+ [Generate 2D visual content](https://docs.unity3d.com/6000.3/Documentation/Manual/UIE-generate-2d-visual-content.html)，利用 [Painter2D](https://docs.unity3d.com/6000.3/Documentation/ScriptReference/UIElements.Painter2D.html) 繪製圖像符號或任何圖像物件。
+ [Work with vector graphics](https://docs.unity3d.com/6000.3/Documentation/Manual/ui-systems/work-with-vector-graphics.html)，利用貝茲曲線建立向量圖像。

### 快取目錄

UI Toolkit 為便於開發人員設計，會自動產生快取目錄，在確認相關目錄用途後應判斷是否忽視此目錄。

+ 目錄 ```UIElementsSchema```，經確認為 Unity 自動生成的文件夾，其中包括 UXML 文件的 XML Schema 定義，主要提供如 Visual Studio 等 IDE 進行程式碼自動補全等功能使用。
+ 目錄 ```Assets/UI Toolkit```，精確認為 Unity 在場景添加 UI Document 時自動生成的預設面板 ( Panel ) 設定資訊
