# 事件系統

以 [Unity 5 - Event](../../unity5/5.%20Event) 研究為基礎，針對 Unity 6 與相關規範進行調查。

## 指令

+ ```do-dev.bat``` 啟動開發環境

## 事件系統

Unity 對於操控訊號共有三種類型的事件系統：

### Input

無論舊式的 [Input Manager](https://docs.unity3d.com/6000.3/Documentation/Manual/class-InputManager.html) 或 新式的 [Input System](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.18/manual/index.html)，都採用典型輸入處理迴圈處理。

```
void Update() {
    if (Input.anyKeyDown) {
        Debug.Log("Do something.");
    }
}
```

利用物件的生命週期函數 Start、Update 執行當下取值，並執行相應的行為或數值計算。

### DOM Level 1

作用於 MonoBehaviour 物件的事件函數，利用函數複寫( function override ) 將行為提供給 Unity Engine 與使用該腳本的遊戲物件。
由於事件函數其事件的發動皆有其條件來源，每個物件也只需對指定的函數發動行為即可。

例如：OnMouseDown 範例寫法。

```
public class ExampleClass : MonoBehaviour {
    void OnMouseDown() {
        Application.LoadLevel("SomeLevel");
    }
}
```

詳細可操控的事件函數參考 [MonoBehaviour](https://docs.unity3d.com/6000.3/Documentation/ScriptReference/MonoBehaviour.html)。

此外，依據文件內容描述，不同事件會對應不同的 Component，若該物件不擁有此項 Component 將無法觸發事件。

### DOM Level 2

事件偵聽( event listener )，使用 [UnityEvent](https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Events.UnityEvent.html) 為基底延伸的各類偵聽事件物件，這類事件系統用途在事件發動須執行的函數會在零或無限之間，要不是觸發但不行動，要就連動一群物件。

Unity 提供的 UnityEvent 是一種觀察者模式 ( Observer Pattern ) 的實踐，參考範例場景 _EventSystem 內的 [ApplicationStartup](./app/Assets/_EventSystem/Sources/Script/ApplicationStartup.cs)，其基本句型如下述：

```
void Start () {
    if (m_MyEvent == null)
        m_MyEvent = new UnityEvent();
    m_MyEvent.AddListener(OnEventTriggered);
}

void Update() {
    if (Input.anyKeyDown && m_MyEvent != null) {
        m_MyEvent.Invoke();
    }
}

void OnEventTriggered() {
    Debug.Log("Callback executed");
}
```

可以看到對 UnityEvent 並不認知事件的意義，而是指定事件的處理者，並基於 Input System 判斷觸發；而 Unity UI 則是根據此系統延伸出如下具體使用方式：

#### 預設事件

參考範例場景 _EventSystem 內的 [ButtonScript](./app/Assets/_EventSystem/Sources/Script/ButtonScript.cs)，其中 Button component 會自帶 OnClick 偵聽物件。

```
Button btn = this.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(this.[Function]);
```

#### 設定事件

參考範例場景 _EventSystem 內的 [CanvasScript](./app/Assets/_EventSystem/Sources/Script/CanvasScript.cs)，其中 Canvas 需建立並取回 [EventTrigger Component](https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-EventTrigger.html)，藉由此元件設定相關的事件型態與處理函數。

```
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
```

補充說明，原則上每個場景若使用 Unity UI 接收事件，則必需在此場景添加一個 [EventSystem](https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/EventSystem.html)。
