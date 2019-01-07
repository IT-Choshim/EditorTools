using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.BResourceMgr
{
    static public class BResources
    {

        static private IResMgr resMgr { get; set; }


        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="path">Path.</param>
        static public void Load(string root = "")
        {
            if(root != "")
            {
                resMgr = new DevResourceMgr();
            }
            else
            {
#if UNITY_EDITOR
                resMgr = new AssetBundleMgr();
#endif
            }
        }


        /// <summary>
        /// 加载资源
        /// </summary>
        /// <returns>The load.</returns>
        /// <param name="path">Path.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        static public T Load<T>(string path) where T : UnityEngine.Object
        {
            return resMgr.Load<T>(path);
        }

    }

}
