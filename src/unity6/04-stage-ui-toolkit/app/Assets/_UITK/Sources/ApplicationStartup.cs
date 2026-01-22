using UnityEngine;
using System.Collections;

namespace Assets.UITK
{
    public class ApplicationStartup : MonoBehaviour
    {
        // Member variable

        // Use this for initialzation system.
        void Awake()
        {
            Debug.Log("Application Startup Script : System");
        }

        // Use this for initialization game object.
        void Start ()
        {
            Debug.Log("Application Startup Script : Module");
        }
    }
}
