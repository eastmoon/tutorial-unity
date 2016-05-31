◎ Startup
Demo : Startup
Demo : ApplicationStartup

Unity並無特定程式起點，而是以載入場景的物件依據各自的行動腳本( MonoBehaviour物件 )運作。
而場景內的物件本身可擁有多個行動腳本，亦即物件在同個腳本事件觸發時會依腳本先後順序觸發。

腳本物件本身有數個重要事件函數：

● 場景載入
- Awake：
This function is always called before any Start functions and also just after a prefab is instantiated. (If a GameObject is inactive during start up Awake is not called until it is made active.)

○ 在第一次更新(Update)
- Start：
Start is called before the first frame update only if the script instance is enabled.

● 頁間
- OnApplicationPause：
This is called at the end of the frame where the pause is detected, effectively between the normal frame updates. One extra frame will be issued after OnApplicationPause is called to allow the game to show graphics that indicate the paused state.

○ 更新
- Update： 
Update is called once per frame. It is the main workhorse function for frame updates.

● 繪製
- OnGUI：
Called multiple times per frame in response to GUI events. The Layout and Repaint events are processed first, followed by a Layout and keyboard/mouse event for each input event.

詳細運作事件可參考文件。
http://docs.unity3d.com/Manual/ExecutionOrder.html

※ 設計上，依據物件概念，物件行為各自負責屬於常規設計。
但軟體的運作仍會存在著唯一起始點、運算模型、共通資訊等設計必要。
因此，使用Singleton模式設計唯一化的Facade物件，並將此設定為鏡頭( Carmera )的腳本；一個場景必定存在一個鏡頭。
另外，使用Unity腳本系統的構成，啟動腳本與鏡頭運作腳本可分開撰寫，避免程式碼混淆。

◎ 層級
Edit -> Project -> Tags & Layers

每個存在於Unity專案結構內的物件皆有兩個重要屬性，Tags和Layers。
透過Layer，Unity用來管理物件所在區域。
Sorting layer用於2D，Layers則用於3D。

雖然Layer混用可以解決很多投影與貼圖材質來源，但在於3D空間構築與資料結構問題仍需要用Scene解決。
http://unity3d.com/cn/learn/tutorials/modules/beginner/live-training-archive/creating-a-scene-menu

但對於Scene的運用，在解讀上反倒有些是Flash中的多重swf檔使用；有需要才載入的材質庫或物件庫。
http://blogs.unity3d.com/2014/08/04/multi-scene-editing/

◎ Retrieve object
http://theunity3d.blogspot.tw/2012/04/find.html
http://answers.unity3d.com/questions/15801/finding-cameras.html
https://docs.unity3d.com/ScriptReference/GameObject.GetComponent.html

◎ Timeline
http://docs.unity3d.com/Manual/TimeFrameManagement.html

◎ Dynamcie Object
http://docs.unity3d.com/Manual/CreateDestroyObjects.html
概念上，Unity的處理方式，應該是先以Object Resource中取得指定名稱的物體，並加以複製於場景內。

但場景如何控制動態產生的物體並刪除，則需要細項考慮。

◎ Render Texture

It will place the camera’s view onto a Texture that can then be applied to another object. 
This makes it easy to create sports arena video monitors, surveillance cameras, reflections etc.

http://docs.unity3d.com/Manual/class-RenderTexture.html
https://www.youtube.com/watch?v=pA7ZC8owaeo

◎ Cameras with lower depth are rendered before cameras with higher depth.
數字越小，越先繪製。
而接下來問題是，如何設定在不同的可視世界。

http://docs.unity3d.com/ScriptReference/Camera-depth.html