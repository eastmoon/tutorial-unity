using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Game.Script
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

            GameObject monitor = new GameObject();
            monitor.AddComponent<Monitor.ApplicationObserver>();
        }

        // Update is called once per frame
        void Update()
        {
            ComputeResolution();
        }

        private void ComputeResolution()
        {
            Camera cam = this.GetComponent<Camera>();
            if( cam != null )
            {
                cam.orthographicSize = Screen.height / 2.0f;
            }
        }
    }
}
