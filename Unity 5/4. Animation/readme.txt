◎ Unity 5 
http://unity3d.com/cn/learn/tutorials/topics/animation

◎ Tween & Animate

Unity中控制動畫共有下列主要物件：

Animator 控制並撥放一個 AnimationClip
Animaion 控制一個Controller ( GameObject )內擁有的複數個 AnimationClip
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

◎ AnimationCurve and Clip
Demo : AnimationCurve&Clip
https://docs.unity3d.com/ScriptReference/AnimationCurve.html
https://docs.unity3d.com/ScriptReference/AnimationClip.html
http://docs.unity3d.com/ScriptReference/Keyframe.html

1. 關係

對一個動畫設定並執行的理想構成：
物理運動公式、運動曲線、運算元集合

理想結構上，透過物理運算公式以及參數( 起始值、終止值、所需時間 )產生運動曲線。
在將複數個運動曲線( 每個曲線對應一個物件屬性 )做成集合，並統一執行。 

而在Unity，其實際構成：
運動曲線、運算元集合

使用者透過設定好運動曲線( 起始值、起始時間、終止值、終止時間 )，構成一個平滑( Smooth )、線性( Linear )、進出緩衝( EaseInOut )的運動路徑。
在將複數個運動曲線( 每個曲線對應一個物件屬性 )做成集合，交付動畫執行管理物件( Animation、Animator )來做執行管理。
 
2. 動態程式控制

2.1 基本構成

A. 建立與設定運算曲線

{
	// 建立
	AnimationCurve curve = new AnimationCurve();
        // 設定曲線關鍵點
	curve.AddKey(new Keyframe(0, 0, 0, 0));
        curve.AddKey(1, 100);
	// 指定曲線輸出在時間為0.5的數值
	curve.Evaluate(0.5)
}

B. 建立與設定運算元集合

{
	// 建立
	AnimationClip clip = new AnimationClip();
	// 設定動畫為舊有系統，亦即供給Animation，而非Animator
	clip.legacy = true;
	// 設定運動曲線與關聯，設定對物件區域座標X軸，依據曲線數據改變
        clip.SetCurve("", typeof(Transform), "localPosition.x", curve);
}

C. 動畫管理物件

Unity的動畫共有兩種管理物件，且皆為物件( MonoBehaviour )的元件( Component )。
Animation：將運算元集合，以名稱方式歸類；在需執行時呼叫其名。
Animator：本質與Animation相同，但視每個運算元為狀態，而狀態間存在著關係並連動運作著。

{	
	// 取得動畫管理物件 Animation
	Animation anim = [targetObject].GetComponent<Animation>();
	// 若不存在則新增 Animation
	if (anim == null)
		anim = [targetObject].gameObject.AddComponent<Animation>();
}

2.1 時間計算

動畫系統中，設定動畫所有的時間數值皆為秒，系統會依據當下的FPS切換成對應Frame的當下值，以確保運算結果符合時間需求。

預設上，Unity內定的FPS為依據對應裝置的重繪效能調整，約在50到60FPS( Frame per Second )間。
但亦可使用Application.targetFrameRate設定其FPS為定值。

2.2 切線(Tangent)計算 

平滑( Smooth )運動曲線，是以貝茲曲線計算其平滑線段。
使用Animation View( Windows => Animation )可以觀察其操作方式。

為了調整其平滑狀態，對單一關鍵點設定切線(Tangent)，即可改變曲線的平滑方向。

Keyframe(Time, Value, InTangent, OutTangent)

針對曲線的關鍵點，可以用上數據結構定義。
然而，依據文件調查，切線(Tangent)是一個介於正負6000的數據，因此若要設計或動態調整可參考相關文件說明。

3. Curve、Tween，動態產生曲線物件。
Demo : AnimationCurve&Clip_byEasing

在Unity的設計上，雖然可以用切線來調整曲線的平滑狀況，但過於特殊的Easing曲線並無法實踐。
且以數學運算是計算的Easing，並不易反算為具有切線的關鍵點。

