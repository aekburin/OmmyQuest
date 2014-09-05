using UnityEngine;
using System.Collections;

public class ButtonSendQuest : MonoBehaviour {
	// Use this for initialization
	Collider sentquest;
	UISprite uiSentquest;
	public bool canpress = true;
	void Start () {
		sentquest = GameObject.Find ("Button_SendQuest").GetComponent<Collider>();
		uiSentquest = GameObject.Find ("Button_SendQuest").GetComponent<UISprite> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (canpress) {
			sentquest.enabled = true;
			uiSentquest.spriteName = "ButtonChallent";
		} else {
			uiSentquest.spriteName = "ButtonChallentBlack";
			sentquest.enabled = false;
		}
	}
}
