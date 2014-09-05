using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
public class LoadUI : MonoBehaviour {
	
	public List<UILabel> label;	// Use this for initialization\
	public UISprite exp;
	public UISprite humanSprite;
	public GameObject dataManger;
	ListToday ld;
	defultApp da;

	void Start () {
		ld = dataManger.GetComponent<ListToday> ();
		da = dataManger.GetComponent<defultApp> ();
		label [0].text = da.money.ToString();
		label [1].text = da.gold.ToString();
		label [2].text = ld.pocketMoney.ToString();
		label [3].text = ld.totalMoney.ToString();
		label [4].text = da.lv.ToString();

		label[10].text = PlayerPrefs.GetString("name"); // name Character
		label[11].text = PlayerPrefs.GetString("sex");
		label[12].text = PlayerPrefs.GetString("birthday"); // birthday
		
		exp.fillAmount = (((50 * (float)da.lv - da.exp) / (50 * (float)da.lv)));

	}
	
	// Update is called once per frame
	void Update () {
		ld = dataManger.GetComponent<ListToday> ();
		da = dataManger.GetComponent<defultApp> ();
		label [0].text = string.Format("{0:0.##}", da.money);
		label [1].text = da.gold.ToString();
		label [2].text = ld.pocketMoney.ToString();
		label [3].text = ld.totalMoney.ToString();
		label [4].text = da.lv.ToString();
		label [5].text = GetComponent<characterStore> ().name[0];
		
		label[7].text = PlayerPrefs.GetInt("MoneyBuy_Profile").ToString(); // money buy
		label[8].text = PlayerPrefs.GetInt("MoneyIncome_Profile").ToString(); // money Income
		label[9].text = PlayerPrefs.GetInt("TotalMoney_Profile").ToString(); // total money
		label[13].text = ((float)(Convert.ToDouble(PlayerPrefs.GetInt("TotalMoney_Profile"))/Convert.ToDouble(PlayerPrefs.GetInt("MoneyIncome_Profile")))*100)+"%";
		humanSprite.fillAmount = (float)((Convert.ToDouble(PlayerPrefs.GetInt("TotalMoney_Profile"))/Convert.ToDouble(PlayerPrefs.GetInt("MoneyIncome_Profile"))));
	
		string[] charactername = GetComponent<characterStore> ().currentObject.name.Split ('(');
		int tempIndex = GetComponent<characterStore> ().modelName.IndexOf(charactername[0]);
		label [6].text = "Level "+GetComponent<characterStore> ().lv [tempIndex];
		int lvexp = 0;
		for (int i =1; i <= da.lv; i++) {
			lvexp += i*50;					
		}
		//exp.fillAmount = 1-(((50 * (float)da.lv - da.exp) / (50 * (float)da.lv)));
		exp.fillAmount =  (da.exp-(lvexp-da.lv*50)) / (lvexp-(lvexp-da.lv*50));
	}
}
