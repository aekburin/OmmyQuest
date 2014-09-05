using UnityEngine;
using System.Collections;

public class SoundCameraSceneMain : MonoBehaviour {

	public TweenPosition soundEffectButton ;
	private int state;

	// Use this for initialization
	void Start () {

		state = PlayerPrefs.GetInt("Status_Sound");
		if(state == 0) // turn off
		{
			soundEffectButton.Toggle();
			PlayerPrefs.SetInt("Status_Sound",1);
			AudioListener.pause = true;
			//Debug.Log ("state = "+state);
		}
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeSound()
	{

		state = PlayerPrefs.GetInt("Status_Sound");

		if(state == 0) // false,turn-off sound
		{
			AudioListener.pause = false; // change to turn on
			PlayerPrefs.SetInt("Status_Sound",1);
			//Debug.Log ("state = "+state);
		}
		else // true, turn-on sound
		{
			AudioListener.pause = true; // change to turn off
			PlayerPrefs.SetInt("Status_Sound",0);
			//Debug.Log ("state = "+state);
		}

	}
}
