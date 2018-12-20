using System.Collections.Generic;
using System.Data;
using System.IO;
using Excel;
using Newtonsoft.Json;

public class ExcelUtility
{
	private DataSet set;
	
	public ExcelUtility(string file)
	{
        // 读取Excel
		FileStream fileStream = File.Open(file, FileMode.Open, FileAccess.Read);
		IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
		set = reader.AsDataSet();
	}


    /// <summary>
    ///  读取excel，转换为json
    /// </summary>
    /// <returns>The json.</returns>
    /// <param name="file">excel表名称</param>
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


    /// <summary>
    ///  获取excel表第index行
    /// </summary>
    /// <returns>The line.</returns>
    /// <param name="index">行数</param>
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

}
