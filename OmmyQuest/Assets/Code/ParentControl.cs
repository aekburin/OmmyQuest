using UnityEngine;
using System.Collections;
using System;
public class ParentControl : MonoBehaviour {

	public bool isControl = false;
	public string password = "";
	public TweenPosition tw;
	public GameObject buttonContorller;
	UILabel sentquestLabel;
	UILabel sentquestLabelPassword;
	UISprite sentquertSprite;
	void Start () {
		sentquestLabelPassword = GameObject.Find("Password_Label").GetComponent<UILabel>();
		sentquestLabel = GameObject.Find("PasswordPlz").GetComponent<UILabel>();
		sentquertSprite = GameObject.Find("SentQuest2").GetComponent<UISprite>();
		tw = GetComponent<TweenPosition>();
		if(getParentControlStatus())
		{
			transform.localPosition = new Vector3(-13,0,0);
			tw.from = new Vector3(-13,0,0);
			tw.to = new Vector3(-15,0,0);
		}
		else
		{
			transform.localPosition = new Vector3(-13,0,0);
			tw.from = new Vector3(-15,0,0);
			tw.to = new Vector3(-13,0,0);

		}
		Debug.Log("asdffasdfasfdas");
		password = PlayerPrefs.GetString("parentControl");

	}
	public  bool getParentControlStatus()
	{
		isControl = Convert.ToBoolean(PlayerPrefs.GetString("parentControl"));
		return isControl;
	}
	public  string getPassword()
	{
		if( PlayerPrefs.GetString("password")!=null)
			password = PlayerPrefs.GetString("password");
		return password;
	}
	public  void setPassword(string password)
	{
		PlayerPrefs.SetString("password",password);
	}
	public  void setControl(string control)
	{
		PlayerPrefs.SetString("parentControl",control);
	}
}
