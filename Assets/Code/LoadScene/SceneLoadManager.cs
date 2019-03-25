using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    private static AsyncOperation m_AsyncOperation = null;
    private static UnityAction<float> m_Progress = null;


    /// <summary>
    /// 加载场景
    /// </summary>
    /// <param name="name">Name.</param>
    /// <param name="progress">Progress.</param>
    /// <param name="finish">Finish.</param>
    static public void LoadScene(string name,UnityAction<float> progress,UnityAction finish)
    {
        new GameObject("#SceneLoadManager#").AddComponent<SceneLoadManager>();
        m_AsyncOperation = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
        m_Progress = progress;

        m_AsyncOperation.completed += delegate(AsyncOperation ao) {
            finish();
            m_AsyncOperation = null;
        };
    }


    private void Update()
    {
        // 抛出加载进度
        if(m_AsyncOperation != null)
        {
            if(m_Progress != null)
            {
                m_Progress(m_AsyncOperation.progress);
                m_Progress = null;
            }
        }
    }
}
