# Hello world

## 指令

+ ```do-dev.bat``` 啟動開發環境

## 專案結構

依據空白專案的內容，並依據 Unity 5 的專案結構相比對，與參考 [Best practices for organizing your Unity project](https://unity.com/how-to/organizing-your-project) 對其專案結構說明。

### 基礎結構

```
app/
├── Assets
├── Library
├── Logs
├── Packages
├── ProjectSettings
├── Temp
└── UserSettings
```

+ ```Assets``` 專案資源，包括程式碼、圖像、影片、聲音的素材存放位置。
+ ```Library``` Unity 專案本機的緩存，儲存 Unity 從來源資源 ( Assets ) 處理的所有資料；此目錄用於提升效能與建置速度，於版本控制中可以忽略。
+ ```Logs``` Unity 專案日誌的儲存目錄。
+ ```Packages``` Unity 專案引用的套件 ( Packages )，由[套件管理器 (UPM)](https://docs.unity3d.com/6000.3/Documentation/Manual/upm-ui-install.html) 管理的自包含模組化單元；詳細結構參考 [Package layout for UPM packages](https://docs.unity3d.com/6000.3/Documentation/Manual/cus-layout.html)。
+ ```ProjectSettings``` Unity 專案的配置資料，設定可透過 Unity 編輯器中的「專案設定」視窗進行管理，對於專案成員協作至關重要。
+ ```UserSettings``` Unity 專案對 Unity 編輯器的本機使用者設定檔，這些設定僅適用於使用者主機，於版本控制中可以忽略。

### 資源結構

對於資源 ( Assets ) 的目錄結構，並無絕對的規範，在此根據 [themorfeus/unity_project_structure](https://github.com/themorfeus/unity_project_structure) 提出的規範設計：

```
Assets/
├── _ProjectName/     # 使用 "_" 符號，確保專案目錄至於頂部
│   ├── Animations/   # 動畫資源
│   ├── Audio/        # 音樂資源
│   ├── Editor/       # 編輯器執行
│   ├── Materials/    # 材質
│   ├── Models/       # 模型物件
│   ├── Prefabs/      # 預製物件
│   ├── Scenes/       # 場景物件
│   ├── Sources/      # 程式碼
│   ├── Sprites/      # 2D 圖像
│   └── Textures/     # 3D 紋理
└── Plugins/          # 額外 plugins 函示庫
```

+ 專案項目的內容都應儲存在 ```Assets``` 資料夾內的一個子資料夾中，該子資料夾的名稱為專案名稱，並加一個下劃線符號 "_" 來確保該子資料夾位於資料夾結構頂部。
+ 除專案資料夾外，還有通用於所有專案項目的資料夾，例如 Plugins、Resources 等。
+ 專案項目的資源應分門別類存放於相應的資源目錄。
+ 若僅有一個專案，則應移除 ```_ProjectName``` 資料夾，將資源資料夾移至 ```Assets``` 資料夾。
+ 若存在複數專案，且專案間共用一個系列的模型、資源，則應建立 ```General``` 資料夾，專門存放相應的資源。
```
Assets/
├── General/          # 通用資源目錄
│   ├── Audio/        # 音樂資源
│   ├── Materials/    # 材質
│   ├── Sprites/      # 2D 圖像
│   └── Textures/     # 3D 紋理
```
+ 若存在特定內容，且內容由複數資源組成一個模組，則應建立 ```Modules``` 資料夾，依據模組名稱分們儲存。
```
Assets/
├── Modules/          # 通用資源目錄
│   ├── Audio/        # 音樂資源
│   ├── Materials/    # 材質
│   ├── Sources/      # 程式碼
│   ├── Sprites/      # 2D 圖像
│   └── Textures/     # 3D 紋理
```
+ 確定一種模型匯入格式 ( 例如 FBX )，並堅持使用，避免不同的匯入方式導致載入時間序難以管理。
+ 避免建立未使用的資料夾，造成協作混亂。
