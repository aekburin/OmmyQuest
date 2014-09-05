using UnityEngine;
using System.Collections;

public class ButtonGoWhere : MonoBehaviour {

	private int checkQuest;
	private GameObject Quest_Today;
	private GameObject Quest_Payment;
	private TweenPosition q;

	// Use this for initialization
	void Start () {

		Quest_Today = GameObject.Find("_Quest1Today");
		Quest_Payment = GameObject.Find("_Quest3Payment");
	}
	
	// Update is called once per frame
	void Update () {
		checkQuest = PlayerPrefs.GetInt("OpenQuested");
	}

	void OnClick()
	{

		if(checkQuest == 0)
		{

			PlayerPrefs.SetInt("OpenQuested",1);
		}

		if(checkQuest == 1)
		{
			q = Quest_Today.GetComponent<TweenPosition>();
			q.PlayReverse();
			q = Quest_Payment.GetComponent<TweenPosition>();
			q.PlayForward();
		}

	}
}
