﻿using UnityEngine;
using System.Collections;

public class SelectFarm : MonoBehaviour {
	GameObject Store;
	characterShop cs;
	public bool isLeft;
	public bool isClickLeft;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnClick()
	{
		GameObject Store = GameObject.Find ("Farm(Clone)");
		CharactersFarm cs = Store.GetComponent<CharactersFarm>();
		if(isClickLeft)
		{
			cs.isClickLeft = true;
		}
		else if(!isClickLeft)
		{
			cs.isClickRight = true;
		}
	}
}
