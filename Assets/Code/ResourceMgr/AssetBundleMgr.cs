using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Code.BResourceMgr
{
    public class AssetBundleMgr : IResMgr
    {

        public AssetBundleMgr()
        {

        }


        /// <summary>
        /// 加载资源
        /// </summary>
        /// <returns>The load.</returns>
        /// <param name="path">Path.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public T Load<T>(string path) where T : Object
        {
            throw new System.NotImplementedException();
        }
    }
}