因此，利用Unity內平滑曲線的運算方式，並對Easing function取樣方式，來模擬整條曲線的實際樣貌。
但須注意，依據不同的曲線結構，取樣的密度會決定該線段的樣貌；取樣少，會利用Unity補完所需曲線，但這曲度未必符合Easing本身樣子。
在理想上，若FPS在60的情況，1秒的曲線至少需取樣60個點，亦即每0.0167秒取樣一次；若30FPS，則為0.033秒。
若選擇瞬間變動幅度大的Easing，可以看到曲線的垂直幅度變化會受到取樣方式而變動。

※ 基於AnimationCurve為密封類別，無法透過繼承複寫函數運作。
※ 基於物件導向設計，物件行為函數無法透過外部指派函數取代。

3.1 Easing、Cubic-Bezier 曲線轉換工具
Demo : EasingCurve

Easing：Easing函數集合物件。
	- Easing.EaseFunctionType，Easing函數型態

EaseCurve：將Easing函數轉換為AnimationCurve物件。

● 單一Easing函數的AnimationCurve

此方式產生的函數，其時間的間隔固定，但Easing函數依據時間輸出對應的當前值。

AnimationCurve curve = EaseCurve.Ease( Easing.Function, Start Value, Start Time, End Value, End Time );

○ 複數Easing函數的AnimationCurve

此方式產生的函數，其時間、數值皆依據Easing函數變動。
典型上可以對兩軸(時間、數值)各設定一個Easing函數，但實際用途並不大。
不過，CubicBezier的計算方式，其四點輸入值，分別標示了函數在兩軸的變動；這部分應該從兩個方向來看。
	- 運動曲線，CubicBezier提供的數值是用兩軸方式產生運動曲線，這時產生曲線填入的運動曲線的時間並非固定間距，而是依據公式算出。
	- 運動結果，使用CubicBezier產生的運動曲線計算當前值，這時候的時間是依據FrameRate產生的固定時間間隔。

AnimationCurve curve = EaseCurve.Ease( Easing.Function Array, Start Value, Start Time, End Value, End Time );
AnimationCurve curve = EaseCurve.Ease( Easing.CubicBezier( Point1.time, Point1.progress, Point2.time, Point2.progress ), Start Value, Start Time, End Value, End Time );

※ 相關文章參考：
---------------------------
AnimationClip.SetCurve
http://docs.unity3d.com/ScriptReference/AnimationClip.SetCurve.html

Application.targetFrameRate
http://docs.unity3d.com/ScriptReference/Application-targetFrameRate.html

Editing Curves
http://docs.unity3d.com/Manual/EditingCurves.html

EditorAnimationCurveExtension
http://wiki.unity3d.com/index.php/EditorAnimationCurveExtension

Create a Sprite Animation Clip in Code
http://answers.unity3d.com/questions/694546/create-a-sprite-animation-clip-in-code.html
http://answers.unity3d.com/questions/331268/a-simple-animation-clip-scripting-control-example.html

How can I convert AnimationCurve.in/outTangent to an angle
http://answers.unity3d.com/questions/48590/how-can-i-convert-animationcurveinouttangent-to-an.html
http://answers.unity3d.com/questions/146760/how-do-i-modify-a-keyframecurves-tangent-in-code.html

Interpolate
http://wiki.unity3d.com/index.php?title=Interpolate

Custom Easing functions
http://forum.unity3d.com/threads/custom-easing-functions.293141/

Easing函數 CSS
http://easings.net/zh-tw

Cubic Bezier
http://cubic-bezier.com/#.17,.67,.83,.67

抽象和密封類別以及類別成員
https://msdn.microsoft.com/zh-tw/library/ms173150.aspx

Bézier Curves for your Games: A Tutorial
http://devmag.org.za/2011/04/05/bzier-curves-a-tutorial/

