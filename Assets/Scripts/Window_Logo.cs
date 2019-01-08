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

        Transform canvasTrans = GameObject.Find("Canvas").transform;
        BResources.Load("");
        GameObject go = BResources.Load<GameObject>("UITools");
        go = GameObject.Instantiate(go);
        go.transform.SetParent(canvasTrans, false);


        var tools = new ToolsData()
        {
            tx_Item = "lizhi",
            tx_Icon = "24",
        };

        UITools.AutoSetComValue(go.transform, tools);



        var subWindow = new SubWindow_Logo(canvasTrans.Find("GameObject"));
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
