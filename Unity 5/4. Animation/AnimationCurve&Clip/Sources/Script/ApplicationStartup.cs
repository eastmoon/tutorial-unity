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
                /*
                animCurve.AddKey(0, 0);
                animCurve.AddKey(1, 100);
                animCurve.AddKey(2, 0);
                */
                animCurve.AddKey(new Keyframe(0, 0, 0, 0));
                animCurve.AddKey(new Keyframe(1, 100, 0, 45));
                animCurve.AddKey(new Keyframe(2, 0, 90, 0));
                // 3. Evaluate curve
                for (float i = 0; i <= 2; i += 0.2f)
                    Debug.Log("Curve value : " + animCurve.Evaluate(i));
                // 4. Set a curve in clip
                animClip.legacy = true;
                animClip.SetCurve("", typeof(Transform), "localPosition.x", animCurve);
                // 5. Retrieve animation in GameObject, if animation component is not exist, then new a component.
                Animation anim = btn.GetComponent<Animation>();
                if (anim == null)
                {
                    btn.gameObject.AddComponent<Animation>();
                    anim = btn.GetComponent<Animation>();
                }
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
