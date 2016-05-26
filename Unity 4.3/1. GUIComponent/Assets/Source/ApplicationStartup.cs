using UnityEngine;
using System.Collections;

public class ApplicationStartup : MonoBehaviour {

	private int update_count;
	private Texture2D icon;

	private string gui_textContent; 

	// Use this for initialzation system.
	void Awake() {
		Debug.Log ("Application Awake Behaviour");
	}

	// Use this for initialization GameObject
	void Start () {
		Debug.Log ("Application Start Behaviour");
		this.update_count = 0;

		// Loading Textures.
		// Reference : http://answers.unity3d.com/questions/348982/resourcesloadpathname-as-texture-null-reference.html
		// Loading Texture by Assets path, unity editor only.
		#if UNITY_EDITOR
		//string texture = "Assets/Resources/Images/icon_resource_tool.png";
		//this.icon = (Texture2D)Resources.LoadAssetAtPath(texture, typeof(Texture2D));
		#endif

		// Loading Texture in Resources folder.
 		this.icon = Resources.Load ("Images/icon_resource_tool") as Texture2D;

		// Initial Text
		this.gui_textContent = "This is TextField";
	}
	
	// Update is called once per frame
	void Update () {
		if( this.update_count < 1 )
			Debug.Log ("Application Update Behaviour ... " + (++this.update_count));
	}

	// OnGUI is called once per frame.
	void OnGUI() {
		// GUI Reference : http://docs.unity3d.com/Manual/gui-Basics.html
		// Make a TextField
		this.gui_textContent = GUI.TextField (new Rect (10, 10, 210, 20), this.gui_textContent);

		// Make a background box
		GUI.Box(new Rect(10,40,100,150), "Loader Menu");

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,70,80,20), "Level 1")) {
			//Application.LoadLevel(1);
			Debug.Log("Click Button Level 1");
		}
		
		// Make the second button.
		// Repeat button will respond every frame that the mouse button remains depressed.
		if(GUI.RepeatButton(new Rect(20,100,80,20), "Level 2")) {
			//Application.LoadLevel(2);
			Debug.Log("Click Button Level 2");
		}

		// Make the thrid button, and content is texture	.
		if (GUI.Button (new Rect (20, 130, 80, 40), this.icon)) {
			print ("you clicked the icon");
		}

		// Make a content, it could have text, image, tip.
		GUI.Box (new Rect (120,40,150,50), new GUIContent("This is text", this.icon));
		// This line feeds "This is the tooltip 1" into GUI.tooltip
		GUI.Button (new Rect (120,100,150,20), new GUIContent ("Click me", "This is the tooltip 1"));
		// This line feeds "This is the tooltip 2" into GUI.tooltip and given button text, image.
		GUI.Button (new Rect (120,130,150,20), new GUIContent ("Click me", icon, "This is the tooltip 2"));
		// This line reads and displays the contents of GUI.tooltip. Every frame just one element could given tip info.
		GUI.Label (new Rect (120,160,150,20), GUI.tooltip);

		// GUI Position setting.
		GUI.Box (new Rect (Screen.width - 100,0,100,30), "Top-right");
		GUI.Box (new Rect (0,Screen.height - 30,100,30), "Bottom-left");
		GUI.Box (new Rect (Screen.width - 100,Screen.height - 30,100,30), "Bottom-right");
	}
}
