using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProfileManager : MonoBehaviour {

	public List<UILabel> InputsLabel;
	// Use this for initialization

	void Start () {

		setName();
		setGender();
	}
	
	// Update is called once per frame
	void Update () {
		/*if(Input.GetKeyDown(KeyCode.P))
		{
			setName();
			setGender();
		}*/

	}

	public void setName()
	{
		InputsLabel[0].text = PlayerPrefs.GetString("Player_Name");

	}

	public void setGender()
	{
		InputsLabel[1].text = PlayerPrefs.GetString("Player_Gender");

	}
	public void setBirthday()
	{
		//InputsLabel[2].text = facebookInterActive.fbgender;
	}

	public void saveProfile()
	{
		PlayerPrefs.SetString("Player_Name",InputsLabel[0].text);
		PlayerPrefs.SetString("Player_Gender",InputsLabel[1].text);
		PlayerPrefs.SetString("Player_Birthday",InputsLabel[2].text);
	}
}
