using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;

public class SceneCollection : ScriptableObject
{
    public SceneSetup[] setup;

    // Call this method to save the current hierarchy setup
    public void SaveSetup()
    {
        setup = EditorSceneManager.GetSceneManagerSetup();
        Debug.Log("Scene setup saved with " + setup.Length + " scenes.");
    }

    // Call this method to load the saved setup
    public void LoadSetup()
    {
        if (setup != null && setup.Length > 0)
        {
            // Optional: Ask the user to save modified scenes before restoring
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                EditorSceneManager.RestoreSceneManagerSetup(setup);
                Debug.Log("Scene setup restored.");
            }
        }
        else
        {
            Debug.LogWarning("No scene setup data found to load.");
        }
    }
}

// Custom Editor window (or part of one) to manage the SceneCollection asset
public class SceneSetupWindow : EditorWindow
{
    // Declare member
    public SceneCollection sceneCollectionAsset;
    private string SceneCollectionAssestPath = "Assets/Editor/SceneSetup.asset";

    // Declare EditorWindows necessary method
    [MenuItem("Tools/Scene Setup Manager")]
    public static void ShowWindow()
    {
        GetWindow<SceneSetupWindow>("Scene Setup Manager");
    }

    void OnGUI()
    {
        GUILayout.Label("Manage Scene Setups", EditorStyles.boldLabel);

        string result = this.FindAssetWithExactFilename();
        if ( result == null)
        {
            Debug.LogWarning("Could not find asset with exact filename: " + this.SceneCollectionAssestPath);
            CreateNewSceneCollectionAsset();
        }
        sceneCollectionAsset = (SceneCollection)AssetDatabase.LoadAssetAtPath(this.SceneCollectionAssestPath, typeof(SceneCollection));

        if (sceneCollectionAsset != null)
        {
            if (GUILayout.Button("Save Current Setup to Asset"))
            {
                sceneCollectionAsset.SaveSetup();
                // Ensure the ScriptableObject asset is saved to disk
                EditorUtility.SetDirty(sceneCollectionAsset);
                AssetDatabase.SaveAssets();
            }

            if (GUILayout.Button("Load Setup from Asset"))
            {
                sceneCollectionAsset.LoadSetup();
            }
        }
    }

    // Declare private method
    private void CreateNewSceneCollectionAsset()
    {
        SceneCollection newAsset = ScriptableObject.CreateInstance<SceneCollection>();
        string path = AssetDatabase.GenerateUniqueAssetPath(this.SceneCollectionAssestPath);
        AssetDatabase.CreateAsset(newAsset, path);
        AssetDatabase.SaveAssets();
        sceneCollectionAsset = newAsset;
        Debug.Log("New SceneCollection asset created at: " + path);
    }

    private string FindAssetWithExactFilename()
    {
        // Find assets with a name that partially matches the filename (without extension)
        string filenameWithExtension = Path.GetFileName(this.SceneCollectionAssestPath);
        string filenameWithoutExtension = Path.GetFileNameWithoutExtension(filenameWithExtension);
        string[] guids = AssetDatabase.FindAssets(filenameWithoutExtension);

        // Iterate through all found GUIDs and find the one with the exact filename
        foreach (string guid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            // Check if the full filename matches exactly
            if (Path.GetFileName(assetPath) == filenameWithExtension)
            {
                return assetPath; // Return the path of the exact match
            }
        }
        return null; // No exact match found
    }
}
