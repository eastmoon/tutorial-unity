◎ Project Structure

考量專案分工與設計整合，將專案製作區分為檔案夾歸類、封裝兩行為

◎ Project Folder
Reference : \Research-SoftwareTheory\1-3. Folder structure and namespace defined\
Reference : \GameRuleArchitecture\CSharp\

專案主要結構為：

AssetBundles
Editor
Resources
Prefabs
Scenes
Scources
    ├ Framework
    ├ Library
    └ Script

● AssetBundles
輸出外部材質，經由AssetBundles封裝完畢的材質檔案。
僅用於若材質需分隔與管理運作時使用

○ Editor
編譯器腳本，放置於此的程式用於改善編譯器的運作。

● Resources
資源檔案，放置於此的為圖檔、影片、模型等靜態物件檔案。

○ Prefabs
預製物件檔，Unity將產生好的遊戲物件、元件關係設置成的物件檔，可直接當成遊戲物件載入。
※ 注意，Prefab檔案其內存的程式碼、圖像是連結資訊，載入後連結資訊會自動對應到實際檔案。

○ Scenes
場景物件，Unity專案啟動是先場景後物件，因此場景內會封裝所有需要的物件與腳本程式連結。

● Scources
腳本程式，在此依據軟體專案架構文件區分。
1. Framework，本專案的主要框架；框架會依據專案做適當調整，而不可調整部分則方入Library中。
2. Library，C#、Unity的共用函式庫。
3. Script，專案場景、物件實際操作的腳本程式；依據需要應細分為UserInterface、Object2D、Object3D、Camera。
	‧UserInterface：使用者介面類別。
	‧Sprite：2D遊戲場景物件類別。
	‧Object：3D遊戲場景物件類別。
	‧Camera：遊戲內鏡頭；鏡頭應視遊戲情況而定去製作，此為非必要之項目。

◎ Project scene

考慮分工狀態，每個開發者會製作所屬部分項目，最後再由系統合併。

1. 專案項目檔案夾

假定專案項目名為『Game』，則其檔案夾結構如下：

Scenes
    └ Game.unity
Resources
    └ Game
        └ *.png
Scources
    └ Script
        └ Game
            └ UserInterface
                └*.cs
            └ Object2D
                └*.cs
            └ Object3D
                └*.cs
            └ Camera
                └*.cs

※ 注意，在此結構上，其名稱空間(Namespace)應符合同樣的結構
‧[Project].Game.UserInterface
‧[Project].Game.Object2D
‧[Project].Game.Object3D
‧[Project].Game.Camera

2. 封裝

以Packages工具，勾選所屬的專案夾、場景檔案。

3. 彙整

在彙整專案中，將Packages載入，並在啟動程式設定關聯以確保運作正常。

※ 相關文章參考：
---------------------------
Resources.Load
https://docs.unity3d.com/ScriptReference/Resources.Load.html
---------------------------
