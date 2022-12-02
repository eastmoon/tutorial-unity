﻿◎ Loading Resources at Runtime

在特定情況下，專案的資源並不需要存在於場景內，而是在執行期間載入資源；例如有的角色模組不只是存在遊戲場景，也同時存在其他介面中。

此外，亦有情況是載入整份資材，從外部檔案或特定網址下載；並以此減少初始時的下載時間，讓下載與內容的規劃與設計更具有彈性。

◎ Resource Folder

資源檔案夾 ( Resource Folder ) 是一個資料儲存資料夾，其中存放著建置 ( 編譯 ) 過的Unity資源，並且沒透過IDE直接與特定遊戲物件 ( GameObject ) 連結。

要放置任何東西到資源檔案夾，只需要在專案夾內的建立一個名叫 "Resource" 的檔案夾。
如：Assets \ Resources 

若用其他方式建構資源資料夾，則需透過Resource.Load函數載入其資源內容。
如：載入名叫 "glass" 的材質檔案
{
	Texture glassTexture = Resources.Load("glass") as Texture;
}

如：載入並複製名叫 "enemy" 的預制 ( prefab ) 檔案
{
	GameObject instance = Instantiate(Resources.Load("enemy", typeof(GameObject))) as GameObject;
}

※ 相關文章參考：
---------------------------
Resources.Load
https://docs.unity3d.com/ScriptReference/Resources.Load.html
---------------------------

◎ Asset Bundles

Asset Bundle 是一個外部資材收集檔。
使用此檔案，可以將不同類別、用途的資材封裝，並將檔案放置在主場景檔案之外，在需要使用時才載回內容。
常用於網頁的動態載入，亦可用於軟體的動態更新機制。

※ 相關文章參考：
---------------------------
Loading Resources at Runtime
https://docs.unity3d.com/Manual/LoadingResourcesatRuntime.html

---------------------------

◎ Launching external application

※ 相關文章參考：
---------------------------
How to start an Android activity from a Unity Application?
http://stackoverflow.com/questions/10069340/how-to-start-an-android-activity-from-a-unity-application

Android/iOS: Launch from within a Unity app another Unity app
http://forum.unity3d.com/threads/android-ios-launch-from-within-a-unity-app-another-unity-app.222709/
---------------------------

◎ Load scene

透過場景讀取，切換場面，以此分割專案並減少冗餘物件。

1. 場景設置

專案中需載入的場景物件，必須先在Build Settings ( Ctrl + Shift + B )中設定並排序場景。
※ 排序在最上層的Scene即為軟體啟動時的第一個主場景。

2. 載入命令
{
	// 將場景載入，但不移除當前的場景內容
	UnityEngine.SceneManagement.SceneManager.LoadScene( [Scene name], LoadSceneMode.Additive );
	// 將場景載入，並移除當前所有的場景內容
	UnityEngine.SceneManagement.SceneManager.LoadScene( [Scene name], LoadSceneMode.Single );
}

場景控制除了載入還有多種用途，運用此可以適當的區分專案與整體運作方式。


※ 相關文章參考：
---------------------------
SceneManager
https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.html

Scene Management in Unity 5
http://www.alanzucconi.com/2016/03/23/scene-management-unity-5/

SceneManager LoadScene Additive AND Set Active
http://forum.unity3d.com/threads/scenemanager-loadscene-additive-and-set-active.380826/
---------------------------
