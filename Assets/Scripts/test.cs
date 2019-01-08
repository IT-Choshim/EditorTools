using System.Collections;
using System.Collections.Generic;
using Code.BResourceMgr;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Window_Logo logo = new Window_Logo(this.transform);
        logo.Init();

       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
