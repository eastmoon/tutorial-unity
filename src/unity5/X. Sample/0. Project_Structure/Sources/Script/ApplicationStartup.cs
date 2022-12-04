﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Library.Monitor;

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

            // UI, application monitor
            GameObject monitor = new GameObject();
            monitor.AddComponent<ApplicationObserver>();

            // Load Scene
            SceneManager.LoadSceneAsync("ParticleStage", LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync("ImageBox", LoadSceneMode.Additive);
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
