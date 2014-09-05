using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class getTranscript : MonoBehaviour {
	public List<string> do_today;
	public List<string> whatdoing;
	public List<string> detail;
	public List<string> price;
	public List<string> time;
	// Use this for initialization
	void Start () {
		whatdoing = new List<string>(); 
		detail = new List<string>(); 
		price = new List<string>(); 
		time = new List<string>(); 
		do_today = new List<string>(); 
	}
	// Update is called once per frame
	void Update () {
	}
	public void getByDate(string date)
	{
		string[] temps = PlayerPrefsX.GetStringArray(date);
		foreach(string temp in temps)
		{
			do_today.Add(temp);
			string[] splitTemp = temp.Split(' ');
			whatdoing.Add(splitTemp[0]);
			detail.Add(splitTemp[1]);
			price.Add(splitTemp[2]);
			time.Add(splitTemp[3]);
		}
	}
}
