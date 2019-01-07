using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.BResourceMgr
{
    public class DevResourceMgr : IResMgr
    {

        public DevResourceMgr()
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
