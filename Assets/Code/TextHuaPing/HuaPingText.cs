using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HuaPingText : MonoBehaviour
{

    // 标记某个字体发生了重建
    private Font m_NeedRebuildFont = null;
    void Start()
    {
        // 监听字体贴图重建事件
        Font.textureRebuilt += delegate(Font font) {
            m_NeedRebuildFont = font;
        };
    }


    void Update()
    {
        if (m_NeedRebuildFont)
        {
            // 找到当前场景中的所有Text，重新刷新一下
            Text[] texts = GameObject.FindObjectsOfType<Text>();
            if(texts != null)
            {
                foreach(Text text in texts)
                {
                    if(text.font == m_NeedRebuildFont)
                    {
                        text.FontTextureChanged();
                    }
                }
            }
            m_NeedRebuildFont = null;
        }
    }
}
