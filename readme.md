# Unity

## 學習目的

Unity 是當前遊戲產業用於設計遊戲的主要遊戲引擎之一，但由於 Unity 逐年變更其服務，近幾次的研究分在不同版本，並針對不同目的進行研究

### [Unity 4](./src/unity4)

初次研究 Unity 4，實際使用版本為 4.3，當時是基於 Flash 與 HTML5 世代交替，研究用於替代 Flash 的網頁與本地端使用者互動介面，但此時研究成果僅是適用而非詳細研究引擎機置。

### [Unity 5](./src/unity5)

基於公司需要重新調研 Unity 引擎，並考量用於設計跨平台的行動端遊戲引擎，本次調研更加針對整個核心與動態元件設計。

### [Unity Hub](./src/unityhub)

從官方文件顯示，自 2017 年起，Unity 5.6 之後的版本是採用雲端更新的 Unity Hub 開發工具匯入所需要的 Unity 版本，若要下載 5.x 以前的版本則需去[ Unity 版本備份](https://unity3d.com/get-unity/download/archive)中選擇指定的版本下載，亦可將備份版本匯入 Unity Hub 使用。

本次調研重點，除針對 Unity 5 以確認的核心與動態設計外，額外考慮關於 DevOps 中編譯程序與整合部屬相關技術的運用。

+ 開發面
  - 核心系統設定與撰寫
  - 動態物件與材質設計
  - 動畫系統設計
+ 整合面
  - 命令操作整理
  - 容器化編譯機制
  - 雲端編譯文件整理

## 文獻

+ 命令編譯
    - 官方文獻
        + [Command line arguments](https://docs.unity3d.com/Manual/CommandLineArguments.html)
        + [Installing the Unity Hub](https://docs.unity3d.com/2020.1/Documentation/Manual/GettingStartedInstallingHub.html)
    - 討論文章
        + [Automating Unity Builds — Part 1 : Unity via Command Line](https://fadhilnoer.medium.com/automating-unity-builds-part-1-ba0c60e8d06b)
