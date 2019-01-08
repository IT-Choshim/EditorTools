using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.BDebug
{
    public interface IDebug
    {

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="t">T.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        void Log<T>(T t) where T : UnityEngine.Object;


        /// <summary>
        /// LogError
        /// </summary>
        /// <param name="t">T.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        void LogError<T>(T t) where T : UnityEngine.Object;

    }
}
