using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEditor;
using UnityEngine;

public class Excel2Code : ObjectClass<Excel2Code>  {

	public void Init()
	{
		string xlsxPath = Path.Combine(Application.dataPath, "Resources/Table");
		if (!Directory.Exists(xlsxPath))
		{
			Directory.CreateDirectory(xlsxPath);
		}
			

		string[] xlsxFiles = Directory.GetFiles(xlsxPath, "*.xlsx", SearchOption.AllDirectories);

		foreach (string f in xlsxFiles)
		{
			ExcelUtility eu = new ExcelUtility(f);
			string json = eu.GetJson(f);
			List<object> list = eu.GetLine(0);
			Json2Class(f, json, list);
			Debug.Log("导出:"+f);
		}

		EditorUtility.DisplayDialog("提示", "生成完成", "确定");
		AssetDatabase.Refresh();
	}


    public void Json2Class(string file, string json, List<object> list)
    {

        string structName = Path.GetFileName(file).Replace(".xlsx", "");
        structName = structName.Substring(0, 1).ToUpper() + structName.Substring(1);

        string outputFile = Path.Combine(Application.dataPath, "Scripts/Table");
        if (!Directory.Exists(outputFile))
        {
            Directory.CreateDirectory(outputFile);
        }

        outputFile = Path.Combine(outputFile, Path.GetFileName(file).Replace(".xlsx", ".cs"));

        // 生成类服务
        CodeCompileUnit unit = new CodeCompileUnit();

        // 生成类名空间
        CodeNamespace namespaces = new CodeNamespace("Game.Data." + structName);
        unit.Namespaces.Add(namespaces);
        namespaces.Imports.Add(new CodeNamespaceImport("System"));
        namespaces.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));

        //命名空间下添加一个类
        CodeTypeDeclaration ration = new CodeTypeDeclaration(structName);
        ration.IsClass = true;
        ration.IsEnum = false;
        ration.IsInterface = false;
        ration.IsPartial = false;
        ration.IsStruct = false;
        namespaces.Types.Add(ration);

        JsonData jsonData = JsonMapper.ToObject(json)[0];
        int i = 0;
        foreach (var key in jsonData.Keys)
        {
            string memberString = @"        public [type] [name] {get;set;}";


            CodeSnippetTypeMember member = new CodeSnippetTypeMember();
            if (key.ToLower() == "id" && key != "Id")
            {
                Debug.LogErrorFormat("<color=yellow>表格{0}字段为Id[大小写]，请修改", structName);
                break;
            }
            else if (key == "Id")
            {
                memberString = @"
        public [type] [name] {get;set;}
";

            }

            string type = null;

            JsonData value = jsonData[key];
            if (value.IsArray)
            {
                string str = value.ToJson();
                if (str.IndexOf("\"") > 0)
                {
                    type = "List<string>";
                }
                else
                {
                    type = "List<double>";
                }
            }
            else if (value.IsBoolean) type = "bool";
            else if (value.IsDouble) type = "double";
            else if (value.IsInt) type = "int";
            else if (value.IsString) type = "string";

            // 注释
            member.Comments.Add(new CodeCommentStatement(list[i].ToString()));
            member.Text = memberString.Replace("[type]", type).Replace("[name]", key);

            ration.Members.Add(member);
            i++;

            // 生成代码
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            options.BlankLinesBetweenMembers = true;

            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                provider.GenerateCodeFromCompileUnit(unit, writer, options);
            }
        }

    }

}
