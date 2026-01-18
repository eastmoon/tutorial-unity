# Unity 舞台 - 使用者介面

以 [Unity 5 - User Interface](../../unity5/1.%20User%20Interface) 研究為基礎，針對 Unity 6 與相關規範進行調查。

## 指令

+ ```do-dev.bat``` 啟動開發環境

## Unity UI 套件

在 Unity 5 中，[uGUI](https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/index.html) 是預設套件，但在 Unity 6 中則需在 Package 中指派引用才可正常運行；其設定方式如下：

+ 開啟[套件管理視窗](https://docs.unity3d.com/6000.3/Documentation/Manual/upm-ui.html) ( Window -> Package Management -> Package Manager )。
+ 點擊 ```+``` 符號並選擇 Install package from git URL。
+ 輸入 com.unity.ugui，並等待套件安裝完成。
+ 檢查 [Packages](./app/Packages/manifest.json) 確認套件設置完成。

## Structure

Unity 的 UI 系統，需以 [Canvas](https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/UICanvas.html) 為圖層，UI 的遊戲物件為元件。

在單一個場景內可擁有複數的Canvas，並可利用 [Canvas.enabled](https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Canvas.html) 作為顯示開關，修改此變數等同於 Editor 介面關閉 Canvas 的操作。

設計上，若要設計 3D 世界中的 UI 介面，須設定 [Canvas.renderMode](Canvas.renderMode)，若設定為 Camera，則可藉由藉此透過特定攝影機輸出內容，或疊加在 3D 世界前方。

## 解析度 ( Screen Resolutions )

參考範例場景 Screen 內的 [CanvasScript](./_ScreenResolutions/Sources/Script/CanvasScript.cs)。

預設上，Canvas 其長寬等同於可顯示螢幕的尺吋，若要修改其尺寸有以下兩種方式：

### [Canvas Scaler](https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-CanvasScaler.html)

Scaler 是以縮放的方式調整 Canvas 的輸出比例，以及子物件的相關比例。

在 Canvas Scaler 的 Scale Mode 可以設定相對螢幕的不同挑整模式：

+ Constant Pixel Size：無論螢幕尺寸如何變化，使用者介面都能保持相同的像素大小比例。
+ Scale With Screen Size：設定參考解析度與縮放比例，當螢幕解析度大小或大於參考，則會跟隨參考縮放所有UI元件。
+ Constant Physical Size：無論螢幕尺寸如何變化，使用者介面都能保持相同的物理比例 ( DPI、Dots Per Inch )。

### [Layout](https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/comp-UIAutoLayout.html)

Layout 元件是對 Canvas 提供子物件排列布局設定，在預設上 Canvas 並未使用 Layout，這使得子物件採用座標系來調整位置。

若使用 Layout 元件，則子物件會基於 Layout 的設定對子元件排版，典型的包括：

+ [Grid Layout Group](https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-GridLayoutGroup.html)，以網格結構布局子物件.
+ [Horizontal Layout Group](https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-HorizontalLayoutGroup.html)，以水平排列結構布局子物件。
+ [Vertical Layout Group](https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-VerticalLayoutGroup.html)，以垂直排列結構布局子物件。

## 對位、尺寸、座標指定

UI 物件皆擁有 [Rect Transform](https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/class-RectTransform.html) ，其結構包括三個重要參數類別：

+ Rect Transform information：包括物件的位置、尺寸等基本資訊。
+ Anchor presets：物件的相對位置。
+ Rotation、Scale：旋轉與縮放比。

透過這些參數的設定，可使註冊於 Canvas 內的子元件，在 Canvas 最大尺寸變動時，仍可保持元件的相對比例與大小。

## 事件系統

參考範例場景 LayoutAndEvent 內的 [ApplicationStartup](./_LayoutAndEvent/Sources/Script/ApplicationStartup.cs)。

在生成按鈕元件後，利用偵聽事件的機制在不同函數使用不同方式掛載事件處理函數：

+ ```btn1.onClick.AddListener(this.OnClickBtnHorizontal);```，提供宣告於類別中的處理函數。
+ ```btn2.onClick.AddListener(delegate { this.OnClickBtn("Vertical"); });```，使用[委派 ( Delegate )](https://learn.microsoft.com/zh-tw/dotnet/csharp/programming-guide/delegates/using-delegates) 封裝的處理函數，在執行時呼叫 onClickBtn 並傳遞指定的數值。
+ ```btn3.onClick.AddListener(() => this.OnClickBtn("Grid"));```，使用 [Lambda 運算式](https://learn.microsoft.com/zh-tw/dotnet/csharp/language-reference/operators/lambda-expressions) 封裝的處理函數，在執行時呼叫 onClickBtn 並傳遞指定的數值。
