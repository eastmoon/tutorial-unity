# Windows 環境執行 Command-Line interface

## Unity Hub

參考 unityci/hub 的設計，基於 Windows 命令列說明設計 unity-hub.bat 執行檔。

### 常用指令

+ ```unity-hub help``` 顯示 Unity Hub 指令說明
+ ```unity-hub editors -i``` 顯示 Unity Hub 安裝的 Editor
+ ```unity-hub install-path -g``` 顯示 Unity Hub 安裝的 Editor 目錄
+ ```unity-hub install-path -s [path]``` 設定 Unity Hub 安裝的 Editor 目錄
+ ```unity-hub install -v [version] -c [changeset] -m [module-short-name]``` 安裝編輯器模
+ ```unity-editor --version``` 確認版本資訊
+ ```unity-editor -createProject [ProjectPath]``` 建立空白專案

### 安裝環境

可安裝版本參考 ```unity-hub editors -r```，但 changeset 則參考 [Unity download archive](https://unity.com/releases/editor/archive)。

依照 unityci 的步驟，系統是先安裝利用 version、changeset 安裝 editor 核心，在使用 version module 安裝發佈模塊。

+ 安裝 Editor version 6000.3.3f1
```
unity-hub.bat install --version 6000.3.3f1 --changeset ef04196de0d6
```

+ 安裝 WebGL Build Support: webgl 模組
```
unity-hub.bat install-modules --version 6000.3.3f1 --module webgl --childModules
```

### 登入環境

```
"%UNITY_APP%" -- ^
  -username "$UNITY_EMAIL" ^
  -password "$UNITY_PASSWORD" ^
  -manualLicenseFile "%PROGRAMDATA%\Unity\Unity_lic.ulf" ^
  -projectPath "%PROJECT_PATH%"
```

### 執行異常

在實裝測試中，不同環境出現以下問題

#### Unity Hub 快取存取拒絕

```
[3676:0109/202727.175:ERROR:net\disk_cache\cache_util_win.cc:25] Unable to move the cache: 存取被拒。 (0x5)
[3676:0109/202727.176:ERROR:net\disk_cache\disk_cache.cc:236] Unable to create cache
```

建議先關閉啟動中的 Unity Hub 並執行快取清除 ```rd /S /Q %APPDATA%\UnityHub```。

#### Unity Editor 執行失敗

```
code execution cannot proceed because Unity.dll failed to load
```

經 AI 文獻提供，進行以下步驟確認：

+ 配置防火牆沒有預設阻擋 ( Configure Antivirus/Windows Defender Exclusions )
+ 參考 [minimum system requirements](https://docs.unity3d.com/6000.3/Documentation/Manual/system-requirements.html) 環境需求文獻更新系統版本
+ 安裝或更新 [Microsoft Visual C++ Redistributables](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist)，此套件用途為執行 C / C++ 程式
