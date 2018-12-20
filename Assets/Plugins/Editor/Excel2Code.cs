using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Excel2Code  {

	static public void Init()
	{
		string xlsxPath = Path.Combine(Application.dataPath, "Resources/Table");
		if (!Directory.Exists(xlsxPath))
		{
			Directory.CreateDirectory(xlsxPath);
		}
			

		string[] xlsxFiles = Directory.GetFiles(xlsxPath, "*.xlsx", SearchOption.AllDirectories);

		foreach (var f in xlsxFiles)
		{
			ExcelUtility eu = new ExcelUtility(f);
			string json = eu.GetJson(f);
			List<object> list = eu.GetLine(0);
			eu.Json2Class(f, json, list);
			Debug.Log("导出:"+f);
		}

		EditorUtility.DisplayDialog("提示", "生成完成", "确定");
		AssetDatabase.Refresh();
	}
	
}
