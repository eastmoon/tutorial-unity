using UnityEngine;
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
            Debug.Log("Screen width : " + Screen.width);
            Debug.Log("Screen height : " + Screen.height);
            //
            Camera.main.orthographicSize = Screen.height / 2;
            Debug.Log("orthographicSize : " + Camera.main.orthographicSize);
        }
    }
}
