# 開發與發佈

## 指令

參考 00.windows-cli 專案設計 unity-editor.bat 的原則，設計相關指令

### 開發環境

指令 ```do-dev.bat``` 包括以下功能

+ 若專案目錄為空，建立一個空白專案
+ 基於 unity-editor 啟動專案

原則上專案並未登入帳號，因此需要啟動一次 Unity Hub 登入帳號。

### 發佈產品

在 Unity 的 CI/CD 運行中常見一個操作方式，是藉由 unity-editor 的參數 ```-executeMethod``` 執行一個整合腳本，用此實做編譯與部屬指令。

使用模組需注意以下事項：

+ 執行模組需放在專案目錄 ```Assets/Editor``` 內
+ 執行參數 ```-executeMethod [Class-Name].[Method-Name]```
+ 執行模組的檔名與類別名稱可不同
+ 執行方法必需是靜態 ( static )

模組範本可參考 [EditorApplication.Exit](https://docs.unity3d.com/2017.2/Documentation/ScriptReference/EditorApplication.Exit.html)，基礎結構如下：

```
using UnityEditor;
using UnityEngine;

public class ExecuteModuleClass
{
    // The method to be executed from the command line
    public static void Perform()
    {
        Debug.Log("Build completed successfully!");
    }
}
```

指令 ```do-pub.bat``` 包括以下功能：

+ 依據命令執行特定發布模組
+ 命令執行為背景模式
+ 執行記錄寫入 ```do-pub.log``` 檔案
