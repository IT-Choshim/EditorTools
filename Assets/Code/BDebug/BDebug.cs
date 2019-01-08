using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.BDebug
{
    public class BDebug
    {

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="t">T.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        static public void Log(object o)
        {
            Debug.Log(o.ToString());
        }


        /// <summary>
        /// LogError
        /// </summary>
        /// <param name="t">T.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        static public void LogError(object o)
        {
            Debug.LogError(o.ToString());
        }

    }
}
