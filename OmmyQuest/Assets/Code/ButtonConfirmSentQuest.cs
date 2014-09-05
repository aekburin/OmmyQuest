using UnityEngine;
using System.Collections;
using System;
public class ButtonConfirmSentQuest : MonoBehaviour {
	ButtonSendQuest btnsentquest;
	defultApp da;
	characterStore cs;
	// Use this for initialization
	void Start () {
		btnsentquest = GameObject.Find ("Button_SendQuest").GetComponent<ButtonSendQuest>();
		da = GameObject.Find ("DataManager").GetComponent<defultApp> ();
		cs = GameObject.Find ("DataLoad").GetComponent<characterStore> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetString (DateTime.Now.Date.ToString () + "sentQuest") != "") {
				UISprite uiDoquest = GameObject.Find ("Button_Quest").GetComponent<UISprite> ();
				uiDoquest.spriteName = "ButtonQuestBlack";
				UISprite uiSentquest = GameObject.Find ("Button_SendQuest").GetComponent<UISprite> ();
				uiSentquest.spriteName = "ButtonChallentBlack";
				btnsentquest.canpress = false;
		} else {
			UISprite uiDoquest = GameObject.Find ("Button_Quest").GetComponent<UISprite> ();
			uiDoquest.spriteName = "ButtonQuest";
		}
	}
	void OnClick()
	{
		string password = PlayerPrefs.GetString("password");
		string status = PlayerPrefs.GetString("parentControl");
		if(status == "true")
		{
			UIInput temp = GameObject.Find("Password_Label").GetComponent<UIInput>();
			if(password==temp.value)
			{
				PlayerPrefs.SetString (DateTime.Now.Date.ToString () + "sentQuest", "true");
				String pocketMoney = PlayerPrefs.GetString(DateTime.Now.Date.ToString()+"pocketMoney");
				String carfare = PlayerPrefs.GetString(DateTime.Now.Date.ToString()+"carfare");
				String totalMoney = PlayerPrefs.GetString(DateTime.Now.Date.ToString()+"totalMoney");
				float green = ((float.Parse (carfare) + 100) - (float.Parse (pocketMoney) - float.Parse (totalMoney))) / (float.Parse (carfare) + 100);
				float red = (float.Parse (totalMoney) / (float.Parse (pocketMoney) - (float.Parse (carfare)+100)));
				if (green < 0) {
					green = 0;		
				}
				if (green > 1) {
					green = 1;		
				}
				if (red > 1) {
					red = 1;		
				}
				if (red < 0) {
					red = 0;		
				}
				
				PlayerPrefs.SetFloat("exp",da.exp+(green*50)+(red*25));
				PlayerPrefs.SetFloat("money",(float)Math.Floor(da.money+(green*100)+((1-red)*50)));
				cs.exp [int.Parse (cs.currentObject.name.Split ('(') [0]) - 1] = (int.Parse(cs.exp [int.Parse (cs.currentObject.name.Split ('(') [0]) - 1])+Mathf.Floor(((float.Parse(totalMoney)/float.Parse(pocketMoney))*100))).ToString();
				int lvmascotup = int.Parse (cs.lvup [int.Parse (cs.currentObject.name.Split ('(') [0]) - 1]) * int.Parse (cs.lv [int.Parse (cs.currentObject.name.Split ('(') [0]) - 1]);
				if (int.Parse (cs.exp [int.Parse (cs.currentObject.name.Split ('(') [0]) - 1]) > lvmascotup)
				{
					//cs.exp [int.Parse (cs.currentObject.name.Split('(')[0]) - 1] = Math.Floor (int.Parse(cs.exp[int.Parse (cs.currentObject.name.Split('(')[0]) - 1]) + (green * 100) + ((1-red) * 50) / 2).ToString();
					cs.lv [int.Parse (cs.currentObject.name.Split ('(') [0]) - 1] = (int.Parse (cs.lv [int.Parse (cs.currentObject.name.Split ('(') [0]) - 1])+1).ToString();
					Debug.Log("up");
				}
				cs.save ();
				int lvexp = 0;
				for (int i =1; i <= da.lv; i++) {
					lvexp += i*50;					
				}
				if (lvexp < (da.exp+(green*50)+(red*25))) {
					Debug.Log("comeon");
					PlayerPrefs.SetInt("lv",(int)da.lv+1);
					Instantiate(Resources.Load("FX_LevelUP/FX_BoomLavelUp"));
				}
				PlayerPrefs.SetInt("totalMoneys",(int.Parse(totalMoney)+PlayerPrefs.GetInt("totalMoneys")));
				Achivement ach = GameObject.Find ("DataManager").GetComponent<Achivement>();
				if (PlayerPrefs.GetInt ("totalMoneys") >0) {
					ach.findACSaving (PlayerPrefs.GetInt ("totalMoneys"));
					ach.findACLevel (PlayerPrefs.GetInt ("lv"));
				}
			}
		}
		else
		{
			PlayerPrefs.SetString (DateTime.Now.Date.ToString () + "sentQuest", "true");
			String pocketMoney = PlayerPrefs.GetString(DateTime.Now.Date.ToString()+"pocketMoney");
			String carfare = PlayerPrefs.GetString(DateTime.Now.Date.ToString()+"carfare");
			String totalMoney = PlayerPrefs.GetString(DateTime.Now.Date.ToString()+"totalMoney");
			float green = ((float.Parse (carfare) + 100) - (float.Parse (pocketMoney) - float.Parse (totalMoney))) / (float.Parse (carfare) + 100);
			float red = (float.Parse (totalMoney) / (float.Parse (pocketMoney) - (float.Parse (carfare)+100)));
			if (green < 0) {
				green = 0;		
			}
			if (green > 1) {
				green = 1;		
			}
			if (red > 1) {
				red = 1;		
			}
			if (red < 0) {
				red = 0;		
			}
		
			PlayerPrefs.SetFloat("exp",da.exp+(green*50)+(red*25));
			PlayerPrefs.SetFloat("money",(float)Math.Floor(da.money+(green*100)+((1-red)*50)));
			cs.exp [int.Parse (cs.currentObject.name.Split ('(') [0]) - 1] = (int.Parse(cs.exp [int.Parse (cs.currentObject.name.Split ('(') [0]) - 1])+Mathf.Floor(((float.Parse(totalMoney)/float.Parse(pocketMoney))*100))).ToString();
			int lvmascotup = int.Parse (cs.lvup [int.Parse (cs.currentObject.name.Split ('(') [0]) - 1]) * int.Parse (cs.lv [int.Parse (cs.currentObject.name.Split ('(') [0]) - 1]);
			if (int.Parse (cs.exp [int.Parse (cs.currentObject.name.Split ('(') [0]) - 1]) > lvmascotup)
			{
			//cs.exp [int.Parse (cs.currentObject.name.Split('(')[0]) - 1] = Math.Floor (int.Parse(cs.exp[int.Parse (cs.currentObject.name.Split('(')[0]) - 1]) + (green * 100) + ((1-red) * 50) / 2).ToString();
				cs.lv [int.Parse (cs.currentObject.name.Split ('(') [0]) - 1] = (int.Parse (cs.lv [int.Parse (cs.currentObject.name.Split ('(') [0]) - 1])+1).ToString();
				Debug.Log("up");
			}
			cs.save ();
			int lvexp = 0;
			for (int i =1; i <= da.lv; i++) {
				lvexp += i*50;					
			}
			if (lvexp < (da.exp+(green*50)+(red*25))) {
				Debug.Log("comeon");
				PlayerPrefs.SetInt("lv",(int)da.lv+1);
				Instantiate(Resources.Load("FX_LevelUP/FX_BoomLavelUp"));
			}
			PlayerPrefs.SetInt("totalMoneys",(int.Parse(totalMoney)+PlayerPrefs.GetInt("totalMoneys")));
			Achivement ach = GameObject.Find ("DataManager").GetComponent<Achivement>();
			if (PlayerPrefs.GetInt ("totalMoneys") >0) {
					ach.findACSaving (PlayerPrefs.GetInt ("totalMoneys"));
					ach.findACLevel (PlayerPrefs.GetInt ("lv"));
			}
		}
	}
}
