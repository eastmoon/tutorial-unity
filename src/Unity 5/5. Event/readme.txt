◎ Event System
Demo：EventSystemDemo

Unity系統共有兩種類型的事件系統：

1. DOM Level 1

函數複寫( function override )，這是作用於MonoBehaviour物件下，提供給Unity Engine操控的共通物件。
因此，其事件的發動皆有其條件來源，每個物件也只需對指定的函數發動行為即可。

例如：OnMouseDown範例寫法。
public class ExampleClass : MonoBehaviour {
    void OnMouseDown() {
        Application.LoadLevel("SomeLevel");
    }
}

※ MonoBehaviour物件的事件複寫條件：
OnMouseDown is called when the user has pressed the mouse button while over the GUIElement or Collider.

依據文件內容描述，不同事件會對應不同的Component，若該物件不擁有此項Component將無法觸發事件。
GUIElement：舊有使用者介面元件，改用UI元件取代，事件系統參考DOM Level 2。
Collider：碰撞框，物件本身須設定具備碰撞的範圍，此元件適用於2、3維場景內的物件。

※ 相關文章參考：
---------------------------
MonoBehaviour.OnMouseDown()
https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnMouseDown.html

How to detect mouse click on sprite?
http://answers.unity3d.com/questions/941276/how-to-detect-mouse-click-on-sprite.html
---------------------------

2. DOM Level 2

事件偵聽( event listener )，使用UnityEvent為基底延伸的各類偵聽事件物件。
這類事件系統用途在事件發動須執行的函數會在零或無限之間，要不是觸發但不行動，要就連動一對物件。
Unity的新式UI系統皆採用此方式，這類設計主要原因來自外部裝置觸發的事件，其牽動的相對介面問題多屬於動態設計。

此外，Unity的UI系統對事件偵聽有兩種模式
A. 預設事件，例如Button component會自帶OnClick偵聽物件。

{
	Button btn = this.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(this.[Function]);
}

B. 設定事件，例如Canvas帶有OnClick事件，這必須透過建立事件系統來規劃偵聽項目。

{
	// Retrieve EventSystem
        EventTrigger et = this.gameObject.GetComponent<EventTrigger>();
        if(et == null)
            et = this.gameObject.AddComponent<EventTrigger>();

        // Create event entry
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener(this.[Function]);

        // Setting event
        et.triggers.Add(entry);
}

※ 動態產生Canvas，事件系統偵聽異常問題：
http://answers.unity3d.com/questions/889908/i-created-an-ui-button-but-click-does-not-work.html

For a button to work you need the following in your scene

1. A button that is a child of a canvas object
2. The canvas object must have a GraphicRaycaster component
3. There must be an EventSystem object somewhere in your hierarchy.

有此內容可知，UI事件系統是依據GraphicRaycaster作為觸發，再由Canvas傳遞給其所擁有的子物件。
同理，若對場景物件使用EventSystem，Camera則需增加Physics 2D Raycaster與Physics Raycaster。

※ UnityEvent 物件

設計上，事件偵聽系統是以Observer為基底概念延伸的設計樣式。
而此物件等同於Observer中的Subject，但執行對象Observer的內容可設定。

※ 相關文章參考：
---------------------------
UI EVENTS AND EVENT TRIGGERS
http://unity3d.com/cn/learn/tutorials/topics/user-interface-ui/ui-events-and-event-triggers

UnityEvent
https://docs.unity3d.com/ScriptReference/Events.UnityEvent.html

Graphic Raycaster
http://docs.unity3d.com/Manual/script-GraphicRaycaster.html

EventSystem.IsPointerOverGameObject
https://docs.unity3d.com/ScriptReference/EventSystems.EventSystem.IsPointerOverGameObject.html

Unity’s (not so) new event system
http://unity-coding.slashgames.org/unitys-not-so-new-event-system/

How do you add an UI EventTrigger by Script ?
http://answers.unity3d.com/questions/854251/how-do-you-add-an-ui-eventtrigger-by-script.html

Unity 4.6 - Simple Tutorial, new Events System and Raycasters!	
http://unitydojo.blogspot.tw/2014/08/unity-46-simple-tutorial-new-events.html

UI How to apply OnClick handler for button generated at runtime (script)
http://answers.unity3d.com/questions/791573/46-ui-how-to-apply-onclick-handler-for-button-gene.html

OnClick on button from code
http://forum.unity3d.com/threads/onclick-on-button-from-code.264111/
---------------------------

◎ 穿透性

1. EventSystem穿透是依據最前者接收事件；UI系統使用。
	- Canvas間，Sort Order大者優先接收。
	- Canvas內的子物件，優先接收。

2. UI和場景物件事件系統為分開計算。
	- 同樣的點擊事件，UI和2D物件會同時收到訊息。 
	- 若場景物件亦使用EventSystem，則穿透性依據前述。

3. EventSystem穿透
	- 原則上不採行此方式，點擊優先執行為最前端的顯示元件。
	- 特殊狀況下考量背景介面仍需接收事件。
	- 使用EventSystem.IsPointerOverGameObject，獲得當前物件是否被觸擊；注意，滑鼠與觸控為不同操作方式。

{
	// Check if the left mouse button was clicked
        if (Input.GetMouseButtonDown(0))
            if (EventSystem.current.IsPointerOverGameObject())
                Debug.Log("Click");
}

※ 相關文章參考：
---------------------------
Graphics Raycaster of Unity; How does it work?
http://gamedev.stackexchange.com/questions/93592/graphics-raycaster-of-unity-how-does-it-work

Unity UI - Blocking clicks
https://www.youtube.com/watch?v=EVZiv7DLU6E

UI Clickthrough
https://www.reddit.com/r/Unity3D/comments/2pi0jj/46_ui_clickthrough/
---------------------------

