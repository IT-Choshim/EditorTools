using System.Collections;
using System.Collections.Generic;
using Code.BDebug;
using UnityEngine;

public class SizeDelta : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BDebug.Log(this.transform.GetComponent<RectTransform>().sizeDelta);
        this.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(2, 1);
        BDebug.Log(this.transform.GetComponent<RectTransform>().sizeDelta);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
