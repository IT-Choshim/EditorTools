using System.Collections;
using System.Collections.Generic;
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

}
