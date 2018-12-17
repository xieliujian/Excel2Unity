using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestExcel : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        string configpath = Application.streamingAssetsPath + "/Config/Config.data";
        ConfigManager.LoadConfig(configpath);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
