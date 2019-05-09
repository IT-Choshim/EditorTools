using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadPrefab();
    }


    /// <summary>
    /// 加载预制体
    /// </summary>
    private void LoadPrefab()
    {
        string playerPath = Application.streamingAssetsPath + "/player.unity3d";
        AssetBundle ab = AssetBundle.LoadFromFile(playerPath);

        LoadMaterial();

        object[] os = ab.LoadAllAssets<GameObject>();
        foreach(var v in os)
        {
            Instantiate<GameObject>((GameObject)v);
        }
    }


    /// <summary>
    /// 加载StreamingAssets
    /// </summary>
    private void LoadMaterial()
    {
        string streamingassetspath = Application.streamingAssetsPath + "/StreamingAssets";
        AssetBundle ab = AssetBundle.LoadFromFile(streamingassetspath);
        AssetBundleManifest manifest = ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        string[] strs = manifest.GetAllDependencies("player.unity3d"); 
        foreach(string name in strs)
        {
            Debug.Log(name);
            AssetBundle b = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + name);
        }
    }

}
