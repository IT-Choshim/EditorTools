using System.Collections;
using System.Collections.Generic;
using Code.BResourceMgr;
using Code.UI;
using UnityEngine;

public class Window_Logo : AWindow {


    public Window_Logo(string name) : base(name)
    {

    }

    public Window_Logo(Transform transform) : base(transform)
    {

    }

    public override void Init()
    {

        Transform mainTrans = GameObject.Find("main").transform;
        BResources.Load("");
        GameObject goR = BResources.Load<GameObject>("UITools");
        Debug.Log(goR);
        //GameObject go = BResources.Instantiate<GameObject>(goR);
        goR.transform.SetParent(mainTrans);

        var tools = new ToolsData()
        {
            tx_Item = "lizhi",
            tx_Icon = "24",
        };

        UITools.AutoSetComValue(goR.transform, tools);


        var subWindow = new SubWindow_Logo(mainTrans.Find("GameObject"));
        subWindow.Init();
        this.AddSubwindow("logo", subWindow);

        var data = new Data
        {
            name = "lizhi",
            age = 24,
        };

        var windowData = new WindowData();
        windowData.AddData("logo",data);
        this.OpenSubwindow("logo", windowData);

    }


    public class Data
    {
        public string name;
        public int age;
    }


    public class ToolsData
    {
        [Component("tx_Item", ComponentType.Text, "text")]
        public string tx_Item;
        [Component("tx_Icon", ComponentType.Text, "text")]
        public string tx_Icon;
    }

}
