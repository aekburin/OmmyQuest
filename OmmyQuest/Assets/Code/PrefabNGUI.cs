using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class PrefabNGUI : MonoBehaviour {
	public GameObject parent;
	public GameObject myPrefab;
	public GameObject DataManager;
	public string pocketMoney;
	public string carfare;
	public string totalMoney;
	public List<string> do_today;
	List<GameObject> transcript;
	transcript_variable tv;
	public List<string> datelist;
	ListToday ld;
	GameObject go;
	bool canset = true;
	private UIGrid grid;
	// Use this for initialization

	int MoneyBuy_Profile = 0;
	int MoneyIncome_Profile = 0;
	int TotalMoney_Profile = 0;

	void Start () {
		transcript = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Z)) 
		{
			string[] a = new string[0];
			PlayerPrefs.SetString(DateTime.Now.Date.ToString()+"pocketMoney","");
			PlayerPrefs.SetString(DateTime.Now.Date.ToString()+"carfare","");
			PlayerPrefs.SetString(DateTime.Now.Date.ToString()+"totalMoney","");
			PlayerPrefs.Save();
			//Debug.Log ("clear");
			PlayerPrefsX.SetStringArray(DateTime.Now.Date.ToString(),a);		
		}
		if(canset)
		{
			ld = DataManager.GetComponent<ListToday>();
			datelist = ld.datelist;
			if(datelist.Count!=0){
				createTranscript();
				canset=false;
			}

		}
	}
	public void createTranscript()
	{
			datelist.Reverse();
			//Debug.Log(datelist[0]);

			foreach(string temp in datelist)
			{
				pocketMoney = PlayerPrefs.GetString(temp+"pocketMoney");

				MoneyIncome_Profile += Convert.ToInt32(pocketMoney); // BUG float to string

				carfare = PlayerPrefs.GetString(temp+"carfare");

				totalMoney = PlayerPrefs.GetString(temp+"totalMoney");

				TotalMoney_Profile += int.Parse(totalMoney);
				MoneyBuy_Profile += (MoneyIncome_Profile - TotalMoney_Profile);	

				string[] a = PlayerPrefsX.GetStringArray(temp);
				string labeltranscript = "";
				string labelpayment = "";
				float totalpay = 0;
				foreach(string dotoday in a)
				{
					string[] splitdotoday = dotoday.Split(' ');
					labeltranscript+= splitdotoday[0] + splitdotoday[1]+"\n"; 
					labelpayment += splitdotoday[2]+"\n";
					
					totalpay += float.Parse(splitdotoday[2]);
					
				}
				
				tv = myPrefab.GetComponent<transcript_variable>();
				string[] datetemp = temp.Split(' ');
				tv.setLabel(totalMoney,datetemp[0],pocketMoney,labelpayment,labeltranscript);
				if(carfare!="")
				tv.setsprite(((float.Parse(carfare)+100)-(float.Parse(pocketMoney)-float.Parse(totalMoney)))/(float.Parse(carfare)+100),1-(float.Parse(totalMoney)/(float.Parse(pocketMoney)-(float.Parse (carfare)+100))));
				
				go = NGUITools.AddChild (parent, myPrefab);
				transcript.Add(go);
				go.transform.position= new Vector3 ((parent.gameObject.transform.childCount)*1.62f,-2.2f,0f);
			}
			
			PlayerPrefs.SetInt("MoneyBuy_Profile",MoneyBuy_Profile);
			PlayerPrefs.SetInt("MoneyIncome_Profile",MoneyIncome_Profile);
			PlayerPrefs.SetInt("TotalMoney_Profile",TotalMoney_Profile);


	}
	public void setbook ()
	{
		pocketMoney = PlayerPrefs.GetString(DateTime.Now.Date.ToString()+"pocketMoney");
		carfare = PlayerPrefs.GetString(DateTime.Now.Date.ToString()+"carfare");
		totalMoney = PlayerPrefs.GetString(DateTime.Now.Date.ToString()+"totalMoney");
		string[] a = PlayerPrefsX.GetStringArray(DateTime.Now.Date.ToString());
		string labeltranscript = "";
		string labelpayment = "";
		float totalpay = 0;
		foreach(string dotoday in a)
		{
			string[] splitdotoday = dotoday.Split(' ');
			labeltranscript+= splitdotoday[0] + splitdotoday[1]+"\n"; 
			labelpayment += splitdotoday[2]+"\n";
			totalpay += float.Parse(splitdotoday[2]);
		}
		//Debug.Log (totalpay);
		GameObject gots = transcript[0];
		tv = gots.GetComponent<transcript_variable> ();
		string[] datetemp = DateTime.Now.Date.ToString ().Split (' ');
		tv.setLabel(totalMoney ,datetemp[0],pocketMoney,labelpayment,labeltranscript);
		tv.setsprite(((float.Parse(carfare)+100)-(float.Parse(pocketMoney)-float.Parse(totalMoney)))/(float.Parse(carfare)+100),1-(float.Parse(totalMoney)/(float.Parse(pocketMoney)-float.Parse(carfare))));

	}

}
