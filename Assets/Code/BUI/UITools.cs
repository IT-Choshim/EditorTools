using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.BUI
{
    static public class UITools
    {

        static private UITools_AutoSetComTransformByData UITools_AutoSetComTransformByData;

        static UITools()
        {
            UITools_AutoSetComTransformByData = new UITools_AutoSetComTransformByData();
        }


        /// <summary>
        /// 自动为Transform进行赋值
        /// </summary>
        /// <param name="transform">Transform.</param>
        /// <param name="o">O.</param>
        static public void AutoSetComValue(Transform t, object o)
        {
            UITools_AutoSetComTransformByData.AutoSetCustemValue(t, o);
        }

    }

}

