using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;

namespace Assets.Sources.Script
{
    public class ApplicationStartup : MonoBehaviour
    {
        // Member variable
        private bool isUpdate;

        // Use this for initialzation system.
        public void Awake()
        {
            Debug.Log("Application Startup Script : System");
            //
            Framework.ApplicationCore.getInstance().SystemStartup();
        }

        // Use this for initialization game object.
        public void Start ()
        {
            Debug.Log("Application Startup Script : Module");
            //
            Framework.ApplicationCore.getInstance().ModuleStatrup();
            //
            this.DoSceneRetreive();
            //
            this.DoAdditionGameObject();
        }

        // Declare public method
        public void DoSceneRetreive()
        {
            // Show all scene information in build and hierarchy.
            this.ShowSceneInformation();
            // Retrieve game object
            Canvas canLibrary = null;
            // by type
            canLibrary = null;
            canLibrary = GameObject.FindFirstObjectByType<Canvas>();
            if (canLibrary != null)
                Debug.Log("Retrieve by type, Canvas name : " + canLibrary.name + ", Scene : " + canLibrary.gameObject.scene);
            // by name
            canLibrary = null;
            canLibrary = (GameObject.Find("UILibrary")).GetComponent<Canvas>();
            if (canLibrary != null)
                Debug.Log("Retrieve by name, Canvas name : " + canLibrary.name + ", Scene : " + canLibrary.gameObject.scene);
            // by name in other scene
            // this.LoadSceneAsyncAwait("Assets/_DynamicObject/Scenes/Library.unity", "UIGroup");
            // by name in AssetsBundle
            this.LoadBundleAsyncAwait("Assets/_DynamicObject/Scenes/AssetLibrary.unity", "UIBundle");
        }

        public void DoAdditionGameObject()
        {
            // Create Canvas
            GameObject newStage = new GameObject();
            newStage.AddComponent<RectTransform>();
            newStage.AddComponent<Canvas>();
            newStage.name = "NewCanvas";

            // Add Button
            //Button btn = GameObject.Find("DefaultButton").GetComponent<Button>();
            //Button btn = GameObject.Find("UILibrary").GetComponentInChildren<Button>();
            Button btn = GameObject.Find("/UILibrary/DefaultButton").GetComponent<Button>();
            if (btn != null)
            {
                Debug.Log("Button name : " + btn.name);
                Button newBtn = Instantiate(btn);
                newBtn.name = "NewButton";
                newBtn.transform.SetParent(newStage.transform);
            }
        }

        // Declare private method
        private void ShowSceneInformation()
        {
            // Get names of all scenes in Build Settings
            Debug.Log("--- Scenes in Build Settings ---");
            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                Scene scene = SceneManager.GetSceneByBuildIndex(i);
                if (scene.IsValid()) // Check if scene is valid/loaded
                {
                    Debug.Log($"Build Index {i}: {scene.name}");
                }
            }

            // Get names of all scenes currently open in the hierarchy
            Debug.Log("--- Scenes in Hierarchy ---");
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                Debug.Log($"Hierarchy Scene: {scene.name}");
            }
            Debug.Log("--- End Scenes ---");
        }
        private async void LoadSceneAsyncAwait(string sceneName, string objectName)
        {
            // The await keyword "waits" here without blocking the main thread
            await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            // This code will only execute once the scene is fully loaded and activated
            Debug.Log("Scene " + sceneName + " loaded with async/await!");

            // Retrieve game object
            Canvas canLibrary = null;
            canLibrary = GameObject.Find(objectName).GetComponent<Canvas>();
            if (canLibrary != null)
                Debug.Log("Retrieve by name, Canvas name : " + canLibrary.name + ", Scene : " + canLibrary.gameObject.scene);

            // Show all scene information in build and hierarchy.
            this.ShowSceneInformation();
        }
        private void LoadBundleAsyncAwait(string sceneName, string objectName)
        {
            AssetBundle bundle = AssetBundle.LoadFromFile(Path.Combine("Build", "AssetBundles", "environment", "desert"));
            if (bundle == null)
            {
                Debug.Log("Failed to load AssetBundle!");
                return;
            }

            Debug.Log("AssetBundle loaded successfully!");

            // Load a specific asset (in this case, a GameObject prefab) from the bundle
            this.LoadSceneAsyncAwait(sceneName, objectName);
        }
    }
}
