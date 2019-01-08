using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.BResourceMgr
{
    public interface IResMgr
    {


        /// <summary>
        /// 同步加载资源
        /// </summary>
        /// <returns>The load.</returns>
        /// <param name="path">Path.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        T Load<T>(string path) where T : UnityEngine.Object;

    }
}
