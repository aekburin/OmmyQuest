using UnityEngine;
using System.Collections;

public class NextScene : MonoBehaviour {

    public string targetScene = "";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void goToNextScene()
    {
		if(targetScene != "")
        Application.LoadLevel(targetScene);
    }
}
