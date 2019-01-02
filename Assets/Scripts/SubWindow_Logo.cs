using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubWindow_Logo : SubWindow
{

    private Transform Transform;

    private Text text;

    public SubWindow_Logo(string name) : base(name)
    {

    }

    public SubWindow_Logo(Transform transform) : base(transform)
    {
        this.Transform = transform;
    }

    public override void Init()
    {
        base.Init();
        Debug.Log("Init()");
        text = this.Transform.Find("Text").GetComponent<Text>();
    }


    public override void Open(WindowData data = null)
    {
        base.Open(data);
        object o;
        if(data.dataMap.TryGetValue("logo",out o))
        {
            Window_Logo.Data ld = (Window_Logo.Data)o;
            Debug.Log(ld.name);
            Debug.Log(ld.age);
            text.text = ld.name + "--" + ld.age;
        }

    }

}
