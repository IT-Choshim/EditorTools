using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AWindow {

    public AWindow(string name)
    {
        subwindowDictionary = new Dictionary<string, SubWindow>();
    }

    public AWindow(Transform transform)
    {
        subwindowDictionary = new Dictionary<string, SubWindow>();
    }

    public Dictionary<string, SubWindow> subwindowDictionary { get; protected set; }


    /// <summary>
    /// 添加subwindow
    /// </summary>
    /// <param name="name">Name.</param>
    /// <param name="sub">Sub.</param>
    public void AddSubwindow(string name,SubWindow sub)
    {
        if (!subwindowDictionary.ContainsKey(name))
        {
            this.subwindowDictionary[name] = sub;
        }
    }


    /// <summary>
    /// 打开subwindow的open()
    /// </summary>
    /// <param name="name">Name.</param>
    /// <param name="o">O.</param>
    public void OpenSubwindow(string name,WindowData windowData = null)
    {
        SubWindow sub;
        if(subwindowDictionary.TryGetValue(name,out sub))
        {
            sub.Open(windowData);
        }
    }


    #region 子窗口

    /// <summary>
    /// 初始化子窗口
    /// </summary>
    public virtual void Init()
    {

    }


    /// <summary>
    /// 打开自窗口
    /// </summary>
    /// <param name="data">Data.</param>
    public virtual void Open(WindowData data = null)
    {

    }


    /// <summary>
    /// 关闭子窗口
    /// </summary>
    public virtual void Close()
    {

    }

    #endregion

}
