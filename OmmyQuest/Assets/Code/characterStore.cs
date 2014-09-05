using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class characterStore : MonoBehaviour {
	public List<string> status;
	public List<string> lv;
	public List<string> exp;
	public List<string> name;
	public List<string> coin;
	public List<string> modelName;
	public List<string> meterial;
	public List<string> lvup;
	public List<string> usecoin;
	public List<string> price;
	public List<string> AllCharacters;
	public List<string> datelist;

	string[] temps;
	public GameObject currentObject = null;
	void Start () {
		temps = PlayerPrefsX.GetStringArray("character");
		foreach(string temp in temps)
		{
			Debug.Log ("temp = "+temp);
			string[] splitTemp = temp.Split(' ');
			status.Add(splitTemp[0]);
			lv.Add(splitTemp[1]);
			exp.Add(splitTemp[2]);
			name.Add(splitTemp[3]);
			coin.Add(splitTemp[4]);
			modelName.Add(splitTemp[5]);
			meterial.Add(splitTemp[6]);
			lvup.Add(splitTemp[7]);
			usecoin.Add(splitTemp[8]);
			price.Add(splitTemp[9]);
		}

			int characterIndex = status.IndexOf("true");
			currentObject = Instantiate(Resources.Load("Characters/"+modelName[characterIndex]),new Vector3(0,-2.5f,11),Quaternion.Euler(0,180,0)) as GameObject;
			//Transform[] me =  currentObject.GetComponentsInChildren<Transform>();

			if(characterIndex == 0)
			{
				/*for(int i=1;i<me.Length;i++)
				{
					if(me[i].renderer!=null)
						me[i].renderer.material = Resources.Load ("Characters/m" +meterial[characterIndex]) as Material;
				}*/
			Transform[] m = GameObject.Find ("1(Clone)").GetComponentsInChildren<Transform>();
			//Debug.Log("Characters/m" +meterial[characterIndex]);
			 m[m.Length-1].renderer.material = Resources.Load ("Characters/m" +meterial[characterIndex]) as Material;
			}
		string[] tempdatelist = PlayerPrefsX.GetStringArray("datelist");
		foreach(string date in tempdatelist)
		{
			datelist.Add(date);
			//Debug.Log("datelist = "+date.ToString());
		}
		int checkdatelist = Array.IndexOf(tempdatelist,DateTime.Now.Date.ToString());
		if(checkdatelist < 0 )
		{
			for(int i = 0 ;i < usecoin.Count ; i++)
			{
				usecoin[i] = lv[i];
				//Debug.Log("usecoin "+i+" = "+usecoin[i]);
			}
			save();
		}

	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			PlayerPrefs.DeleteAll();
		}

	}
	public void swapCharacter(int newindex,string state)
	{	
		int index = status.IndexOf ("true");
		status[index] = "false";
		if (state == "select") {
			int trueindex = modelName.IndexOf ((newindex + 1).ToString ());
			//Debug.Log (trueindex);				
			status [trueindex] = "true";
		} else {
			status[newindex] = "true";	
		}
		save();
	}

	public void AddCharacter(int index,string price1,string coin1)
	{
		status.Add("false");
		lv.Add("1");
		exp.Add("0");
		name.Add(name[0]);
		coin.Add(coin1);
		lvup.Add ("150");
		usecoin.Add("1");
		price.Add(price1);
		modelName.Add((index).ToString());
		if (index == 0) {
			meterial.Add (meterial[0]);
		} else {
			meterial.Add ((index).ToString ());
		}
		swapCharacter (status.Count-1,"buy");
		//AllCharacters.Add (status[status.Count-1]+" 0 0 "+name[0]+" 0 "+index.ToString()+" "+index.ToString());
		Destroy (currentObject);
		destroyShop ();
		save();
	}
	public void destroyShop()
	{
		GameObject Store = GameObject.Find ("Store(Clone)") as GameObject;
		if (Store != null) {
						characterShop cs = Store.GetComponent<characterShop> ();
						GameObject CharacterStore = GameObject.Find ("DataLoad");
						characterStore csStore = CharacterStore.GetComponent<characterStore> ();
						
						Destroy (csStore.currentObject);
						if (csStore.status.IndexOf ("true") == 0) {
								csStore.currentObject = Instantiate (Resources.Load ("Characters/" + csStore.modelName [csStore.status.IndexOf ("true")]), new Vector3 (0, -2.5f, 11), Quaternion.Euler (0, 180, 0)) as GameObject;
								Transform[] me = csStore.currentObject.GetComponentsInChildren<Transform> ();
								for (int i=1; i<me.Length; i++) {
										if (me [i].renderer != null)
												me [i].renderer.material = Resources.Load ("Characters/m" + csStore.meterial [0]) as Material;
								}		
						} else {
								csStore.currentObject = Instantiate (Resources.Load ("Characters/" + csStore.modelName [csStore.status.IndexOf ("true")]), new Vector3 (0, -2.5f, 11), Quaternion.Euler (0, 180, 0)) as GameObject;
						}
						Destroy(cs.currentObject);
						Destroy (GameObject.Find ("storeChar"));
						Destroy (Store);
				}
	}
	public void destroyFarm()
	{
		GameObject Farm = GameObject.Find ("Farm(Clone)") as GameObject;
		if (Farm != null) {
			CharactersFarm cs = Farm.GetComponent<CharactersFarm> ();
			GameObject CharacterStore = GameObject.Find ("DataLoad");
			characterStore csStore = CharacterStore.GetComponent<characterStore> ();
			Destroy (csStore.currentObject);
			if (csStore.status.IndexOf ("true") == 0) {
				csStore.currentObject = Instantiate (Resources.Load ("Characters/" + csStore.modelName [csStore.status.IndexOf ("true")]), new Vector3 (0, -2.5f, 11), Quaternion.Euler (0, 180, 0)) as GameObject;
				Transform[] me = csStore.currentObject.GetComponentsInChildren<Transform> ();
				for (int i=1; i<me.Length; i++) {
					if (me [i].renderer != null)
						me [i].renderer.material = Resources.Load ("Characters/m" + csStore.meterial [0]) as Material;
				}		
			} else {
				csStore.currentObject = Instantiate (Resources.Load ("Characters/" + csStore.modelName [csStore.status.IndexOf ("true")]), new Vector3 (0, -2.5f, 11), Quaternion.Euler (0, 180, 0)) as GameObject;
			}
			Destroy (cs.currentGameobject);
			Destroy (GameObject.Find ("FarmChar"));
			Destroy (Farm);
		}
	}

	public void save()
	{
		AllCharacters.Clear ();

		for(int i=0;i<status.Count;i++){
			AllCharacters.Add(status[i]+" "+lv[i]+" "+exp[i]+" "+name[i]+" 0 "+modelName[i]+" "+meterial[i]+" "+lvup[i]+" "+usecoin[i]+" "+price[i]);
		}
		PlayerPrefsX.SetStringArray ("character",AllCharacters.ToArray());
		status.Clear();
		lv.Clear();
		exp.Clear();
		name.Clear();
		coin.Clear();
		modelName.Clear();
		meterial.Clear();
		lvup.Clear();
		usecoin.Clear();
		price.Clear();
		temps = PlayerPrefsX.GetStringArray("character");

		foreach(string temp in temps)
		{
			Debug.Log ("temp = "+temp);
			string[] splitTemp = temp.Split(' ');
			status.Add(splitTemp[0]);
			lv.Add(splitTemp[1]);
			exp.Add(splitTemp[2]);
			name.Add(splitTemp[3]);
			coin.Add(splitTemp[4]);
			modelName.Add(splitTemp[5]);
			meterial.Add(splitTemp[6]);
			lvup.Add(splitTemp[7]);
			usecoin.Add(splitTemp[8]);
			price.Add(splitTemp[9]);
		}
	}
}
