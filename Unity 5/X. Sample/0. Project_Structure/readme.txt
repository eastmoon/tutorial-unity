◎ Project structure

軟體專案架構，其檔案結構如下述

● Framework
	├ Model
	├ View
	│  ├ Utility
	│  └ Builder
	├ Controller
	└ Core

框架，用於存放共用性強，但相依本專案的架構、物件樣式設計。
設計上，雖針對本專案開發，但其共用性設計上應考量可重複運用至相似專案的可行性。

View.Utility : 靜態公用函數，提供顯示物件所需的參數計算函數。
View.Builder : 建立工具物件，以Builder pattern混和Factory pattern，用於動態生產所需的顯示物件。

※ 相關文章參考：
---------------------------

---------------------------

○ Library
	├ EasingCurve
	└ Monitor

函式庫，用於存放第三方函式庫、單一用途工具物件。

※ 相關文章參考：
---------------------------

---------------------------

● Script
	├ Sprite
	└ UserInterface

專案主程式，區分為Sprite ( 二維空間 )、UserInterface ( 使用者介面 )。

※ 相關文章參考：
---------------------------

---------------------------