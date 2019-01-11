using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Code.BUI
{

    public class UITools_Attribute : MonoBehaviour
    {

        /// <summary>
        /// 用来生成代码字段
        /// </summary>
        public bool GenAttribute_TransformPath = false;

        /// <summary>
        /// 用来绑定 数据回调
        /// </summary>
        public string GenAttribute_BindData;

        /// <summary>
        /// 用来自动赋值字段
        /// </summary>
        public string ToolTag_FieldName = "";

    }

}

