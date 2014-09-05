using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CallFacebookObject : MonoBehaviour {

	public GameObject fb;
	public InteractiveConsole_Facebook InterFB;
	private CharactersFarm characterFarm;
	// Use this for initialization
	void Awake () {
		fb = GameObject.Find ("Facebook_Object");
		if(fb != null)
			InterFB = fb.GetComponent<InteractiveConsole_Facebook> ();
	}
	public void FB_ShareScreen()
	{
		InterFB.ShareScreen();
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void FBLogOut()
	{
		FB.Logout();
	}

	public void GotoMiniGame1()
	{
		characterFarm = GameObject.Find("Farm(Clone)").GetComponent<CharactersFarm>();
		//Debug.Log(characterFarm.currentIndex);
		PlayerPrefs.SetString("NameCharacter_Minigame",characterFarm.charactersnameFarm[(characterFarm.currentIndex)]);
		//Debug.Log("NameCharacter_Minigame1 = "+characterFarm.charactersnameFarm[characterFarm.currentIndex]);
		Application.LoadLevel("05_Minigame");
	}
}
