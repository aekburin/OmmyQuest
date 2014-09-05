using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class Achivement : MonoBehaviour {
	public List<int> ac_Level;
	public List<int> ac_Buddy;
	public List<int> ac_Saving;
	public List<int> ac_Level_Complete;
	public List<int> ac_Buddy_Complete;
	public List<int> ac_Saving_Complete;
	public List<UISprite> ac_sprite;
	// Use this for initialization
	void Start () {
		int[] levelbool = PlayerPrefsX.GetIntArray ("ac_level");
		ac_Level_Complete = initvar (levelbool, ac_Level_Complete);
		int[] buddybool = PlayerPrefsX.GetIntArray ("ac_buddy");
		ac_Buddy_Complete = initvar (buddybool, ac_Buddy_Complete);
		int[] savingbool = PlayerPrefsX.GetIntArray ("ac_saving");
		ac_Saving_Complete = initvar (savingbool, ac_Saving_Complete);
		initAch(ac_Level_Complete,0,"Achive_Lavel0",ac_Level);
		initAch(ac_Buddy_Complete,ac_Level.Count,"Buddy0",ac_Buddy);
		initAch(ac_Saving_Complete,(ac_Level.Count+ac_Buddy.Count),"Saving0",ac_Saving);
	}
	void initAch(List<int> temps,int begin,string name,List<int> ache)
	{
		string tempname = name;
		foreach(int temp in temps)
		{
			name = tempname+(ache.IndexOf(temp)+1);
			Debug.Log(name);
			ac_sprite[(begin+ache.IndexOf(temp))].spriteName = name;
		}
	}
	// Update is called once per frame
	void Update () {

	}
	public void findACLevel(int value)
	{
		process (ac_Level, ac_Level_Complete,"ac_level",value);
	}
	public void findACBuddy(int value)
	{
		process (ac_Buddy, ac_Level_Complete,"ac_buddy",value);
	}
	public void findACSaving(int value)
	{
		process (ac_Saving, ac_Level_Complete,"ac_saving",value);
	}
	public void process(List<int> temps,List<int> ach,string acType,int value)
	{
		bool collectAch = temps.IndexOf (value) > -1;
		int indextemp = 0;
		string name = "";
		if(acType == "ac_buddy")
		{
			indextemp+= ac_Level.Count;
			name = "Buddy0"+(temps.IndexOf (value)+1);
		}
		if(acType =="ac_saving")
		{
			indextemp+= (ac_Level.Count+ ac_Buddy.Count);
			name = "Saving0"+(temps.IndexOf (value)+1);
		}
		if(acType =="ac_level")
		{
			name = "Achive_Lavel0"+(temps.IndexOf (value)+1);
		}
		if (collectAch) {
			if(ach.IndexOf(value)== -1)
			{
				ach.Add(value);
				//Debug.Log(name);
				ac_sprite[(indextemp+ach.IndexOf(value))].spriteName = name;
			}
		}
		PlayerPrefsX.SetIntArray (acType, ach.ToArray ());
	}
	public List<int> initvar(int[] temps,List<int> ac)
	{
		ac.Clear ();
		foreach (int temp in temps) {
			ac.Add(temp);
		}
		return ac;
	}
}
