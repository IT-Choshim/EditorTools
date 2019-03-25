using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class ReadManager
{

    // 数据文件位置
    //public const string dataPath = "/data";
    public static bool isDataInit = false;

    public static void Init()
    {
        if (isDataInit)
        {
            return;
        }
        isDataInit = true;

        InitBoundle();
    }


    public static void InitBoundle()
    {
        // 调入

        //ParserFromtxtFile<>
    }


    public static void ParserFromtxtFile<T>(List<T> list,bool bRefResource = false)
    {
        string asset = null;

        // 获取文件路径
        string file = ((DataPathAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(DataPathAttribute))).filePath;

        if (bRefResource)
        {
            asset = ((TextAsset)Resources.Load(file, typeof(TextAsset))).text;
        }
        else
        {
            asset = File.ReadAllText(Application.dataPath + "/Code/ReadCSV/"+file);
        }


        StringReader reader = null;
        try
        {
            bool isHeadData = false;
            string[] headLine = null;
            string stext = string.Empty;
            reader = new StringReader(asset);
            while((stext = reader.ReadLine()) != null)
            {
                if (!isHeadData)
                {
                    headLine = stext.Split(',');
                    isHeadData = true;
                }
                else
                {
                    string[] data = stext.Split(',');
                    list.Add(CreateDataModule<T>(headLine.ToList(), data));
                }
            }

        }
        catch(Exception e)
        {

        }
        finally
        {
            if(reader != null)
            {
                reader.Close();
            }
        }
    }


    public static T CreateDataModule<T>(List<string> headLine,string[] data)
    {
        T result = Activator.CreateInstance<T>();
        FieldInfo[] fis = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance);
        foreach(FieldInfo f in fis)
        {
            string colum = headLine.Where(tempstr => tempstr == f.Name).FirstOrDefault();
            if (!string.IsNullOrEmpty(colum))
            {
                string baseValue = data[headLine.IndexOf(colum)];
                object baseValueObj = null;
                Type setValueType = f.GetType();
                if (setValueType.Equals(typeof(short)))
                {
                    baseValueObj = string.IsNullOrEmpty(baseValue) ? (short)0 : Convert.ToInt16(baseValue);
                }

                f.SetValue(result, baseValueObj);
            }
        }


        return result;
    }
}
