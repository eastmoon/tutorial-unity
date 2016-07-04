using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System;

public class ExportProjectPackages
{
    static string ProjectName = "Particle";
    static string SceneName = "ParticleStage";
    static string PackagesName = "Stage2D_Particle";

    [MenuItem("Assets/Export Project Packages")]
    static void BuildAllAssetBundles()
    {
        string[] paths = null;
        string outputPath = System.IO.Directory.GetCurrentDirectory() + "/Packages/";
        
        // 1. Retrieve all resources and sources
        string scene = "Assets/Scenes/" + ExportProjectPackages.SceneName + ".unity";
        string[] res = RetrieveAllFilesInDirectory("Assets/Resources/" + ExportProjectPackages.ProjectName);
        string[] src = RetrieveAllFilesInDirectory("Assets/Sources/Script/" + ExportProjectPackages.ProjectName);
        paths = new string[] { scene };
        if(res != null)
            paths = ExportProjectPackages.MergeArray(paths, res);
        if(src != null)
            paths = ExportProjectPackages.MergeArray(paths, src);

        // 2. Output packages, make sure output path at [Project directory]/Packages/[Output filename]
        if (paths != null)
        { 
            for (int i = 0; i < paths.Length; i++)
                Debug.Log("Out : " + paths[i]);
            if (!System.IO.Directory.Exists(outputPath))
                System.IO.Directory.CreateDirectory(outputPath);
            AssetDatabase.ExportPackage(paths, outputPath + ExportProjectPackages.PackagesName + ".unitypackage");
        }
        else
        {
            Debug.Log("Error : Export Project Packages, path is null");
        }
    }

    static string[] RetrieveAllFilesInDirectory(string _path)
    {
        string[] directories = null;
        string[] files = null;

        // 1. make sure directory exist.
        if(System.IO.Directory.Exists(_path))
        {
            // 1-1. retrieve current directory subfolders and files.
            directories = System.IO.Directory.GetDirectories(_path);
            files = System.IO.Directory.GetFiles(_path);

            // 1-2. retrieve file in subfolders.
            if(directories.Length > 0)
            {
                string[] filesInSubfolder = null;
                
                for(int i = 0; i < directories.Length; i++)
                {
                    // retrieve
                    filesInSubfolder = RetrieveAllFilesInDirectory(directories[i]);

                    // resize array and copy data into array.
                    files = ExportProjectPackages.MergeArray(files, filesInSubfolder);
                }
            } 
        }

        return files;
    }
    static string[] MergeArray(string[] _soruce, string[] _target)
    {
        string[] mergeArray = null;
        if (_soruce != null && _target != null)
        {
            mergeArray = new string[_soruce.Length + _target.Length];
            Array.Copy(_soruce, mergeArray, _soruce.Length);
            Array.Copy(_target, 0, mergeArray, _soruce.Length, _target.Length);
        }
        return mergeArray;
    }
}
