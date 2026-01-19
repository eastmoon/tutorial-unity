using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateAssetBundles : EditorWindow
{
    [MenuItem ("Tools/Build AssetBundles")]
    static void BuildAllAssetBundles ()
    {
        string build_path = Path.Combine("Build", "AssetBundles");
        if (!Directory.Exists(build_path))
        {
            DirectoryInfo di = Directory.CreateDirectory(build_path);
            Debug.Log("Directory ensured at: " + di.FullName);
        }
        BuildPipeline.BuildAssetBundles (build_path, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
}
