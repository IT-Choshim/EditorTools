using UnityEditor;
using UnityEngine;

public class EditorTest : EditorWindow {

	[MenuItem("Editor/表格/Excel->Class")]
	static void ExcelT()
	{
		EditorTest et = (EditorTest) EditorWindow.GetWindow(typeof(EditorTest), true, "Editor");
		et.Show();
	}

	private void OnGUI()
	{
		if (GUILayout.Button("Excel->Class",GUILayout.Width(200)))
		{
            Excel2Code.Instance.Init();
		}

        if (GUILayout.Button("Excel->Sqlite", GUILayout.Width(200))){

        }

    }
}
