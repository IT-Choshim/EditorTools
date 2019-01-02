using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowData {


    public WindowData()
    {
        dataMap = new Dictionary<string, object>();
    }


    public Dictionary<string, object> dataMap = null;


    /// <summary>
    /// add到datamap
    /// </summary>
    /// <param name="name">Name.</param>
    /// <param name="o">O.</param>
    public void AddData(string name,object o)
    {
        if (!dataMap.ContainsKey(name))
        {
            dataMap.Add(name, o);
        }
        else
        {
            Debug.Log("老铁 你所提供的name，datamap中已存在，请检查");
        }
    }


    /// <summary>
    /// 得到datamap value
    /// </summary>
    /// <returns>The data.</returns>
    /// <param name="name">Name.</param>
    /// <typeparam name="T">The 1st type parameter.</typeparam>
    public T GetData<T>(string name)
    {
        object o;
        if(dataMap.TryGetValue(name,out o))
        {
            return (T)o;
        }
        return default(T);
    }


    // 删除字典中对应的value
    public void RemoveData(string name)
    {
        if (dataMap.ContainsKey(name))
        {
            dataMap.Remove(name);
        }
    }


    // 删除字典中所有的value
    public void RemoveAll()
    {
        if(dataMap.Count > 0)
        {
            dataMap.Clear();
        }
    }

}
