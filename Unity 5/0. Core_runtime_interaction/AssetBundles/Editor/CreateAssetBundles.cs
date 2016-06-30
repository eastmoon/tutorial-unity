using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class CreateAssetBundles
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        // 1. Make sure asset bundles folder exist.
        //Debug.Log(string.Format("Assets/AssetBundles {0}", System.IO.Directory.Exists("Assets/AssetBundles")));
        if (!System.IO.Directory.Exists("Assets/AssetBundles"))
            System.IO.Directory.CreateDirectory("Assets/AssetBundles");

        // 2. Difference System version put into difference directory.
        if (!System.IO.Directory.Exists("Assets/AssetBundles/Windows"))
            System.IO.Directory.CreateDirectory("Assets/AssetBundles/Windows");
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles/Windows", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);

        // 2. Difference System version put into difference directory.
        if (!System.IO.Directory.Exists("Assets/AssetBundles/Android"))
            System.IO.Directory.CreateDirectory("Assets/AssetBundles/Android");
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles/Android", BuildAssetBundleOptions.None, BuildTarget.Android);
    }
}
