using UnityEngine;
using System.Collections;

public class ParentControlButtonConfirm : MonoBehaviour {

	GameObject ButtonContorl;
	GameObject PasswordLabel;
	UILabel txtstatus;
	ParentControl pc;
	UIInput pl;
	public TweenPosition tw;
	UILabel sentquestLabel;
	UILabel sentquestLabelPassword;
	UISprite sentquertSprite;
	string password;
	void Start () {
		sentquestLabelPassword = GameObject.Find("Password_Label").GetComponent<UILabel>();
		sentquestLabel = GameObject.Find("PasswordPlz").GetComponent<UILabel>();
		sentquertSprite = GameObject.Find("SentQuest2").GetComponent<UISprite>();
		txtstatus = GameObject.Find("TXT_Status").GetComponent<UILabel>();
		ButtonContorl = GameObject.Find("FX_button_Parent");
		PasswordLabel = GameObject.Find("TXT_Password_Label");
		pc = ButtonContorl.GetComponent<ParentControl>();
		pl = PasswordLabel.GetComponent<UIInput>();
		password = PlayerPrefs.GetString("password");
		string parent = PlayerPrefs.GetString("parentControl");
		tw = GameObject.Find("FX_button_Parent").GetComponent<TweenPosition>();
		if(parent == "true")
		{
			GameObject.Find("FX_button_Parent").transform.localPosition = new Vector3(13,0,0);
			tw.from = new Vector3(13,0,0);
			tw.to = new Vector3(-15,0,0);
			sentquestLabel.depth = 19;
			sentquestLabelPassword.depth = 19;
			sentquertSprite.depth = 18;
			Debug.Log("true");
		}
		else
		{
			sentquestLabel.depth = 10;
			sentquestLabelPassword.depth = 10;
			sentquertSprite.depth = 10;
			Debug.Log("false");
			GameObject.Find("FX_button_Parent").transform.localPosition = new Vector3(-15,0,0);
			tw.from = new Vector3(-15,0,0);
			tw.to = new Vector3(13,0,0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnClick()
	{
		password = PlayerPrefs.GetString("password");
		if(password == "")
		{
			PlayerPrefs.SetString("password",pl.value);
			PlayerPrefs.SetString("parentControl","true");
			Debug.Log(PlayerPrefs.GetString("parentControl"));
			txtstatus.text = "เปิดระบบ Parent Controll เรียบร้อย";
			sentquestLabel.depth = 19;
			sentquestLabelPassword.depth = 19;
			sentquertSprite.depth = 18;
		}
		else if(password == pl.value)
		{
			PlayerPrefs.SetString("password","");
			PlayerPrefs.SetString("parentControl","false");
			Debug.Log(PlayerPrefs.GetString("parentControl"));
			txtstatus.text = "ปิดระบบ Parent Controll เรียบร้อย";
			sentquestLabel.depth = 10;
			sentquestLabelPassword.depth = 10;
			sentquertSprite.depth = 10;
		}
	}
}
