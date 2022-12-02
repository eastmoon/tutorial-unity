using UnityEngine;
using System.Collections;

public class ApplicationStartup : MonoBehaviour {

	private bool isUpdate;

	// Use this for initialzation system.
	void Awake() {
		Debug.Log ("Application Awake Behaviour");
	}

	// Use this for initialization GameObject
	void Start () {
		Debug.Log ("Application Start Behaviour");
		this.isUpdate = false;

		//TestClass tc = new TestClass ();	
	}
	
	// Update is called once per frame
	void Update () {
		if (!this.isUpdate) 
		{
			this.isUpdate = true;
			Debug.Log ("Application Update Behaviour");
		}
	}
}
