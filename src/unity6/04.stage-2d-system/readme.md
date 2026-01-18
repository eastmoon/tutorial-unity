# Unity 舞台 - 2D

以 [Unity 5 - Stage 2D System](../../unity5/2.%20Stage_2D%20System) 研究為基礎，針對 Unity 6 與相關規範進行調查。

## 指令

+ ```do-dev.bat``` 啟動開發環境

## 2D 舞台

Unity 2D 遊戲舞台的設計，是基於 Unity 3D 舞台，但維持鏡頭拍攝方位、距離，並以正交投影 ( Orthographic ) 方式讓攝影機完成繪製。

### 投影

對於 Unity 的相機，其 3D 與 2D 視覺效果在於其投影方式 ( Projection )：

+ 透視 ( Perspective )：基於透視效果渲染物件。
+ 正交 ( Orthographic )：相機會均勻渲染物件，並且不會產生透視感。

這兩個透影技術可參考 [Orthographic vs. Perspective Projection: Key Differences and Applications](https://www.alexomegapy.com/post/orthographic-vs-perspective-projection-key-differences-and-applications)，透視其本質就是當物體遠離投影中心 ( 相機 )，則會產生相對的變形與縮放，進而產生距離感。

若要切換 Projection 則可如下設定相機參數：

```
Camera.orthographic = true | false;
Camera.orthographicSize = {N ; N > 0};
```

### 影像尺寸

一個 Sprite 物件，其實際尺寸與最後輸出至畫面的尺寸需經過一連串計算過程來取得相對的數據。

1. Retrieve sprite size and transform to world size.
	a. The sprite size is image, make pixel transform to unit.
	b. Consider scale make sprite change size.

2. Convert to screen space size.
	a. orthorraphicSize is 1/2 screen height.

3. Size in pixels

※ 相關文章參考：
---------------------------
Getting a sprites size in pixels
http://answers.unity3d.com/questions/1042119/getting-a-sprites-size-in-pixels.html
---------------------------

### 解析度，Screen Resolutions

參考範例場景 ScreenResolutions 內的 [ApplicationStartup](./app/Assets/_ScreenResolutions/Sources/Script/ApplicationStartup.cs)。

在 Unity 3D 其投影成像是依據攝影機內的兩項參數來決定：

+ 投影結果的輸出尺寸，此值可為固定、亦可為不固定，例如 [Screen.SetResolution](https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Screen.SetResolution.html) 可設定 Screen 解析度。
+ 投影機在空間中的尺寸，此值會影響到自空間中投影的面積，在設計輸出時，亦會依據實際需求與比例設計攝影機的投影面。

這樣的設計，也對應於正交投影的相機內；然而，不論三維空間或二維空間的計算，都會依存一個數值為比例量尺 PPU ( Pixels per Unit )，每個單元等於多少像素。

+ ```Image Settings => Pixels Per Unit = 1 ( 每個 Unit 等於1個 Pixels )```，此設定作用於匯入的影像上。

此外，在 [Camera.orthographicSize](https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Camera-orthographicSize.html) 提到『The height of the viewing volume is (orthographicSize * 2)』，因此推算得到以下算式：

+ ```Orthographic size = Screen.height / 2```，此設定可配置於介面或利用程式動態調整。

在公式上，實際計算回如下式：

```
UPP ( Unit per Pixels ) = Screen.height / (OrthographicSize * 2)
PPU ( Pixels per Unit ) = 1
Output Image height = (Image.height / PPU) * UPP
```

若在 Screen.height = 100、OrthographicSize = 5、Image.hegith = 10

```
Output Image hegith = (10 / 1) * 100 / (5 * 2) = 100
```

若在Screen.height = 100、OrthographicSize = 50、Image.hegith = 10

```
Output Image hegith = (10 / 1) * 100 / (50 * 2) = 10
```

+ [Screen](https://docs.unity3d.com/ScriptReference/Screen.html)
+ [Pixel Perfect Calculator for Orthographic Camera : Unity3D](https://indiehoodgames.wordpress.com/2013/07/27/pixel-perfect-calculator-for-orthographic-camera-unity3d/)
