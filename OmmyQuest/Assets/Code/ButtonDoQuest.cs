using UnityEngine;
using System.Collections;
using System;
public class ButtonDoQuest : MonoBehaviour {
	public bool canpress = false;
	Collider cd;
	// Use this for initialization
	void Start () {
		cd = GameObject.Find ("Button_Quest").GetComponent<Collider> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetString(DateTime.Now.Date.ToString()+"sentQuest") != "") {
			cd.enabled = false;
		} else {
			cd.enabled = true;
		}
	}
}
