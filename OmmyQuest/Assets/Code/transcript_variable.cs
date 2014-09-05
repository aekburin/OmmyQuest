using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class transcript_variable : MonoBehaviour {
	public List<UILabel> uilabel;
	public List<UISprite> uisprite;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void setLabel(string balance,string date,string money ,string payment,string transcript)
	{
		uilabel[0].text = balance;
		uilabel[1].text = date;
		uilabel[2].text = money;
		uilabel[3].text = payment;
		uilabel[4].text = transcript;
	}
	public void setsprite(float green, float red)
	{
		uisprite[0].fillAmount = green;
		uisprite[1].fillAmount = red;
	}
}
