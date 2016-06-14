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

            // Create canvas
            Canvas operateCanvas = this.CreateCanvas("OperateCanvas");
            // Sorting Order, The number more higher, more the front. 
            operateCanvas.sortingOrder = 1;
            // Create button
            Button btn1 = this.CreateButton(operateCanvas.transform, "Layout Horizontal");
            Button btn2 = this.CreateButton(operateCanvas.transform, "Layout Vertical");
            Button btn3 = this.CreateButton(operateCanvas.transform, "Layout Grid");
            // Setting position
            btn1.GetComponent<RectTransform>().anchoredPosition = new Vector3(150, -100, 0);
            btn2.GetComponent<RectTransform>().anchoredPosition = new Vector3(150, -160, 0);
            btn3.GetComponent<RectTransform>().anchoredPosition = new Vector3(150, -220, 0);
            // Setting event
            btn1.onClick.AddListener(this.OnClickBtnHorizontal);
            btn2.onClick.AddListener(delegate { this.OnClickBtn("Vertical"); });
            btn3.onClick.AddListener(() => this.OnClickBtn("Grid"));
        }

        public Canvas CreateCanvas(string _name)
        {
            // Create Canvas
            GameObject newStage = new GameObject();
            newStage.AddComponent<RectTransform>();
            newStage.AddComponent<Canvas>();
            newStage.AddComponent<CanvasScaler>();
            newStage.AddComponent<GraphicRaycaster>();
            // Setting Canvas
            newStage.name = _name;
            newStage.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            newStage.GetComponent<CanvasScaler>().referencePixelsPerUnit = 1;
            return newStage.GetComponent<Canvas>();
        }
        public Button CreateButton(Transform _parent, string _name)
        {
            // Add Button
            Button template = (GameObject.Find("DefaultButton")).GetComponent<Button>();
            Button btn = null;
            if (template != null)
            {
                // Create clone button
                btn = Instantiate(template);
                // Setting basic information
                btn.name = "Btn_" + _name;
                btn.transform.SetParent(_parent);
                // Setting Text
                Text t = btn.GetComponentInChildren<Text>();
                if (t != null)
                    t.text = _name;
            }
            return btn;
        }

        // Event
        public void OnClickBtn(string _name)
        {
            // All false
            (GameObject.Find("CanvasLayoutHorizontal")).GetComponent<Canvas>().enabled = false;
            (GameObject.Find("CanvasLayoutVertical")).GetComponent<Canvas>().enabled = false;
            (GameObject.Find("CanvasLayoutGrid")).GetComponent<Canvas>().enabled = false;
            // Show one by name
            (GameObject.Find("CanvasLayout" + _name)).GetComponent<Canvas>().enabled = true;
        }

        public void OnClickBtnHorizontal()
        {
            (GameObject.Find("CanvasLayoutHorizontal")).GetComponent<Canvas>().enabled = true;
            (GameObject.Find("CanvasLayoutVertical")).GetComponent<Canvas>().enabled = false;
            (GameObject.Find("CanvasLayoutGrid")).GetComponent<Canvas>().enabled = false;
        }
    }
}
