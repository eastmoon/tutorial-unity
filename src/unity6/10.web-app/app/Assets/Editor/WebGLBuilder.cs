using UnityEditor;
using UnityEngine;

class WebGLBuilder
{
    // A static method to be called from the command line
    public static void build()
    {
        // Define scenes to include in the build
        string[] scenes = { "Assets/_WebApp/Scenes/Main.unity" }; // Replace with your scene paths

        // Define build options
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = scenes;
        buildPlayerOptions.locationPathName = "Build/WebGL"; // Specify the output path
        buildPlayerOptions.target = BuildTarget.WebGL;
        buildPlayerOptions.options = BuildOptions.None; // Set additional options if needed

        // Perform the build
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }
}
