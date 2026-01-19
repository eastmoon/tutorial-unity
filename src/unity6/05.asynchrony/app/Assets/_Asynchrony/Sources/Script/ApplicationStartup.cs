using UnityEngine;
using System.Collections;
using Assets.Framework;

namespace Script
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
            ApplicationCore.getInstance().SystemStartup();
        }

        // Use this for initialization game object.
        void Start()
        {
            Debug.Log("Application Startup Script : Module");
            //
            ApplicationCore.getInstance().ModuleStatrup();
            //
            this.transform.position = new Vector3(0f, 0f, -2f);
            //
            ApplicationCore.getInstance().RunCount();
        }

        // Update information and render view.
        void Update()
        {
            // When Frame equal 1, than run Coroutine
            if ( Time.frameCount == 1 ) {
                this.StartCoroutine(this.RunCoroutine());
            }
            // Spin with center point ( 0, 0, 0 ) around at 20 degrees/second.
            this.transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 1, 0), 20 * Time.deltaTime);
            //
            if ( ApplicationCore.getInstance().count > 0 ) {
                Debug.Log("Show Count : " + ApplicationCore.getInstance().count);
                ApplicationCore.getInstance().count = 0;
            }
        }

        IEnumerator RunCoroutine()
        {
            Debug.Log("S1. Frame : " + Time.frameCount);
            yield return null;
            Debug.Log("S2. Frame : " + Time.frameCount);
            yield return null;
            Debug.Log("S3. Frame : " + Time.frameCount);
            yield return new WaitForSeconds(5.0f);
            Debug.Log("S4. Frame : " + Time.frameCount);
        }
    }
}
