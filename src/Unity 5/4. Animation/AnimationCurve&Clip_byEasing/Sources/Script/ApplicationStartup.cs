using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Assets.Sources.Script
{
    public class ApplicationStartup : MonoBehaviour
    {
        // Member variable
        private bool isUpdate;

        // Use this for initialzation system.
        void Awake()
        {
            Debug.Log("Application Startup Script : System");
            // 
            Framework.ApplicationCore.getInstance().SystemStartup();
        }
        static float EaseInOutCirc(float start, float distance, float
                         elapsedTime, float duration)
        {
            // clamp elapsedTime so that it cannot be greater than duration
            elapsedTime = (elapsedTime > duration) ? 2.0f : elapsedTime / (duration / 2);
            if (elapsedTime < 1) return -distance / 2 * (Mathf.Sqrt(1 - elapsedTime * elapsedTime) - 1) + start;
            elapsedTime -= 2;
            return distance / 2 * (Mathf.Sqrt(1 - elapsedTime * elapsedTime) + 1) + start;
        }
        // Use this for initialization game object.
        void Start ()
        {
            Debug.Log("Application Startup Script : Module");
            // 
            Framework.ApplicationCore.getInstance().ModuleStatrup();
            // 
            Button btn = GameObject.Find("Button").GetComponent<Button>();
            if( btn != null )
            {
                // 1. New curve and clip
                AnimationCurve animCurve = new AnimationCurve();
                AnimationClip animClip = new AnimationClip();
                // 2. Set a curve                
                for (float i = 0; i <= 1; i += 0.0167f)
                {
                    animCurve.AddKey(i, EaseInOutCirc(0, 100, i, 1));
                    Debug.Log("Easing : " + EaseInOutCirc(0, 100, i, 1));
                }
                // 3. Evaluate curve
                for (float i = 0; i <= 1; i += 0.1f)
                    Debug.Log("Curve value : " + animCurve.Evaluate(i));
                // 4. Set a curve in clip
                animClip.legacy = true;
                animClip.SetCurve("", typeof(Transform), "localPosition.x", animCurve);
                // 5. Retrieve animation in GameObject, if animation component is not exist, then new a component.
                Animation anim = btn.GetComponent<Animation>();
                if (anim == null)
                    anim = btn.gameObject.AddComponent<Animation>();
                // 6. Push clip in anim, and play
                anim.AddClip(animClip, "test");
                anim.Play("test");
                // 
                btn.onClick.AddListener(this.OnClickButton);
            }
        }

        void OnClickButton()
        {
            Button btn = GameObject.Find("Button").GetComponent<Button>();
            if (btn != null)
            {
                Animation anim = btn.GetComponent<Animation>();
                anim.Play("test");
            }
        }
    }
}
