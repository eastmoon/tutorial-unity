using UnityEngine;
using System.Runtime.InteropServices;

namespace Script
{
    public class BrowserResolution
    {
        public int width;
        public int height;
    }

    public class InteractionWithBrowser : MonoBehaviour
    {
        // Import the functions from the jslib
        #if UNITY_WEBGL
        [DllImport("__Internal")]
        private static extern void Hello();
        [DllImport("__Internal")]
        private static extern string Resolution();
        [DllImport("__Internal")]
        private static extern void SetFullWidnsow();
        #endif
        // Use this for initialzation system.
        void Awake() {}

        // Use this for initialization game object.
        void Start() {
            #if UNITY_WEBGL
            Hello();
            SetFullWidnsow();
            #else
            Debug.Log("JS plugins only work in WebGL builds.");
            Screen.SetResolution(800, 600, FullScreenMode.Windowed);
            #endif
        }

        // Update information and render view.
        void Update()
        {}
    }
}
