using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class CanvasScript : MonoBehaviour {

    // Use this for initialization
    public void Start () {
        // Retrieve UI component and setting event.
        Canvas can = this.gameObject.GetComponent<Canvas>();

        // Retrieve EventSystem
        EventTrigger et = this.gameObject.GetComponent<EventTrigger>();
        if(et == null)
            et = this.gameObject.AddComponent<EventTrigger>();

        // Create event entry
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener(this.OnPointerClick);

        // Setting event
        et.triggers.Add(entry);
	}

    // Update is called once per frame
    public void Update () {

	}

    // OnPointerClick is called when EventSystem is trigger event.
    public void OnPointerClick(BaseEventData _eventData)
    {
        Debug.Log("OnPointerClick Canvas ");
    }
}
