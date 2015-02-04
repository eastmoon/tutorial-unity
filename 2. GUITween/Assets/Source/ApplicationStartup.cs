using UnityEngine;
using System.Collections;
using Easing;

public class ApplicationStartup : MonoBehaviour {

	private string gui_from;
	private string gui_to;
	private string gui_duration;
	private int gui_selected;

	// Use this for initialzation system.
	void Awake() {
		Debug.Log ("Application Awake Behaviour");
	}

	// Use this for initialization GameObject
	void Start () {
		Debug.Log ("Application Start Behaviour");

		// Loading Textures.
		// Reference : http://answers.unity3d.com/questions/348982/resourcesloadpathname-as-texture-null-reference.html
		// Loading Texture by Assets path, unity editor only.
		#if UNITY_EDITOR
		//string texture = "Assets/Resources/Images/icon_resource_tool.png";
		//this.icon = (Texture2D)Resources.LoadAssetAtPath(texture, typeof(Texture2D));
		#endif

		// Initial Text
		this.gui_from = "0";
		this.gui_to = "500";
		this.gui_duration = "30";
		this.gui_selected = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}

	// OnGUI is called once per frame.
	void OnGUI() {
		// Make a background box
		GUI.Box(new Rect(10,10,310,150), "Control Menu");

		// Make a TextField for From
		GUI.Label (new Rect (15,30,50,20), "From");
		this.gui_from = GUI.TextField (new Rect (70, 30, 230, 20), this.gui_from);

		// Make a TextField for To
		GUI.Label (new Rect (15,60,50,20), "To");
		this.gui_to = GUI.TextField (new Rect (70, 60, 230, 20), this.gui_to);

		// Make a TextField for Duration
		GUI.Label (new Rect (15,90,50,20), "Duration");
		this.gui_duration = GUI.TextField (new Rect (70, 90, 230, 20), this.gui_duration);

		// toggle button
		string[] options = new string[] { "Linear", "BackEaseInOut", "CubicEaseOut" };
		Rect position = new Rect(330, 30, 300, 70);
		this.gui_selected = GUI.SelectionGrid(position, this.gui_selected, options, 1, GUI.skin.toggle);

		// Make a button to Run tween.
		if(GUI.Button(new Rect(120,120,80,30), "RUN")) {
			// Use GameObject to Find the target
			GameObject target = GameObject.Find("UnityWatermark");
			// Use SendMessage to call method in GameObject
			if( target != null )
			{
				Tween.Equations easing = Tween.Equations.Linear;
				switch( this.gui_selected )
				{
				default:
				case 0:
					easing = Tween.Equations.Linear;
					break;
				case 1:
					easing = Tween.Equations.BackEaseInOut;
					break;
				case 2:
					easing = Tween.Equations.CubicEaseOut;
					break;
				}
				target.SendMessage("RunAnimate", new Tween(easing,
				                                           double.Parse(this.gui_from),
				                                           double.Parse(this.gui_to),
				                                           double.Parse(this.gui_duration)));
			}
		}
	}
}
