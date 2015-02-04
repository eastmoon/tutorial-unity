using UnityEngine;
using System.Collections;
using Easing;
public class WatermarkTween : MonoBehaviour
{
	private Tween m_tween;
	// Use this for initialization
	void Start ()
	{
		this.m_tween = null;
		//Debug.Log (this.name + " " + this.gameObject.activeSelf);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Rect temp = this.guiTexture.pixelInset;
		if (this.m_tween != null) 
		{
			temp.x = (float)this.m_tween.Run ();
			this.guiTexture.pixelInset = temp;
		}
	}

	public void RunAnimate( Tween a_tween)
	{
		this.m_tween = a_tween;
	}
}

