using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class AssetBundleTools
{
    [MenuItem("AB/Bundle AssetBundle")]
    static void BundleAssetBundle()
    {

        string outPath = Application.streamingAssetsPath;
        if (Directory.Exists(outPath))
        {
            Directory.Delete(outPath, true);
        }
        Directory.CreateDirectory(outPath);

        BuildPipeline.BuildAssetBundles(outPath, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneOSX);
        AssetDatabase.Refresh();
    }

}
