using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.BDebug
{
    public class BDebug : IDebug
    {

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="t">T.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public void Log<T>(T t) where T : Object
        {
            Debug.Log(t.ToString());
        }


        /// <summary>
        /// LogError
        /// </summary>
        /// <param name="t">T.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public void LogError<T>(T t) where T : Object
        {
            Debug.LogError(t.ToString());
        }

    }
}
