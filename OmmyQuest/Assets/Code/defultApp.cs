using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
public class defultApp : MonoBehaviour {
	public string name;
	public string sex;
	public string birthday;
	public float exp;
	public float money;
	public float gold;
	public int lv;
	characterStore cs;
	public  GameObject storeP;
	public GameObject storeObject;
	public GameObject FarmObject;
	public GameObject Dataload;
	public List<UIInput> profileInput;
	public ButtonSendQuest btnsentQuest;
	public GameObject Farm;
	// Use this for initialization
	void Start () {
		name = PlayerPrefs.GetString("name");
		sex = PlayerPrefs.GetString("sex");
		birthday = PlayerPrefs.GetString("birthday");
		exp = PlayerPrefs.GetFloat("exp");
		money = PlayerPrefs.GetFloat("money");
		gold = PlayerPrefs.GetFloat("gold");
		lv = PlayerPrefs.GetInt("lv");
		if(Dataload!=null){
		cs = Dataload.GetComponent<characterStore> ();
		btnsentQuest = GameObject.Find ("Button_SendQuest").GetComponent<ButtonSendQuest>();
		}
		display ();
	}
	void display()
	{
		Debug.Log ("name: " + name + " sex: " + sex + " birthday: " + birthday + " exp: " + exp.ToString ()
						+ " money: " + money.ToString () + " gold: " + gold.ToString ()
						+ " lv: " + lv.ToString ());
	}
	// Update is called once per frame
	void Update () {
		exp = PlayerPrefs.GetFloat("exp");
		money = PlayerPrefs.GetFloat("money");
		gold = PlayerPrefs.GetFloat("gold");
		lv = PlayerPrefs.GetInt("lv");
		if(btnsentQuest != null)
		{
			if (DateTime.Now.Hour >= 18 && PlayerPrefs.GetString (DateTime.Now.Date.ToString () + "sentQuest") == ""  ) {
							btnsentQuest.canpress = true;
			}
			if(cs.status.Count>1)
			{
				UISprite buttonFarm =  GameObject.Find("Button_5Farm_nonactive").GetComponent<UISprite>();
				buttonFarm.depth = 6;
			}
			else
			{
				UISprite buttonFarm =  GameObject.Find("Button_5Farm_nonactive").GetComponent<UISprite>();
				buttonFarm.depth =9;
			}
		}
	}
	public void profile()
	{
		PlayerPrefs.SetString("name",profileInput[0].value);
		PlayerPrefs.SetString("sex",profileInput[1].value);
		PlayerPrefs.SetString("birthday",profileInput[2].value);
	}
	public void setLv(int lv)
	{
		this.lv = lv;
	}
	public void setGold(float gold)
	{
		this.gold = gold;
	}
	public void setMoney(float money)
	{
		this.money = money;
	}
	public void increadExp(float exp)
	{
		this.exp += exp;
	}
	public void setExp(float exp)
	{
		this.exp = exp;
	}
	public void setDefult()
	{
		PlayerPrefs.SetString ("name", profileInput[0].value);
		PlayerPrefs.SetString ("sex", profileInput [1].value);
		PlayerPrefs.SetString ("birthday", profileInput [2].value);
		PlayerPrefs.SetFloat ("exp", 0);
		PlayerPrefs.SetFloat ("money", 50);
		PlayerPrefs.SetFloat ("gold", 5);
		PlayerPrefs.SetInt ("lv",1);
		PlayerPrefs.Save ();
	}
	public  void createStore()
	{
		if(storeObject == null)
		{
		storeObject = Instantiate (storeP) as GameObject;
		cs = Dataload.GetComponent<characterStore> ();
		cs.currentObject.transform.position = new Vector3(10,10,10);
			Debug.Log("cs current = "+cs.currentObject.transform.position.ToString());
		}
	}
	public  void createFarm()
	{
		if(FarmObject == null)
		{
			FarmObject = Instantiate (Farm) as GameObject;
			cs = Dataload.GetComponent<characterStore> ();
			cs.currentObject.transform.position = new Vector3 (10, 10, 10);

		}
	}
	public  void removeStore()
	{
		cs.transform.position = new Vector3 (0, -2.5f, 11);
		Destroy (storeObject);
	}

}
