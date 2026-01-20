# WebGL 應用程式

針對 Unity 6 發佈、執行相關規範進行調查。

## 指令

+ ```do-dev.bat``` 啟動開發環境
+ ```do-pub.bat``` 執行發佈指令
+ ```do-run.bat``` 基於發佈內容啟動運行環境

本項目範例，設計一個繞物運轉的鏡頭操作。

## 發佈

關於[編譯與發佈](https://docs.unity3d.com/Manual/building-introduction.html)可參考連結的官方文獻說明，簡略來說，Unity 編譯與發佈有兩個主要方式：

+ 使用編輯器，可參考[Create a build from the Editor](https://docs.unity3d.com/Manual/BuildSettings.html)

簡約來說是使用 ( File -> Build Profile )，在其介面中選擇 Platform 並設定需編譯的場景 ( Open Scene List )，在點擊下方的編譯或發佈。

+ 使用腳本，可參考[Customize the build pipeline](https://docs.unity3d.com/Manual/build-customize-build-pipeline.html)

參考 Editor 內的 [WebGLBuilder](./app/Assets/Editor/WebGLBuilder.cs) 的內容，此方式是透過腳本編寫編譯、發佈所需的內容，並透過如下指令運行：

```
[Unity_Editor_App] -- -quit -batchmode -logfile [DEVOPS_LOGFILE_PATH] -projectPath [PROJECT_PATH] -executeMethod WebGLBuilder.build
```
> Unity_Editor_App 依據不同作業系統會存在不同位置，且執行該指令必需經過授權驗證才可正常運作

## 執行

發佈 WebGL 的內容後，會儲存於 ```app/Build``` 目錄內，啟動 Nginx 伺服器即可運行該服務。

但需注意，由於 Unity 需下載數個檔案，為此 Nginx 需有相應設定確保檔案回傳的資訊正確，詳細資訊可參考 [Set up your Nginx server configuration for Web builds](https://docs.unity3d.com/6000.3/Documentation/Manual/web-server-config-nginx.html)。
