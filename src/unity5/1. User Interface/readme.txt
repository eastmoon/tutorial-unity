◎ User Interface

◎ Structure

Unity 5的UI系統，採用的是階層式結構，以Canvas為根，UI Object為點。
在單一個場景內可擁有複數的Canvas，並以Canvas.enabled作為顯示開關。
此外，當建立場景內的第一個Canvas，會同時建立對應的EventSystem，並以此來擷取各類操作裝置的輸入。

※ 設計上，傳統的Unity 5以下版本，其UI系統多為禁用，應避免涉及相關內容。
※ 設計上，若要設計3D UI，將Canvas -> Render Mode -> Screen Space - Camera，藉此透過特定攝影機輸出內容。
※ 相關文章參考：
---------------------------
Canvas
http://docs.unity3d.com/Manual/UICanvas.html
---------------------------

◎ 解析度，Screen Resolutions
Demo : ScreenResolutions

預設上，Canvas其長寬等同於可顯示螢幕的尺吋，若要修改其尺寸有以下兩種方式：

1. Canvas Scaler

Scaler是以縮放的方式調整Canvas的輸出比例，以及子物件的相關比例。

『In the Canvas Scaler component, you can set its UI Scale Mode to Scale With Screen Size. With this scale mode you can specify a resolution to use as reference. If the current screen resolution is smaller or larger than this reference resolution, the scale factor of the Canvas is set accordingly, so all the UI elements are scaled up or down together with the screen resolution.』

在Canvas Scaler的Scale Mode設定Scale With Screen Size，並設定參考解析度；當螢幕解析度大小或大於參考，則會跟隨參考縮放所有UI元件。

2. Layout

Layout元件是對此Canvas提供畫面調整、子物件關聯、排列方式。
在預設上並未使用Layout的Canvas，其結構與典型的視窗系統相同，是以座標戲來調整子物件的位置。
使用Layout元件則可以透過Layout內定的方式對子元件排版；詳細設計參考文件說明。

※ 相關文章參考：
---------------------------
Canvas Scaler
http://docs.unity3d.com/Manual/script-CanvasScaler.html

Basic Layout
http://docs.unity3d.com/Manual/UIBasicLayout.html

Auto Layout
http://docs.unity3d.com/Manual/comp-UIAutoLayout.html

Designing UI for Multiple Resolutions
http://docs.unity3d.com/Manual/HOWTO-UIMultiResolution.html

Unity UGUI 原理篇(二)：Canvas Scaler 縮放核心
http://k79k06k02k.com/blog/24/unity/unity-ugui-%E5%8E%9F%E7%90%86%E7%AF%87%E4%BA%8C%EF%BC%9Acanvas-scaler-%E7%B8%AE%E6%94%BE%E6%A0%B8%E5%BF%83
---------------------------

◎ 對位、尺寸、座標指定

所有的UI Object皆擁有Rect Transform與Anchor presets兩個重要參數系統。
Rect Transform：UI Object的位置、尺寸等基本資訊。
Anchor presets：UI Object的對位方式。

透過這兩項參數系統的設定，可使登記於Canvas內的子元件，在Canvas因外力導致最大尺寸變動時，仍可保持元件的相對比例與大小。
但在透過程式設定其座標位置時，要注意以下操作方式。

1. transform.position
設定物件所在的世界座標。
※ 此設定不是合用於UI。

2. transform.localPosition
設定物件所在的相對座標，依據Parent所在的位置調整。
※ 此設定不是合用於UI。

3. GetComponent<RectTransform>().localPosition
設定物件所在二維空間中的相對座標，此座標會依據Anchor位置為中心點。


※ 在實驗程式中，使用transform來指定，其座標填入時會實際轉換後，再依據Anchor調整；這使得物件無法如預期的出現在顯示的位置。
※ 相關文章參考：
---------------------------
Rect Transform
http://docs.unity3d.com/Manual/class-RectTransform.html

Basic Layout
http://docs.unity3d.com/Manual/UIBasicLayout.html

What's the best practice for moving RectTransforms in Script?
http://forum.unity3d.com/threads/whats-the-best-practice-for-moving-recttransforms-in-script.264495/

Set value on GameObject.transform.position.x with C# ?
http://forum.unity3d.com/threads/set-value-on-gameobject-transform-position-x-with-c.66768/

How to set the new Unity UI Rect Transform Anchor Presets
http://answers.unity3d.com/questions/1007886/how-to-set-the-new-unity-ui-rect-transform-anchor.html
---------------------------

◎ 顯示順序
https://docs.unity3d.com/ScriptReference/Canvas-sortingOrder.html

1. Sort order

針對Canvas元件，有一參數SortingOrder，設定該參數，即可調整Canvas間的關係。
參數數字越大，顯示在越前面。

2. Enabled order

在相同Sorting Order下 (預設為0的情況)，依據Canvas.enabled為啟動狀態的先後順序。
亦即，越後啟動，顯示在越前面。

◎ Group 元件
http://docs.unity3d.com/Manual/class-CanvasGroup.html

Canvas 元件，預設無設定，此元件用途在於管理對子元件互動關係。
如整體透明度(Alpha)，是否可執行(Interactable)，是否列入事件系統(Block Raycasts)等。

◎ Layout 元件
http://docs.unity3d.com/Manual/comp-UIAutoLayout.html
Demo : LayoutAndEvent

預設情況下，Canvas為自由座標系統，但若需要顯示共同寬高的列表系統，Unity共有三個額外Layout可使用。

1. Horizontal
水平排列，輸入的單元為在水平方向擺放，可設定子物件間格( spacing )、物件邊界( Padding )。

2. Vertical
垂直排列，輸入的單元為在垂直方向擺放，可設定子物件間格( spacing )、物件邊界( Padding )。

3. Grid
網格排列，輸入的單元為依指定的起點，以固定的單格(Ceil)來放置子物件，並排放成格子狀。
可設定子物件間格( spacing )、物件邊界( Padding )、起始角( Start corner)、起始軸( Start axis )等。

Layout 在畫面動態比較強的遊戲設計上，用途會相對降低，但用於較為制式的選單介面仍有其使用價值。

◎ Component

※ 相關文章參考：
---------------------------
UI / UnityEditor.UI / UI / MenuOptions.cs
https://bitbucket.org/Unity-Technologies/ui/src/5fc21bb4ecf4b40ff6630057edaa070252909b2e/UnityEditor.UI/UI/MenuOptions.cs?at=4.6&fileviewer=file-view-default
---------------------------



