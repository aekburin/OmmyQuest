using UnityEngine;
using System.Collections;

public class Click_CutScene : MonoBehaviour {
	public GameObject button;
	FadeScene fs;
	public float delay=3f;
	bool isclick=false;
	// Use this for initialization
	void Start () {
		fs = button.GetComponent<FadeScene>();
	}
	
	// Update is called once per frame
	void Update () {

		if(isclick)
		{
			delay -= Time.deltaTime;
		}
		if(Input.GetMouseButtonDown(0))
		{
			isclick = true;
		}
		if(delay <=0)
		{
			fs.sceneEnding = true;
		}
	}
}
