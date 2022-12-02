using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class CanvasMouseMoveScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        // Check if the left mouse button was clicked
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("Click Canvas Mouse Move.");
            }
        }
    }
}
