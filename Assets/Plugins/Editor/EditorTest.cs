using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class EditorTest : EditorWindow {

	[MenuItem("Editor/excel")]
	static void ExcelT()
	{
		EditorTest et = (EditorTest) EditorWindow.GetWindow(typeof(EditorTest), true, "Editor");
		et.Show();
	}

	private void OnGUI()
	{
		if (GUILayout.Button(("excel"),GUILayout.Width(200)))
		{
			Excel2Code.Init();
		}
			
	}
}
