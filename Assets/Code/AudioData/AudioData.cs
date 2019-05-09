using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioData : MonoBehaviour
{

    private AudioSource _audioSource = null;
    private AudioClip _audioClip = null;

    private void Awake()
    {
        //_audioClip = new AudioClip();
        _audioSource = this.gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
        //_audioSource.clip = Microphone.Start("Built-in Microphone", true, 10, 44100);
        //_audioSource.Play();
    }

    private void OnGUI()
    {
        if(GUILayout.Button("<size = 50>开始录音</size>"))
        {
            _audioClip = Microphone.Start("Built-in Microphone", true, 10, 44100);
        }

        if(GUILayout.Button("<size = 50>结束录音</size>"))
        {
            if (_audioClip)
            {
                Microphone.End("Built-in Microphone");
            }
        }

        if(GUILayout.Button("<size = 50>播放保存录音</size>"))
        {
            if (_audioClip)
            {
                _audioSource.clip = _audioClip;
                _audioSource.Play();
            }
        }
    }
}
