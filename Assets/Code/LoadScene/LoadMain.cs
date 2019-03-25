using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 禁止切换场景时卸载初始化的游戏对象
        GameObject[] InitGameObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach(GameObject go in InitGameObjects)
        {
            if(go.transform.parent == null)
            {
                GameObject.DontDestroyOnLoad(go.transform);
            }
        }

        // 加载场景
        SceneLoadManager.LoadScene("main",(float progress)=>{
            Debug.LogFormat("加载进度：{0}", progress);
        },()=>{
            Debug.Log("加载完成");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
