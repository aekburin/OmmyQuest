using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ListToday : MonoBehaviour {
	
	public List<string> do_today;
	string whatdoing;
	public string whereIgo;
	public float pocketMoney;
	public float carfare;
	public float totalMoney;
    public List<UILabel> WhereIgo_Object;
    public List<UIInput> Budget_Object;
    public List<UILabel> Assign_Object;
	public List<UILabel> Payment_Object;
	public List<string> datelist;

	DateTime time;
    DateTime oldDate;
	void Start () 
    {
		datelist = new List<string>();
		do_today = new List<string>();
		string[] tempdo_today = PlayerPrefsX.GetStringArray(DateTime.Now.Date.ToString());
		foreach(string doing in tempdo_today)
		{	
			do_today.Add(doing);
		}
		string[] tempdatelist = PlayerPrefsX.GetStringArray("datelist");
		foreach(string date in tempdatelist)
		{
			datelist.Add(date);
		}
		int checkdatelist = Array.IndexOf(tempdatelist,DateTime.Now.Date.ToString());
		if(checkdatelist < 0 )
		{
			PlayerPrefs.SetInt("OpenQuested",0);
			datelist.Add(DateTime.Now.Date.ToString());
			PlayerPrefsX.SetStringArray("datelist",datelist.ToArray());
		}
		if (PlayerPrefs.GetString (DateTime.Now.Date.ToString () + "totalMoney") != "") {
	
				totalMoney = float.Parse (PlayerPrefs.GetString (DateTime.Now.Date.ToString () + "totalMoney"));
		}
		if (PlayerPrefs.GetString (DateTime.Now.Date.ToString () + "pocketMoney") != "") {
				pocketMoney = float.Parse (PlayerPrefs.GetString (DateTime.Now.Date.ToString () + "pocketMoney"));
		}
		//displayArray();
		time = DateTime.Now;
		SetDate(); // set date to current time
	}
	public void SetDate()
	{
		oldDate = time;
	}
	public bool CheckOldDate()
	{
		if(oldDate == time)
		{
			return true;
		}
		return false;
	}

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.L))
		{
			SetDate();
		}
		PlayerPrefs.SetString(DateTime.Now.Date.ToString()+"totalMoney",totalMoney.ToString());
		PlayerPrefs.SetString(DateTime.Now.Date.ToString()+"whereIgo",whereIgo);
		PlayerPrefs.SetString(DateTime.Now.Date.ToString()+"pocketMoney",pocketMoney.ToString());
		PlayerPrefs.SetString(DateTime.Now.Date.ToString()+"carfare",carfare.ToString());
		PlayerPrefs.Save ();
	}

	public void clearWhereIgo()
	{
		this.whereIgo = null;
	}
	public void setWhereIgo_Object1()
	{
		whereIgo = WhereIgo_Object [0].text;
		print ("where  = "+whereIgo);
	}
	public void setWhereIgo_Object2()
	{
		whereIgo = WhereIgo_Object [1].text;
		print ("where  = "+whereIgo);
	}
	public void setWhereIgo_Object3()
	{
		whereIgo = WhereIgo_Object [2].text;
		print ("where  = "+whereIgo);
	}
	public void setWhereIgo_Object4()
	{
		whereIgo = WhereIgo_Object [3].text;
		print ("where  = "+whereIgo);
	}
	public void setWhereIgo_Object5()
	{
		whereIgo = WhereIgo_Object [4].text;
		print ("where  = "+whereIgo);
	}

	public void clearPocketMoney()
	{
		this.pocketMoney = 0;
	}
	private void setBudget_Object1()
	{
		pocketMoney = float.Parse(Budget_Object [0].value);
		float use = 0;
		foreach(string doing in do_today)
		{
			string[] a = doing.Split(' ');
			use+= float.Parse(a[2]);
		}
		totalMoney = pocketMoney - use;
		PlayerPrefs.SetString(DateTime.Now.Date.ToString()+"totalMoney",totalMoney.ToString());
		print ("pocketMoney = "+pocketMoney);
		int PocketMoneyTemp = Convert.ToInt32(pocketMoney);
		PlayerPrefs.SetInt("MoneyIncome_Profile",(PlayerPrefs.GetInt("MoneyIncome_Profile")+PocketMoneyTemp));
	}
	private void setBudget_Object2()
	{
		carfare = float.Parse(Budget_Object [1].value);
		print ("carfare = "+carfare);

	}
	public void setBudgetAll()
	{
		setBudget_Object1 ();
		setBudget_Object2 ();
	}
	public void setPayment01()
	{
		whatdoing = Payment_Object[0].text;
	}
	public void setPayment02()
	{
		whatdoing = Payment_Object[1].text;
	}
	public void setPayment03()
	{
		whatdoing = Payment_Object[2].text;
	}
	public void setPayment04()
	{
		whatdoing = Payment_Object[3].text;
	}
	
	public void saveList()
	{
		totalMoney -=  float.Parse(Assign_Object[1].text);
		PlayerPrefs.SetString(DateTime.Now.Date.ToString()+"totalMoney",totalMoney.ToString());
		do_today.Add(whatdoing+" "+Assign_Object[0].text+" "+Assign_Object[1].text+" "+DateTime.Now.TimeOfDay.ToString());
		Debug.Log(do_today.Count);
		PlayerPrefsX.SetStringArray(DateTime.Now.Date.ToString(),do_today.ToArray());

		int MoneyBuy_Profile = PlayerPrefs.GetInt("MoneyBuy_Profile");
		int MoneyIncome_Profile = PlayerPrefs.GetInt("MoneyIncome_Profile");
		PlayerPrefs.SetInt("MoneyBuy_Profile",(MoneyBuy_Profile+int.Parse(Assign_Object[1].text)));
		
		MoneyBuy_Profile = PlayerPrefs.GetInt("MoneyBuy_Profile");
		PlayerPrefs.SetInt("TotalMoney_Profile",(MoneyIncome_Profile-MoneyBuy_Profile));
		Assign_Object [0].text = ""; // clear text
		Assign_Object [1].text = ""; // clear text
	}
	public void displayArray()
	{
		//Debug.Log(PlayerPrefs.GetString(DateTime.Now.Date.ToString()+"whereIgo"));
		//Debug.Log(PlayerPrefs.GetString(DateTime.Now.Date.ToString()+"pocketMoney"));
		//Debug.Log(PlayerPrefs.GetString(DateTime.Now.Date.ToString()+"carfare"));
		string[] a = PlayerPrefsX.GetStringArray(DateTime.Now.Date.ToString());
		foreach(string array in a)
		{
			Debug.Log (array);
		}
	}
	
}
