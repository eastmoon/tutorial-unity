# Unity 核心流程

以 [Unity 5 - Core dynamic object](../../unity5/0.%20Core_dynamic_object) 研究為基礎，針對 Unity 6 與相關規範進行調查。

## 指令

+ ```do-dev.bat``` 啟動開發環境

## Unity UI 套件

在 Unity 5 中，[uGUI](https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/index.html) 是預設套件，但在 Unity 6 中則需在 Package 中指派引用才可正常運行；其設定方式如下：

+ 開啟[套件管理視窗](https://docs.unity3d.com/6000.3/Documentation/Manual/upm-ui.html) ( Window -> Package Management -> Package Manager )。
+ 點擊 ```+``` 符號並選擇 Install package from git URL。
+ 輸入 com.unity.ugui，並等待套件安裝完成。
+ 檢查 [Packages](./app/Packages/manifest.json) 確認套件設置完成。

## 動態取得遊戲物件

基於物件導向程式設計的觀念，動態取回遊戲物件符合 SOLID 原則 ( 單一職責、開放封閉、里氏替換、接口隔離、依賴反轉 )，然而如何基於名稱正確調用目標仍是值得探討的技術。

詳細執行範本參考腳本 [ApplicationStartup](./app/Assets/_DynamicObject/Sources/Script/ApplicationStartup.cs) 的 DoSceneRetreive 函數。

### Find object by compoennt type

```
GameObject.FindFirstObjectByType<component type>();
```

[FindFirstObjectByType](https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Object.FindFirstObjectByType.html) 可經由指定型態來產生相應的遊戲物件。

需要注意，可以被調用的必需是 GameObject 所知的型態。

### Find object by name

```
GameObject.Find(string objectName)
```

[GameObject.Find](https://docs.unity3d.com/6000.3/Documentation/ScriptReference/GameObject.Find.html) 是透過取得目標名稱遊戲物件，且必需為活動狀態。

在 Unity 中，遊戲物件的活動 ( active ) 狀態，是根據物件是否在場景中啟用和運行，亦可解釋若要基於此方式僅能在進入 Hierarchy 的場景尋找。

```
(GameObject.Find(string objectName)).GetComponent<component type>();
```

此方式則是結合前兩者，先基於名稱取回遊戲物件，再從其中調回指定的型態的遊戲物件。

```
(GameObject.Find(string objectName)).GetComponentInChildren<component type>();
```

此方式也是基於遊戲物件名稱取回目標，但會取回遊戲物件中擁有特定型態的子物件。

```
# 取得 UILibrary 遊戲物件，並回傳其中的 Button 型態物件
GameObject.Find("UILibrary").GetComponentInChildren<Button>();
# 取得 DefaultButton 遊戲物件並回傳 Button 型態物件
GameObject.Find("DefaultButton").GetComponent<Button>();
# 取得 UILibrary 下的 DefaultButton 遊戲物件並回傳 Button 型態物件
GameObject.Find("/UILibrary/DefaultButton").GetComponent<Button>();
```

### Find object in other scene

```
await SceneManager.LoadSceneAsync("Assets/TargetScene/scene.unity", LoadSceneMode.Additive);
```

[LoadSceneAsync](https://docs.unity3d.com/6000.3/Documentation/ScriptReference/SceneManagement.LoadSceneMode.html) 可以透過載入指定場景，在遵照前面的方式取回場景中的遊戲物件。

需要注意，雖然在 Hierarchy 可以不設定此場景存在，但必需設定於編譯的場景列表中 ( File -> Build Profile -> [Target Platform] -> Open Scene List -> Add Open Scenes)。

此外，LoadSceneAsync 是個非同步函數，在 MonoBehaviour 的事件中 Start、Update 並無法等待場景完成動作後做相應行為，若要等待完成後執行需使用回呼 ( Callback ) 或事件 ( Event )。

### Find object in AssetBundle

AssetBundle 是一種歸檔文件，可用於將資源組合在一起以建立可下載內容 (DLC)，或減少應用程式的初始安裝大小。
> From [Introduction to AssetBundles](https://docs.unity3d.com/6000.3/Documentation/Manual/AssetBundlesIntro.html)

其包括以下特性：

+ 可將資源 ( Assets ) 包裝至針對特定平台的包裝檔。
+ 不同作業系統的包裝檔，無法供給其他作業系統載入。
+ 可於需要時間載入資源，減少記憶體消耗。

資源包使用步驟如下：

+ [Build the Scene AssetBundle](https://docs.unity3d.com/540/Documentation/Manual/BuildingAssetBundles.html)，在各資源的 Inspector 下方的 AssetsBundle 選擇要打包檔名，並建立打包指令與腳本，參考 [AssetBundlesPlugin](./app/Assets/Editor/AssetBundlesPlugin.cs)。
    - 若要用腳本形式添加資源包，參考 [BuildPipeline.BuildAssetBundles](https://docs.unity3d.com/ScriptReference/BuildPipeline.BuildAssetBundles.html) 的範本。
+ [Load the AssetBundle](https://docs.unity3d.com/6000.3/Documentation/ScriptReference/AssetBundle.LoadFromFile.html)，在程式啟動後，透過載入資源包檔案，系統會將所有資源放進執行管理的記憶中。
+ Load the Scene，載入包後，即可透過前述的場景 ( Scene ) 載入機制將資源調用至 Hierarchy 的列表。

## 複製與重構遊戲物件

Unity 對於動態遊戲物件的處理方式，除了前述載入資源外，也可以透過新建與複製方式產生新的遊戲物件，並透過添加 Componet 與修改參數來建立新遊戲物件。

詳細執行範本參考腳本 [ApplicationStartup](./app/Assets/_DynamicObject/Sources/Script/ApplicationStartup.cs) 的 DoAdditionGameObject 函數。

### New GameObject

簡單來說就是建立空白的遊戲物件 ( GameObjec ) 與添加需要的元件 ( Component )，其句型結構如下：

```
GameObject obj = new GameObject();
obj.AddComponent<component type>();
```

### Instantiate

動態產生空白元件，可以完全自定義一個新元件，但也因此會需填寫異常瑣碎的大量細項設定。

因此，複製存在於場景的元件，在基於戲要細項調整會比較契合設計師習慣，也可以避免設定綴碼。

```
GameObject obj = Object.Instantiate(origin object instance);
```
