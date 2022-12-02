using UnityEngine;
using UnityEngine.EventSystems;
using Library.EasingCurve;
using System.Collections;

namespace Game.Script.Particle.Object2D
{
    public class Particle : MonoBehaviour
    {
        private AnimationClip mAnimClip;
        private Animation mAnim;

        // Use this for initialization
        void Start()
        {
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
        void Update()
        {
            // Check if the left mouse button was clicked
            if (Input.GetMouseButtonDown(0))
            {
                //if (!EventSystem.current.IsPointerOverGameObject())
                {
                    Camera cam = GameObject.Find("Main Camera").GetComponent<Camera>();
                    Easing.EaseFunctionType[] easingType = new Easing.EaseFunctionType[]
                    {
                        Easing.EaseQuadOut,
                        Easing.EaseElasticOut,
                        Easing.EaseBackOut,
                        Easing.EaseBounceOut
                    };
                    if (cam != null)
                    {
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
                        animCurveX = EaseCurve.Ease(easingType[Random.Range(0, easingType.Length - 1)], 
                            this.gameObject.transform.localPosition.x,
                            Random.Range(0, 0.3f), 
                            Input.mousePosition.x - cam.pixelRect.width / 2, 
                            .2 + Random.Range(0.3f, 0.5f));
                        animCurveY = EaseCurve.Ease(easingType[Random.Range(0, easingType.Length - 1)], 
                            this.gameObject.transform.localPosition.y,
                            Random.Range(0, 0.3f), 
                            Input.mousePosition.y - cam.pixelRect.height / 2, 
                            .2 + Random.Range(0.3f, 0.5f));
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
}
