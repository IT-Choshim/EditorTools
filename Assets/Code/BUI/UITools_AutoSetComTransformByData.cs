using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Code.BUI
{

    public class UITools_AutoSetComTransformByData
    {

        private Dictionary<Transform, Dictionary<string, ComponentValueCache>> componentValueCacheMap;

        public UITools_AutoSetComTransformByData()
        {
            componentValueCacheMap = new Dictionary<Transform, Dictionary<string, ComponentValueCache>>();
        }


        /// <summary>
        /// 自动对Transform进行赋值
        /// </summary>
        /// <param name="t">T.</param>
        /// <param name="o">O.</param>
        public void AutoSetCustemValue(Transform t, object o)
        {
            // 建立缓存
            Dictionary<string, ComponentValueCache> coms = new Dictionary<string, ComponentValueCache>();

            if(!componentValueCacheMap.TryGetValue(t,out coms))
            {
                FirstCustemValue(t, o, out coms);

                this.componentValueCacheMap[t] = coms;
            }

            var fields = o.GetType().GetFields();
            foreach(var f in fields)
            {
                ComponentValueCache cc;
                if(coms.TryGetValue(f.Name,out cc))
                {
                    cc.SetValue(f.GetValue(o));
                }
                else
                {
                    Debug.Log("该字段配置无节点" + f.Name);
                }
            }

        }


        /// <summary>
        /// Firsts the custem value.
        /// </summary>
        /// <param name="t">T.</param>
        /// <param name="o">O.</param>
        /// <param name="coms">Coms.</param>
        private void FirstCustemValue(Transform t,object o,out Dictionary<string, ComponentValueCache> coms)
        {
            coms = new Dictionary<string, ComponentValueCache>();
            var setList = new List<UITools_Attribute>(t.GetComponentsInChildren<UITools_Attribute>());

            var type = o.GetType();
            var fields = type.GetFields();

            foreach (var f in fields)
            {
                var attrs = f.GetCustomAttributes(typeof(ComponentAttribute), false);
                var fAttrs = attrs.ToList().Find(a => a is ComponentAttribute) as ComponentAttribute;

                if(fAttrs != null && fAttrs.ComponentType != null)
                {
                    // 获取uitools一致的节点
                    var trans = setList.Find(s => s.ToolTag_FieldName == fAttrs.UITools_AttributeName);
                    if(trans != null)
                    {
                        // 存入
                        coms[f.Name] = new ComponentValueCache(fAttrs,trans.transform);
                    }
                }

            }
        }

    }



    /// <summary>
    /// Component value cache.
    /// </summary>
    public class ComponentValueCache
    {
        private UIBehaviour component;
        private ComponentAttribute componentAttribute;
        private Dictionary<ComponentType, Type> typesMap = new Dictionary<ComponentType, Type>();

        public ComponentValueCache(ComponentAttribute componentAttribute,Transform transform)
        {
            this.componentAttribute = componentAttribute;
            typesMap[ComponentType.Image] = typeof(Image);
            typesMap[ComponentType.Text] = typeof(Text);
            typesMap[ComponentType.Toggle] = typeof(Toggle);
            typesMap[ComponentType.ScrollBar] = typeof(Scrollbar);
            typesMap[ComponentType.Slider] = typeof(Slider);
            var c = transform.GetComponent(typesMap[componentAttribute.ComponentType]);
            this.component = c as UIBehaviour;
        }


        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="o">O.</param>
        public void SetValue(object o)
        {
            if (o == null)
                return;

            // 先处理自定义的值
            if(componentAttribute.CustemField != CustemField.Null)
            {

            }
            else
            {
                SetComponentValue(typesMap[componentAttribute.ComponentType], componentAttribute.ComponentField, component, o);
            }
        }


        /// <summary>
        /// 自动设置组件的值
        /// </summary>
        private void SetComponentValue(Type t,string field,UIBehaviour behaviour,object o)
        {
            MemberInfo info;
            info = t.GetField(field);

            if(info == null)
            {
                info = t.GetProperty(field);
            }

            if(info == null)
            {
                Debug.Log("不存在字段或属性");
            }

            if(info.MemberType == MemberTypes.Field)
            {
                ((FieldInfo)info).SetValue(behaviour, o);
            }
            else if(info.MemberType == MemberTypes.Property)
            {
                ((PropertyInfo)info).SetValue(behaviour, o);
            }
        }
    }

}
