◎ 2D Game

Unity 2D 遊戲舞台的設計，是繼承自Unity 3D結構，以鏡頭拍攝固定方位、距離內的物件。
並以正交投影 ( Orthographic ) 方式的攝影機將之繪製。

◎ 解析度，Screen Resolutions
Demo : ScreenResolutions

在認知上，三度空間的輸出結果是依據攝影機內的兩項參數來決定：

1. 投影結果的輸出尺寸，此值可為固定、亦可為不固定。
	- 在Screen物件內有對應設定解析度的行為函數。

2. 投影機在空間中的尺寸，此值會影響到自空間中投影的面積。
	- 在設計輸出時，意會依據實際需求與比例設計攝影機的投影面。

這樣的設計，也對應於正交投影的相機內。
然而，不論三維空間或二維空間的計算，都會依存一個數值為比例量尺來計算。
在經過文件查閱後，可知在Unity內是以單元為基本單位，如PPU ( Pixels per Unit ) 是指每個像素對應多少單元。
對此，設定正交投影輸出共需下列兩個設定

1. Orthographic size = Screen.height / 2
	- 正交尺寸是指在投影機的高度半徑，應該切為幾個單元。
	- 單元為正方，寬度則會依此值往旁延伸；若設定失當會出現實際寬度無法以單元填滿。
	- 設定為實際影幕高度的一半，使單元總值等同於實際像素。

2. Image Settings => Pixels Per Unit = 1 ( 每個Unit等於1個Pixels )
	- 設定專案內影像的PPU。

在公式上，實際計算回如下式：

UPP ( Unit per Pixels ) = Screen.height / (OrthographicSize * 2)
PPU ( Pixels per Unit ) = 1

Output Image height = (Image.height / PPU) * UPP

若在Screen.height = 100、OrthographicSize = 5、Image.hegith = 10
Output Image hegith = (10 / 1) * 100 / (5 * 2) = 100

若在Screen.height = 100、OrthographicSize = 50、Image.hegith = 10
Output Image hegith = (10 / 1) * 100 / (50 * 2) = 10

※ 此項設計，在固定PPU情況下，可以透過改變UPP值調整整體畫面的比例尺。

※ 相關文章參考：
---------------------------
Screen
https://docs.unity3d.com/ScriptReference/Screen.html

Orthographic Camera Setup
https://indiehoodgames.wordpress.com/2013/07/27/orthographic-camera-setup/

Pixel Perfect Calculator for Orthographic Camera : Unity3D
https://indiehoodgames.wordpress.com/2013/07/27/pixel-perfect-calculator-for-orthographic-camera-unity3d/

How do you handle aspect ratio differences with Unity 2D ?
http://gamedev.stackexchange.com/questions/79546
---------------------------

◎ 投影狀態

Projection Toggles the camera’s capability to simulate perspective.
- Perspective：Camera will render objects with perspective intact.
- Orthographic：Camera will render objects uniformly, with no sense of perspective.

切換Projection可以切換當前視角為3D或2D，若保留3D模型並混用2D，可以造出類2.5D透視場景。

Camera.orthographic = true | false;
Camera.orthographicSize = {N ; N > 0};


