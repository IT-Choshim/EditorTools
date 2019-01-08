using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.BUI
{

    public enum ComponentType:int
    {
        Image = 0,
        Text,
        ScrollBar,
        Slider,
        Toggle,
    }

    public enum CustemField:int
    {
        Null = 0,
        /// <summary>
        /// 资源加载路径
        /// </summary>
        ResourcesPath,
        /// <summary>
        /// 设置GameObject状态
        /// </summary>
        GameObjectActive,
        /// <summary>
        /// 设置component状态
        /// </summary>
        ComponentEnable,

    }


    public class ComponentAttribute:Attribute
    {
        /// <summary>
        /// Gets the name of the UIT ools attribute.
        /// </summary>
        /// <value>The name of the UIT ools attribute.</value>
        public string UITools_AttributeName { get; private set; }

        /// <summary>
        /// Gets the type of the component.
        /// </summary>
        /// <value>The type of the component.</value>
        public ComponentType ComponentType { get; private set; }

        /// <summary>
        /// Gets the custem field.
        /// </summary>
        /// <value>The custem field.</value>
        public CustemField CustemField { get; private set; }

        /// <summary>
        /// Gets the component field.
        /// </summary>
        /// <value>The component field.</value>
        public string ComponentField { get; private set; }

        public ComponentAttribute(string Tools_Attribute,ComponentType componentType,CustemField custemField)
        {
            this.UITools_AttributeName = Tools_Attribute;
            this.ComponentType = componentType;
            this.CustemField = custemField;
        }

        public ComponentAttribute(string Tools_Attribute,ComponentType componentType,string componentField)
        {
            this.UITools_AttributeName = Tools_Attribute;
            this.ComponentType = componentType;
            this.ComponentField = componentField;
        }

    }
}
