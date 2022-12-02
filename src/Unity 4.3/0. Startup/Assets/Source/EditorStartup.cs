using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
[InitializeOnLoad]
#endif

public class EditorStartup
{
	static EditorStartup()
	{
		Debug.Log("Editor Startup");
	}
}

