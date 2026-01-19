using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using Assets.Framework;

namespace Assets.Sources.Script
{
    public class ApplicationStartup : MonoBehaviour
    {
        // Member variable
        private bool isUpdate;
        private UnityEvent m_MyEvent;

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
            if (m_MyEvent == null)
                m_MyEvent = new UnityEvent();

            m_MyEvent.AddListener(OnEventTriggered);

        }

        void Update()
        {
            if (Input.anyKeyDown && m_MyEvent != null)
            {
                m_MyEvent.Invoke();
            }
        }

        void OnEventTriggered()
        {
            Debug.Log("Callback executed");
        }
    }
}
