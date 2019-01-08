using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.BWindow {

public class SubWindow:AWindow {

    public SubWindow(string name) : base(name)
    {
        subWindowDictionary = new Dictionary<string, object>();
    }

    public SubWindow(Transform transform) : base(transform)
    {
        subwindowDictionary = new Dictionary<string, SubWindow>();
    }


    public Dictionary<string, object> subWindowDictionary { get; private set; }


    /// <summary>
    /// add subWindowDictionary
    /// </summary>
    /// <param name="name">Name.</param>
    /// <param name="o">O.</param>
    public void AddData(string name,object o)
    {
        if (!subWindowDictionary.ContainsKey(name))
        {
            subWindowDictionary.Add(name,o);
        }
        else
        {
            Debug.Log("老铁 你所提供的name，subWindowDictionary中已存在，请检查");
        }
    }


    /// <summary>
    /// remove掉subwindowdictionary
    /// </summary>
    /// <param name="name">Name.</param>
    /// <param name="o">O.</param>
    public void RemoveData(string name, object o)
    {
        if (subWindowDictionary.ContainsKey(name))
        {
            subWindowDictionary.Remove(name);
        }
    }


    /// <summary>
    /// Removes all.
    /// </summary>
    public void RemoveAll()
    {
        subWindowDictionary.Clear();
    }


    /// <summary>
    /// Close this instance.
    /// </summary>
    public override void Close()
    {
        base.Close();
    }

    }
}