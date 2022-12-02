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
            // Retrieve game object
            Canvas canLibrary = null;
            // by type
            canLibrary = GameObject.FindObjectOfType<Canvas>();
            if (canLibrary != null)
                Debug.Log("Retrieve by type, Canvas name : " + canLibrary.name);
            // by name
            canLibrary = (GameObject.Find("UILibrary")).GetComponent<Canvas>();
            if (canLibrary != null)
                Debug.Log("Retrieve by name, Canvas name : " + canLibrary.name);

            // Create Canvas
            GameObject newStage = new GameObject();
            newStage.AddComponent<RectTransform>();
            newStage.AddComponent<Canvas>();
            newStage.name = "NewCanvas";

            // Add Button
            Button btn = (GameObject.Find("DefaultButton")).GetComponent<Button>();
            if (btn != null)
            {
                Debug.Log("Button name : " + btn.name);
                Button newBtn = Instantiate(btn);
                newBtn.name = "NewButton";
                newBtn.transform.SetParent(newStage.transform);
            }


        }
    }
}
