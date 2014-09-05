using UnityEngine;
using System.Collections;
using System;

public class ScreenCapture : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ScreenShot()
	{

		int d = PlayerPrefs.GetInt("numPic");
		/*if(d == null)
			d = 0;*/
		d++;
		Application.CaptureScreenshot("ScreenShot"+d+".jpg");
		PlayerPrefs.SetInt("numPic",d);

	}
}
