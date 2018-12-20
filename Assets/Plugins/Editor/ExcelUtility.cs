using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Excel;
using LitJson;
using Newtonsoft.Json;
using UnityEngine;

public class ExcelUtility
{
	private DataSet set;
	
	public ExcelUtility(string file)
	{
		FileStream fileStream = File.Open(file, FileMode.Open, FileAccess.Read);
		IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
		set = reader.AsDataSet();
	}

	public string GetJson(string file)
	{
		

		if (set.Tables.Count < 1)
		{
			return "";
		}

		DataTable sheet = set.Tables[0];

		if (sheet.Rows.Count < 1)
		{
			return "";
		}

		int rows = sheet.Rows.Count;
		int columns = sheet.Columns.Count;
		
		List<Dictionary<string,object>> list = new List<Dictionary<string, object>>();
		for (int i = 2; i < rows; i++)
		{
			Dictionary<string,object> dic = new Dictionary<string, object>();
			for (int j = 0; j < columns; j++)
			{
				string field = sheet.Rows[1][j].ToString();
				dic[field] = sheet.Rows[i][j];
			}
			list.Add(dic);
		}

		string json = JsonConvert.SerializeObject(list, Formatting.None);
		json = json.Replace("\"[", "[").Replace("]\"", "]");
		json = json.Replace("\\\"", "\"");
		json = json.Replace("\"\"\"\"", "\"\"");
		
		return json;
	}

	public List<object> GetLine(int index)
	{
		if (set.Tables.Count < 1)
		{
			return null;
		}

		DataTable sheet = set.Tables[0];

		if (sheet.Rows.Count < 1)
		{
			return null;
		}

		int rows = sheet.Rows.Count;
		int columns = sheet.Columns.Count;

		List<object> list = new List<object>();
		
		for (int i = 0; i < columns; i++)
		{
			string field = sheet.Rows[index][i].ToString();
			list.Add(field);
		}
		
		return list;
	}

	public void Json2Class(string file,string json,List<object> list)
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
		CodeNamespace namespaces = new CodeNamespace("Game.Data."+structName);
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
			string memberString = @"		public [type] [name] {get;set;}";

			
			CodeSnippetTypeMember member = new CodeSnippetTypeMember();
			if (key.ToLower() == "id" && key != "Id")
			{
				Debug.LogErrorFormat("<color=yellow>表格{0}字段为Id[大小写]，请修改",structName);
				break;
			}
			else if(key == "Id")
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
			}else if (value.IsBoolean) type = "bool";
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
				provider.GenerateCodeFromCompileUnit(unit,writer,options);
			}
		}

	}

}
