◎ Memory releasing 

● 問題

Unity中產生的物件，因系統可能存有監控之必要等可能性問題，並不會經過Garbage Collection (System.GC.Collect)處理；亦即及使用Clear或Remove等方式清除內容，也不會將物件刪除。

相關問題引發於動態AnimationClip增設，並於再次新增時刪除導致問題無法處理；如相關文獻說明。

○ 記憶體與執行監視

監視記憶體狀態與物件狀態，可使用 Window -> Profiler ( Ctrl + 7 )，並點擊記憶體 ( Memory ) 來監視其狀況。
其中可以看到AnimationClip的物件總數量。

● 解決方式

雖無法透過GC進行記憶體回收，但可利用手動方式移除。

1. GameObject.DestroyImmediate

使用此方式可直接將GameObject物件消滅，並依據其參數指定材質部分一併移除。
{
	GameObject.DestroyImmediate( [Target object], true);
}

2. Component

存在於GameObject內的Component，可以透過AddComponent來增加，卻無刪除命令；對此，可用運上述方式將特定元件移除。
{
	// Remove animation component in GameObject。
	Animation.DestroyImmediate( this.gameObject.GetComponent<Animation>(), true );
}

3. 動態 Animation 與 AnimationClip 的記憶體管理

原則上，Animation.AddClip命令，是複製AnimationClip到Animation物件內。
AnimationClip內的Curve，並無直接影響記憶體的變化(經觀察物件總數)，使用ClearCurve即可移除其中的資料。

對此，避免不必要的物件生成行為，但確保記憶體內多餘資訊可正確移除，僅需將複製的物件移除，並控制總AnimationClip物件為實際物件的兩倍 ( 管理用本體與執行用複製 )。

{
	// Take back target clip, if exist then destroy clip.
	if(this.[Animation Object].GetClip("MOVE_TO") != null)
		AnimationClip.DestroyImmediate(this.[Animation Object].GetClip("MOVE_TO"), true);
	// Add animation clip object in animation.
	this.[Animation Object].AddClip(this.[Animation Clip Object], "MOVE_TO");
	// Execute animation clip.
	this.[Animation Object].Play("MOVE_TO");
}

※ 相關文章參考：
---------------------------
Bug: Unity Not Releasing AnimationClips
http://forum.unity3d.com/threads/bug-unity-not-releasing-animationclips.129916/

Remove all clips from animation by script
http://answers.unity3d.com/questions/26119/remove-all-clips-from-animation-by-script.html
---------------------------