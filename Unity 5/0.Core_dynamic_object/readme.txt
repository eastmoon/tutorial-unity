◎ Object structure
Demo：DynamicObject

在Unity中，所有存在於Scene內的物件皆為GameObject，而不同用途的GameObject是取決於崁入其中的Componenet。

Scene
└ GameObject_1
	└ Component_1
	└ Component_2
└ GameObject_2
	└ Component_1

◎ Retrieve object

1. Find object by compoennt type

GameObject.FindObjectOfType<component type>();

取得並取回指定型態的物件。
若有複數，改用FindObjectsOfTypeAll，這將回傳儲存所有同型態物件的列表。

※ 此方式會回傳Component type，並非GameObject本身，若要操作則需另外呼叫屬性。

2. Find object by name

GameObject.Find(string objectName)

取得名稱相同的物件。

(GameObject.Find(string objectName)).GetComponent<component type>();

若取回內容需要轉型為Component，以此方式轉型為指定的型態。

※ 相關文章參考：
---------------------------
尋找物件的方法 各種的Find
http://theunity3d.blogspot.tw/2012/04/find.html

Finding Cameras
http://answers.unity3d.com/questions/15801/finding-cameras.html

GameObject.GetComponent
https://docs.unity3d.com/ScriptReference/GameObject.GetComponent.html
---------------------------


◎ Dynamcie Object

概念上，Unity的處理方式，應該是先以Object Resource中取得指定名稱的物體，並加以複製於場景內。
但如結構描述所說，實際上共有兩種方式動態產生物件。

1. New GameObject

簡單來說就是建立空白的GameObject，並自行添加需要的Component。

GameObject obj = new GameObject();
obj.AddComponent<component type>();
...

2. Instantiate

複製存在的元件，雖然可以依據需求動態產生空白元件，但產生過程的細項設定異常瑣碎。
考量設計師習慣，避免設定綴碼，使用複製元件，並調整細項，會是比較適當的運作方式。
※Instantiate為靜態變數，不屬於任何物件。

GameObject obj = Object.Instantiate(origin object instance);

※ 動態物件階層結構化
預設上，方式1、2產生的物件皆是儲存在Scene的Root位置。
若要改變位置，使用Transform來設定物件的階層關係。

obj.transform.SetParent( parent object tramsform );

※ 相關文章參考：
---------------------------
Creating and Destroying GameObjects
http://docs.unity3d.com/Manual/CreateDestroyObjects.html

Object.Instantiate
http://docs.unity3d.com/ScriptReference/Object.Instantiate.html

How to dynamically create an UI text Object in Unity 5?
http://gamedev.stackexchange.com/questions/116177/how-to-dynamically-create-an-ui-text-object-in-unity-5
---------------------------
