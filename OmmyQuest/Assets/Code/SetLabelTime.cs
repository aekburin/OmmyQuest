using UnityEngine;
using System.Collections;
using System;

public class SetLabelTime : MonoBehaviour {

	public UILabel labelObject;

	//private string timeText = "";
	private string dayText = "";
	private string monthText = "";
	private string dateText = "";
	private string YearText = "";
	
	public bool showDay;
	public bool showMonth;
	public bool showTime;
	public bool showDate;
	public bool showYear;
	public bool showAll;


	// Use this for initialization
	void Start () 
	{


		if(showMonth||showAll)
		{
			monthText = convertMonthToString (DateTime.Today.Date.Month)+" "+DateTime.Today.Year.ToString();
			//Debug.Log("monthText : "+monthText);
		}

		if(showDay||showAll)
		{
			string[] dayEng = {"Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday"};
			string[] dayThai = {"อาทิตย์","จันทร์","อังคาร","พุธ","พฤหัสบดี","ศุกร์","เสาร์"};
			int index = Array.IndexOf(dayEng,DateTime.Today.DayOfWeek.ToString() as String);
			dayText = dayThai[index];
			//Debug.Log("dayText : "+dayText);
		}

		if(showDate||showAll)
		{
			dateText = DateTime.Today.Day.ToString();
			//Debug.Log("dateText : "+dateText);
		}

		if(showYear||showAll)
		{
			YearText = DateTime.Today.Year.ToString();
			//Debug.Log("YearText : "+YearText);
		}
				
	}
	
	// Update is called once per frame
	void Update () 
	{
		updateTime ();

	}

	void updateTime()
	{
		if (showTime||showAll) {
			labelObject.text = ""+DateTime.Now.ToString ("HH:mm tt")+"\n"+dayText+"\n"+ dateText + " "
							+ monthText + " " + YearText + "\n";
		} 

		else{
			labelObject.text = ""+dayText+""+ dateText + ""
							+ monthText + "" + YearText;
		}

	}
	
	string convertMonthToString(int month)
	{
		String[] m = {"มหราคม","กุมภาพันธ์","มีนาคม","เมษายน","พฤษภาคม","มิถุนายน","กรกฎาคม","สิงหาคม","กันยายน","ตุลาคม","พฤศจิกายน","ธันวาคม"};
		return m[month-1];
	}
	
}
