using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DisallowMultipleComponent]
public class UIGray : MonoBehaviour
{

    private bool _isGray = false;
    public bool isGray
    {
        get { return _isGray; }
        set 
        { 
            if(_isGray != value)
            {
                _isGray = value;
            }
        }
    }


    static private Material _defaultGrayMaterial = null;
    static private Material grayMaterial
    {
        get
        {
            if(_defaultGrayMaterial == null)
            {
                _defaultGrayMaterial = new Material(Shader.Find("UI/Gray"));
            }
            return _defaultGrayMaterial;
        }
    }


    /// <summary>
    /// 设置gray
    /// </summary>
    /// <param name="gray">If set to <c>true</c> gray.</param>
    private void SetGray(bool gray)
    {
        Image[] images = transform.GetComponentsInChildren<Image>();
        int count = images.Length;
        for(int i = 0; i < count; i++)
        {
            Image g = images[i];
            if (gray)
            {
                g.material = grayMaterial;
            }
            else
            {
                g.material = null;
            }
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(UIGray))]
public class UIGrayInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        UIGray gray = target as UIGray;
        gray.isGray = GUILayout.Toggle(gray.isGray," isGray");
        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}
#endif
