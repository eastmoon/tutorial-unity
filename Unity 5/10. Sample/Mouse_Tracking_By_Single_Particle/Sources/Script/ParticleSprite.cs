using UnityEngine;
using UnityEngine.EventSystems;
using Assets.Sources.Framework.EasingCurve;
using System.Collections;

public class ParticleSprite : MonoBehaviour {

    private AnimationClip mAnimClip;
    private Animation mAnim;

	// Use this for initialization
	void Start () {
        // New clip
        this.mAnimClip = new AnimationClip();
        this.mAnimClip.legacy = true;
        // Retrieve animation in GameObject, if animation component is not exist, then new a component.
        this.mAnim = this.gameObject.GetComponent<Animation>();
        if (this.mAnim == null)
            this.mAnim = this.gameObject.gameObject.AddComponent<Animation>();
        // Push clip in anim, and play
        this.mAnim.AddClip(this.mAnimClip, "MOVE_TO");
    }
	
	// Update is called once per frame
	void Update () {
        // Check if the left mouse button was clicked
        if (Input.GetMouseButtonDown(0))
        {
            //if (!EventSystem.current.IsPointerOverGameObject())
            {
                Camera cam = GameObject.Find("Main Camera").GetComponent<Camera>();
                if(cam != null) { 
                    Debug.Log("Click Canvas Mouse Move." + cam.pixelRect.width + " ," + cam.pixelRect.height);

                    /*
                    // Direct move.
                    this.gameObject.transform.localPosition = new Vector3(
                        Input.mousePosition.x - cam.pixelRect.width / 2, 
                        Input.mousePosition.y - cam.pixelRect.height / 2, 
                        0);
                        */

                    // Easing Curve animation
                    // 0. Remove all curve
                    this.mAnimClip.ClearCurves();
                    // 1. New curve and clip
                    AnimationCurve animCurveX = new AnimationCurve();
                    AnimationCurve animCurveY = new AnimationCurve();
                    // 2. Set a curve     
                    animCurveX = EaseCurve.Ease(Easing.EaseBackOut, this.gameObject.transform.localPosition.x, 0, Input.mousePosition.x - cam.pixelRect.width / 2, .5);
                    animCurveY = EaseCurve.Ease(Easing.EaseCircOut, this.gameObject.transform.localPosition.y, 0, Input.mousePosition.y - cam.pixelRect.height / 2, .5);
                    // 4. Set a curve in clip
                    this.mAnimClip.SetCurve("", typeof(Transform), "localPosition.x", animCurveX);
                    this.mAnimClip.SetCurve("", typeof(Transform), "localPosition.y", animCurveY);
                    // 5. Play
                    this.mAnim.AddClip(this.mAnimClip, "MOVE_TO");
                    this.mAnim.Play("MOVE_TO");
                }
            }
        }
    }
}
