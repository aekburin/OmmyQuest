using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class Message_Pet : MonoBehaviour {

	public List<string> Message_Good ; 
	public List<string> Message_Bad ; 
	public List<string> Message_Trip ; 

	private LoadUI loadUI;
	private float HumanSprite;

	public UILabel message_box;
	// Use this for initialization
	void Start () {
		//Debug.Log ("human = "+(float)(Convert.ToDouble(PlayerPrefs.GetInt("TotalMoney_Profile"))/Convert.ToDouble(PlayerPrefs.GetInt("MoneyIncome_Profile"))));
		loadUI = GameObject.Find("DataLoad").GetComponent<LoadUI>();
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void genMessage()
	{
		HumanSprite = (float)(Convert.ToDouble(PlayerPrefs.GetInt("TotalMoney_Profile"))/Convert.ToDouble(PlayerPrefs.GetInt("MoneyIncome_Profile")));

		int r = UnityEngine.Random.Range(0,2);

		if(r == 0)
		{
			if(HumanSprite > 0.5f) // message good
			{
				int index = UnityEngine.Random.Range(0,Message_Good.Count);
				message_box.text = Message_Good[index].ToString();

			}
			else if(HumanSprite < 0.5f ) // message bad
			{
				int index = UnityEngine.Random.Range(0,Message_Bad.Count);
				message_box.text = Message_Bad[index].ToString();
			}
		}
		else if(r == 1)
		{
			int index = UnityEngine.Random.Range(0,Message_Trip.Count);
			message_box.text = Message_Trip[index].ToString();

		}
	}
}
