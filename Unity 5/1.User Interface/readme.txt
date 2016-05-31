◎ User Interface

◎ Structure

Unity 5的UI系統，採用的是階層式結構，以Canvas為根，UI Object為點。
在單一個場景內可擁有複數的Canvas，並以Canvas.enabled作為顯示開關。
此外，當建立場景內的第一個Canvas，會同時建立對應的EventSystem，並以此來擷取各類操作裝置的輸入。

※ 設計上，傳統的Unity 5以下版本，其UI系統多為禁用，應避免涉及相關內容。
※ 設計上，若要設計3D UI，將Canvas -> Render Mode -> Screen Space - Camera，藉此透過特定攝影機輸出內容。
※ 相關文章參考：
---------------------------
http://docs.unity3d.com/Manual/UICanvas.html
---------------------------

◎ 解析度，Screen Resolutions
Demo : ScreenResolutions

預設上，Canvas其長寬等同於可顯示螢幕的尺吋，若要修改其尺寸有以下兩種方式：

1. Canvas Scaler

Scaler是以縮放的方式調整Canvas的輸出比例，以及子物件的相關比例。

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
---------------------------

◎ 對位與尺寸

所有的UI Object皆擁有Rect Transform與Anchor presets兩個重要參數系統。
Rect Transform：UI Object的位置、尺寸等基本資訊。
Anchor presets：UI Object的對位方式。

透過這兩項參數系統的設定，可使登記於Canvas內的子元件，在Canvas因外力導致最大尺寸變動時，仍可保持元件的相對比例與大小。


※ 相關文章參考：
---------------------------
Rect Transform
http://docs.unity3d.com/Manual/class-RectTransform.html

Basic Layout
http://docs.unity3d.com/Manual/UIBasicLayout.html
---------------------------


