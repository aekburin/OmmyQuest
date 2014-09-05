using UnityEngine;
using System.Collections;

public class DontDestroyobject : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}

}
