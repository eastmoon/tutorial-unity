using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ImageScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // Retrieve UI component and setting event.
        Image img = this.gameObject.GetComponent<Image>();

        // Retrieve EventSystem
        EventTrigger et = this.gameObject.GetComponent<EventTrigger>();
        if (et == null)
            et = this.gameObject.AddComponent<EventTrigger>();

        // Create event entry
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener(this.OnPointerClick);

        // Setting event
        et.triggers.Add(entry);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    // OnPointerClick is called when EventSystem is trigger event.
    public void OnPointerClick(BaseEventData _eventData)
    {
        Debug.Log("OnPointerClick Image");
    }
}
