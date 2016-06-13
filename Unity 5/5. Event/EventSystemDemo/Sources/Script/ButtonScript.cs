using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    // Use this for initialization
    public void Start () {
        // Retrieve UI component and setting event.
        Button btn = this.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(this.OnClick);
	}

    // Update is called once per frame
    public void Update () {
	
	}

    // OnClick is called when button onClick event listener has captcha event.
    public void OnClick()
    {
        Debug.Log("OnClick Button");
    }
}
