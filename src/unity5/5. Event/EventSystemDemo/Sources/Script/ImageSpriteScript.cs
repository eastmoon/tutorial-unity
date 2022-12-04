using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ImageSpriteScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    // OnMouseDown is called when the user has pressed the mouse button while over the GUIElement or Collider.
    public void OnMouseDown()
    {
        Debug.Log("OnMouseDown ImageSprite");
    }
}
