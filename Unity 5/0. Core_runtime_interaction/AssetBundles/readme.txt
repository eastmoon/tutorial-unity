◎ AssetBundles

AssetBundles are files which you can export from Unity to contain assets of your choice. These files use a proprietary compressed format and can be loaded on demand by your application. This allows you to stream in content, such as models, textures, audio clips, or even entire scenes, separately from the scene in which they will be used.

◎ 流程

1. Building AssetBundles. Asset bundles are created in the editor from assets in your scene. The Asset Bundle building process is described in more detail in the section for Building AssetBundles

2. Uploading AssetBundles to external storage. This step does not include the Unity Editor or any other Unity channels, but we include it for completeness. You can use an FTP client to upload your Asset Bundles to the server of your choice.

3. Downloading AssetBundles at runtime from your application. This is done from script within a Unity scene, and Asset Bundles are loaded from the server on demand. More on that in Downloading Asset Bundles.

4. Loading objects from AssetBundles. Once the AssetBundle is downloaded, you might want to access its individual Assets from the Bundle. More on that in Loading Resources from AssetBundles


※ 相關文章參考：
---------------------------
Building AssetBundles
http://docs.unity3d.com/Manual/BuildingAssetBundles.html

Downloading AssetBundles
https://docs.unity3d.com/Manual/DownloadingAssetBundles.html

Easy Steps to Create and Download Asset Bundle in Unity
http://www.theappguruz.com/blog/create-and-download-asset-bundle-in-unity

ASSETBUNDLES AND THE ASSETBUNDLE MANAGE
AssetBundles and The Assetbundle Manager
http://unity3d.com/cn/learn/tutorials/topics/scripting/assetbundles-and-assetbundle-manager

Unity 3D : 製作與載入 AssetBundle
http://godstamps.blogspot.tw/2012/02/unity-3d-assetbundle.html

Unity3D研究院之Assetbundle的实战
http://www.xuanyusong.com/archives/2405

How do I load code dynamically from outside sources?
http://answers.unity3d.com/questions/442769/how-do-i-load-code-dynamically-from-outside-source.html

MonoBehaviour from DLL in AssetBundle Reflection problem
http://answers.unity3d.com/questions/298421/monobehaviour-from-dll-in-assetbundle-reflection-p.html
---------------------------

◎ 封裝限制

AssertBundles封裝是針對資源為主，用於動態或需要編譯的文檔則無法封裝，如Script、Scene。
下列檔案則可列入封裝：
‧JPG、PNG
‧Shader
‧Material
‧Text
‧Prefab

◎ 程式碼載入

AssetBundles官方文件說明，在其中可以TextAssets方式將程式碼載入，但這程式並非可執行的程式碼。
若須封裝到AssetBundles，則必須先完成編譯 ( DLL檔 )，並透過Mono Reflection class讀取。
但這種方式對應於不相容DLL的環境無法運作，如iOS。

※ 相關文章參考：
---------------------------
Including scripts in AssetBundles
http://docs.unity3d.com/Manual/scriptsinassetbundles.html

Instantiating Prefabs at runtime
https://docs.unity3d.com/Manual/InstantiatingPrefabs.html

Plugin
https://docs.unity3d.com/Manual/PluginInspector.html

Managed Plugins
https://docs.unity3d.com/Manual/UsingDLL.html

MonoBehaviour from DLL in AssetBundle Reflection problem
http://answers.unity3d.com/questions/298421/monobehaviour-from-dll-in-assetbundle-reflection-p.html

How to download and load a scene during runtime?
http://answers.unity3d.com/questions/470022/how-to-download-and-load-a-scene-during-runtime.html
---------------------------


