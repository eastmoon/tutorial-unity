◎ Unity 5 
http://unity3d.com/cn/learn/tutorials/topics/animation

◎ Tween & Animate

Unity中控制動畫共有下列主要物件：

Animator 控制並撥放一個 AnimationClip
Animaion  控制一個Controller ( GameObject )內擁有的複數個 AnimationClip
AnimationClip 擁有對象參數的 AnimationCurve
AnimationClip 擁有對象參數的 AnimationEvent
 
※ 相關文章參考：
---------------------------
http://docs.unity3d.com/ScriptReference/AnimationClip.html
http://docs.unity3d.com/ScriptReference/AnimationCurve.html
http://docs.unity3d.com/ScriptReference/AnimationEvent.html
---------------------------
 
動畫處理，意指對物件( GameObject )的公開屬性，進行隨時間單位改變的數據操作。
 
舉例來說，如對一個2D圖像進行橫向移動。
object.x = EasingFunction( easing type, easing value, current time, duration time ) + object.x
 
這是一個隨時間改變的計算公式，其輸出單位值介在0到1之間。
y = F(type, value, current, duration) + x
 
在Unity中，這動作則是由AnimationCurve執行。
AnimationCurve 等同 Easing Function，但僅有Linear、EaseInOut、BezierPoint三種；典型的Tween物件則是以數學式完成各類EaseInOut公式。
在實務運用上可選擇的動作類型不多，且過度著重於操作，而非動態程式設計。因此若有需要仍需取用Tween物件，或重設計一套可共用的物件。
※ 若使用Animation介面操作，其內部曲線皆以BezierPoint、EaseInOut自動設計。

 
另外，對於Unity的物件改變，因為GameObject設計問題，導致同屬性數值必須一同改變。
例如，移動座標X，實際必須重新設定整個Position物件，這部份導致運算難以公式化；亦即現行設計雖可對單一數據進行設定，但實際卻會動到相同屬性數據，這設計假設應考量在動畫運作不會只對單一軸改變為前提。
但也因此這設計，導致必須另外寫工具函數來修正各類屬性動作或多做設定。
 
 
動畫系統設計目的：
1. 隨時間單位改變的數據操作；物理運算式
- AnimationCurve、Tween
2. 複數物理運算式同步控制；動畫段
- AnimationClip
3. 多動畫段控制，將動畫段賦予狀態，以命令運作狀態
- Animation
4. 動畫段的狀態關聯控制，允許設定動畫段間的轉場 ( Fade-In、Fade-Out )
- Animator
 
雖然Animation的設計為legacy system，設計核心概念與Animator相同，但兩者使用方向與動態操作複雜度也不相同。
對於簡單的2D動作或3D圖像來說，Animator太過強大且沒必要，反而Animation的運用會比較簡單。
反過來，對於3D角色來說，Animation則太過陽春，反而需要活用Animator來讓角色更加自然。
 
可若著眼於簡單的UI轉場，僅需要運用到AnimationClip就已經極為複雜。
但對於AnimationCurve的過度簡亦設計與對物件屬性的配合設計，若有必要則需重新思考軟體架構來提高運用靈活與自由度。

◎ AnimationCurve

◎ AnimationClip



