using UnityEngine;
using System.Collections;

public class LodingPageScript : MonoBehaviour {
	public float delay;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		delay -= Time.deltaTime;
		if(delay<=0)
		{
			NextScene ns = GetComponent<NextScene>();
			if(PlayerPrefs.GetString("name")!= "")
			{
				ns.targetScene = "04_ Main";
			}
			else
			{
				ns.targetScene = "02_FacebookLogin";
			}
			ns.goToNextScene();
		}
	}
}
