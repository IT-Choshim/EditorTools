using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.BResourceMgr
{
    public class BResources : MonoBehaviour
    {
        static BResources()
        {

        }


        /// <summary>
        /// Load the specified path.
        /// </summary>
        /// <param name="path">Path.</param>
        static public void Load(string path)
        {

        }


        /// <summary>
        /// 加载资源
        /// </summary>
        /// <returns>The load.</returns>
        /// <param name="path">Path.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        static public T Load<T>(string path) where T : UnityEngine.Object
        {
            if (string.IsNullOrEmpty(path))
            {
                return null;
            }

            return (T)Instantiate(Resources.Load<T>(path));

        }

    }

}
